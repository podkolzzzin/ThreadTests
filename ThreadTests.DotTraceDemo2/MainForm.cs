using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using System.Windows.Forms;

namespace ThreadTests.DotTraceDemo2 {

  public partial class MainForm : Form {

    private sealed class TimeUtil : IDisposable {

      private readonly MainForm form;
      private readonly string action;
      private readonly Stopwatch sw;

      public TimeUtil(MainForm form, string action) {

        this.action = action;
        this.form = form;
        sw = Stopwatch.StartNew();
        form.Output($"Start {action}");
      }

      public void Dispose() {

        sw.Stop();
        form.Output($"End {action}. Elapsed: {(int)sw.ElapsedMilliseconds}ms");
      }
    }

    private CancellationTokenSource cancelSource;
    private List<Task> tasks;

    public MainForm() {

      InitializeComponent();
    }

    private void btStop_Click(object sender, EventArgs e) {

      cancelSource.Cancel();
      try {
        Task.WaitAll(tasks.ToArray());
      }
      catch { }
    }

    private void btStart_Click(object sender, EventArgs e) {

      Clear();
      btStart.Enabled = false;
      btStop.Enabled = true;
      try {
        ProcessImages();
      }
      catch (TaskCanceledException) { }
      finally {
        btStart.Enabled = true;
        btStop.Enabled = false;
      }
    }

    private void ProcessImages() {

      var files = new DirectoryInfo(@"..\..\imgs").EnumerateFiles();
      foreach (var file in files) {
        ProcessImage(file);
      }
    }

    private async Task ProcessImagesAsync(CancellationToken token) {

      var files = new DirectoryInfo(@"..\..\imgs").EnumerateFiles();
      tasks = new List<Task>();

      foreach (var file in files) {

        token.ThrowIfCancellationRequested();
        
        tasks.Add(Task.Factory.StartNew(
          () => ProcessImage(file),
          cancelSource.Token,
          TaskCreationOptions.None,
          TaskScheduler.Default));
      }
      await Task.WhenAll(tasks);
    }

    private void ProcessImage(FileInfo file) {

      Bitmap img;
      Output("===========================");
      using (new TimeUtil(this, $"Load {file.Name}"))
        img = (Bitmap)Image.FromFile(file.FullName);

      using (new TimeUtil(this, $"Process")) {
        Bitmap newImg = DropColorInfo(img);
        if (IsDark(newImg))
          Output($"{file.Name} is dark");
        else
          Output($"{file.Name} is not dark");
      }
    }

    private bool IsDark(Bitmap newImg) {

      int counter = 0;
      for (int i = 0; i < newImg.Width; i++)
        for (int j = 0; j < newImg.Height; j++)
          if (newImg.GetPixel(i, j).R < 128)
            counter++;
      return counter > (newImg.Width * newImg.Height / 2);
    }

    private Bitmap DropColorInfo(Bitmap img) {

      Bitmap newBmp = new Bitmap(img.Width, img.Height);
      for (int i = 0; i < img.Width; i++)
        for (int j = 0; j < img.Height; j++) {
          Color color = img.GetPixel(i, j);
          int gray = (color.R + color.G + color.B) / 3;
          Color grayColor = Color.FromArgb(
            gray, gray, gray);
          newBmp.SetPixel(i, j, grayColor);
        }
      return newBmp;
    }

    private void Output(string line) {

      Do(() => tbOutput.AppendText($"{line}{Environment.NewLine}"));
    }

    private void Clear() {

      Do(() => tbOutput.Clear());
    }

    private void Do(Action action) {

      if (InvokeRequired)
        BeginInvoke(action);
      else
        action();
    }
  }
}
