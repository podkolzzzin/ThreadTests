using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadTest.TaskDeadlock {

  public partial class MainForm : Form {

    public MainForm() {
      InitializeComponent();
    }

    private async void btDownload_Click(object sender, EventArgs e) {

      DoWork().Wait();
    }

    private async Task DoWork() {

      using (var wc = new WebClient())
        for (int i = 0; i < 3; i++)
          await wc.DownloadStringTaskAsync("http://github.com");
      btDownload.Text = "Done";
    }
  }
}
