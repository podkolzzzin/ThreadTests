using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ThreadTest.Volatile {

  class CodeEditorDemo {

    private volatile bool isDirty;
    private volatile int version;

    private string text;

    public bool IsDirty => isDirty;
    public int Version => version;

    public string Text {
      get {
        return text;
      }
      set {
        text = value;
        OnTextChanged();
      }
    }

    private void OnTextChanged() {

      isDirty = true;
      version++;
    }

    public int Parse() {

      int version = this.version;

      if (isDirty) {
        ThreadPool.QueueUserWorkItem(o => {
          // Emulate some work
          // Imagine that results of work are connected with value of 
          int textLength = text.Length;
          for (int i = 0; i < 500; i++)
            if (version != this.version)
              return;
          isDirty = false;
        });

      }
      return version;
    }
  }


  class Program {

    static void Main(string[] args) {

      object state = null;

      Thread thread = new Thread(SomeBackgroundJob);
      thread.Start(state);

      thread.Join();

      ThreadPool.QueueUserWorkItem(SomeBackgroundJob);


      //LazyInitializedFailer failer = new LazyInitializedFailer();
      //failer.Test();
      const int attempts = 700;
      var syncObject = new object();
      var editor = new CodeEditorDemo();
      ThreadPool.QueueUserWorkItem(o => {
        for (int j = 0; ;j++) {
          int parsedOnVersion = editor.Parse();
          for (int i = 0; i < attempts; i++)
            lock (syncObject)
              if (!editor.IsDirty && editor.Version != parsedOnVersion)
                throw new Exception($"{attempts * j+i} attempts, Version: {editor.Version} Volotile sOcks!");
        }
      });

      while (true) {
        lock (syncObject)
          editor.Text = "some text...";
        Thread.SpinWait(100);
      }
    }

    private static void Callback(IAsyncResult ar) {
      
    }

    private static void SomeBackgroundJob(object state) {
      throw new NotImplementedException();
    }
  }
}
