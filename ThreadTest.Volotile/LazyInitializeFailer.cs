using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest.Volatile {

  /// <summary>
  /// This sample would fail only on processors with ARM architecture
  /// </summary>
  class LazyInitializeFailer {

    public static void Test() {

      LazyInitialized val = new LazyInitialized();
      long times = 0;
      Task.Run(() => val = new LazyInitialized());
      for (int i = 0; i < 3; i++) {
        Task.Run(() => {
          while (true) {
            Interlocked.Increment(ref times);
            if (val.Value == null)
              Console.WriteLine($"Failed after {times}");
          }
        });
      }

      while (true) {
        Thread.Sleep(7000);
        Console.WriteLine($"Executed {times}");
      }
    }
  }

  class ComplexObject {

    private double val;
    private string test;

    public ComplexObject() {

      var r = new Random();
      val = Math.Sin(r.Next() * Math.PI * 2);
      test = Guid.NewGuid().ToString();
    }
  }

  class LazyInitialized {

    private object syncObject = new object();
    private ComplexObject value;
    private bool initialized;

    public object Value {
      get {
        if (initialized)
          return value;

        lock (syncObject) {
          if (initialized)
            return value;

          value = new ComplexObject();
          initialized = true;
          return value;
        }
      }
    }
  }
}
