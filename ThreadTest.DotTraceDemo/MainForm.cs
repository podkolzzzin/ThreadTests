using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AHtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace ThreadTest.DotTraceDemo {
  public partial class MainForm : Form {

    private const string host = "http://github.com";

    private HashSet<string> downloaded;

    private CancellationTokenSource cancelToken;
    private BlockingCollection<string> urls;

    public MainForm() {
      InitializeComponent();
    }

    private void btStart_Click(object sender, EventArgs e) {

      if (cancelToken != null) {
        cancelToken.Cancel();
        btStart.Text = "Start";
      }
      else {
        cancelToken = new CancellationTokenSource();
        urls = new BlockingCollection<string>();
        downloaded = new HashSet<string>();
        urls.Add(host);
        btStart.Text = "Stop";
        StartLoad();
      }
    }

    private async Task<Tuple<string, string>> DownloadStringAsync(string url) {

      using (WebClient wc = new WebClient()) {
        try {
          var result = await wc.DownloadStringTaskAsync(url);
          return Tuple.Create(url, result);
        }
        catch {
          return null;
        }
      }
    }

    private List<Task<Tuple<string, string>>> DownloadMany(int count) {
      
      var result = new List<Task<Tuple<string, string>>>();
      int toTake = Math.Min(count, urls.Count);
      if (toTake == 0)
        toTake = count;
      foreach (var item in urls.GetConsumingEnumerable().Take(toTake)) { 
        result.Add(DownloadStringAsync(item));
      }
      return result;
    }

    private async void StartLoad() {

      using (WebClient wc = new WebClient()) {
        while (true) {

          if (cancelToken.IsCancellationRequested)
            return;

          var items = DownloadMany(5);
          while (items.Count > 0) {
            var s = await Task.WhenAny(items);
            items.Remove(s);
            if (s.Result != null) {
              downloaded.Add(s.Result.Item1);
              ExtractLinks(s.Result.Item1, s.Result.Item2);
            }
            UpdateUI();
          }
        }
      }
    }

    private void ExtractLinks(string currentUri, string content) {

      Task.Run(() => {
        var doc = new AHtmlDocument();
        doc.LoadHtml(content);

        var links = doc.DocumentNode.Descendants("a")
          .Select(f => f.GetAttributeValue("href", null))
          .Where(f => f != null)
          .Select(f => ToAbsoluteUri(currentUri, f))
          .Where(f => f != null);

        foreach (var item in links)
          if (!downloaded.Contains(item))
            urls.Add(item);
      });
    }

    private void UpdateUI() {

      tbDone.Text = downloaded.Count.ToString();
      tbQueue.Text = urls.Count.ToString();
    }

    private string ToAbsoluteUri(string baseLink, string uri) {

      Uri baseUri = new Uri(baseLink);
      Uri result;
      if (Uri.TryCreate(baseUri, uri, out result))
        return result.ToString();
      return null;
    }
  }
}
