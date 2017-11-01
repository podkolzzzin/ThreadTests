using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest.BusyWait {

  public class CancelSample {

    private bool isDone;

    private CancellationTokenSource cancelationSource;

    public void Do() {

      cancelationSource = new CancellationTokenSource();
      DoWorkInternal(cancelationSource.Token);
    }

    public void Cancel() => cancelationSource.Cancel();

    private void DoWorkInternal(CancellationToken token) {

      while (!isDone) {
        token.ThrowIfCancellationRequested();
        DoWorkPart();
      }
    }

    private void DoWorkPart() {
    }
  }

  class Program {

    public static bool SomethingIsDone {
      get;
      set;
    }

    private static void BusyWait() {

      while (!SomethingIsDone)
        Thread.Sleep(1);

      #region Process Result
      #endregion
    }

    static void Main(string[] args) {
      BusyWait();
    }
  }
}
