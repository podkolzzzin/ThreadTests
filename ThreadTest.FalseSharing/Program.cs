using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Schedulers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using TCO = System.Threading.Tasks.TaskCreationOptions;

namespace ThreadTest.FalseSharing {

  class SomeRepository {

    private Dictionary<int, string> cache;

    public ValueTask<string> GetById(int id) {

      string val;
      if (cache.TryGetValue(id, out val))
        return new ValueTask<string>(val);
      return new ValueTask<string>(
        RequestById(id));
    }

    private async Task<string> RequestById(int id) {
      return "";
    }
  }

  class BlockingCollectionSample {

    private BlockingCollection<string> data;
    // Thread#1
    private void ProduceData(IEnumerable<string> urls) {

      foreach (var url in urls)
        data.Add(LoadItem(url));
      data.CompleteAdding();
    }
    // Thread#2
    private void ConsumeData() { 

      foreach (var item in data.GetConsumingEnumerable())
        ProcessItem(item);
    }




    private void ProcessItem(string item) {

      data = new BlockingCollection<string>();
    }

    private string LoadItem(string url) {
      return "";
    }
  }

  class ConcurrentDictionarySample {

    private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

    private ConcurrentDictionary<int, string> cache;

    public string GetById(int id) {

      return cache.GetOrAdd(id, RequestById);
    }















    private string RequestById(int id) {
      return "";
    }

    public void Wrong() {

    }
  }

  class Result { }

  class SomeApiInstance {
    public event Action<Result> Done;

    public void Do() { }
  }

  class Msg { }

  class LongPollingApi {

    private Dictionary<int, TaskCompletionSource<Msg>> tasks;

    public async Task<Msg>  AcceptMessageAsync
      (int userId, int duration) {

      var cs = new TaskCompletionSource<Msg>();
      tasks[userId] = cs;
      await Task.WhenAny(Task.Delay(duration), cs.Task);
      return cs.Task.IsCompleted ? cs.Task.Result : null;
    }








    public void SendMessage(int userId, Msg m) {

      TaskCompletionSource<Msg> cs;
      if (tasks.TryGetValue(userId, out cs))
        cs.SetResult(m);
    }
  }

  static class OldApiWrapper {

    public static Task<Result> 
      DoAsync(this SomeApiInstance someApiObj) {

      var completionSource 
        = new TaskCompletionSource<Result>();

      someApiObj.Done += result =>
        completionSource.SetResult(result);

      someApiObj.Do();

      return completionSource.Task;
    }
  }

  class Generator {

    public static string GenerateString(int length) {

      var r = new Random();
      var s = new StringBuilder(length);
      for (int i = 0; i < length; i++)
        s.Append((char)r.Next('a', 'z'));
      return s.ToString();
    }
  }

  public class TrueFalseSharingBenchmark {

    private int[] result = new int['z' - 'a'];
    private string testData;

    public TrueFalseSharingBenchmark() {

      testData = Generator.GenerateString(65536000);
    }

    [Benchmark]
    public void ParallelTest() {

      Parallel.For(0, testData.Length, i => {
        Interlocked.Increment(ref result[testData[i] - 'a']);
      });
    }

    [Benchmark]
    public IDictionary<char, int> LinqTest() {

      return testData.GroupBy(f => f).ToDictionary(f => f.Key, f => f.Count());
    }

    [Benchmark]
    public IDictionary<char, int> PLinqTest() {

      return testData.AsParallel().GroupBy(f => f).ToDictionary(f => f.Key, f => f.Count());
    }

    [Benchmark]
    public void FourThreads() {

      var t1 = Task.Run(() => Count(0, testData.Length / 4));
      var t2 = Task.Run(() => Count(testData.Length / 4, testData.Length / 4 * 2));
      var t3 = Task.Run(() => Count(testData.Length / 4 * 2, testData.Length / 4 * 3));
      Count(testData.Length / 4 * 3, testData.Length);
      Task.WaitAll(t1, t2, t3);
    }

    [Benchmark]
    public int[] AnotherFourThreads() {

      var t1 = Task.Run(() => AnotherCount(0, testData.Length / 4));
      var t2 = Task.Run(() => AnotherCount(testData.Length / 4, testData.Length / 4 * 2));
      var t3 = Task.Run(() => AnotherCount(testData.Length / 4 * 2, testData.Length / 4 * 3));
      var data = AnotherCount(testData.Length / 2, testData.Length);

      for (int i = 0; i < data.Length; i++)
        data[i] += t1.Result[i] + t2.Result[i] + t3.Result[i];
      return data;
    }

    [Benchmark]
    public void SingleThread() {

      for (int i = 0; i < testData.Length; i++)
        result[testData[i] - 'a']++;
    }

    private void Count(int start, int end) {

      for (int i = start; i < end; i++)
        Interlocked.Increment(ref result[testData[i] - 'a']);
    }

    private int[] AnotherCount(int start, int end) {

      int[] data = new int['z' - 'a'];
      for (int i = start; i < end; i++)
        data[testData[i] - 'a']++;
      return data;
    }
  }

  class Tester {

    public static void Test(string test, Action ac) {

      const int count = 5;
      var sw = Stopwatch.StartNew();
      for (int i = 0; i < count; i++)
        ac();
      sw.Stop();
      Console.WriteLine("Test: " + test + $" {sw.ElapsedMilliseconds / count}ms");
    }

    public static /*volatile*/ int counter;
  
    public static void Do() {

      List<Task> tasks = new List<Task>();
      for (int i = 0; i < 10; i++) {
        tasks.Add(Task.Run(() => {
          for (int j = 0; j < 100000000; j++)
            //Thread.VolatileWrite(ref counter, Thread.VolatileRead(ref counter) + 1);
            Volatile.Write(ref counter, Volatile.Read(ref counter) + 1);
            //Interlocked.Increment(ref counter);
            //counter++;
        }));
      }
      Task.WaitAll(tasks.ToArray());
      Console.WriteLine(counter);
    }
  }

  class Program {

    private static TaskScheduler scheduler = new OrderedTaskScheduler();

    private bool SomethingIsDone;

    public void Test() {

      while (!SomethingIsDone)
        ;


      #region Process Result
      #endregion
    }

    static void Main(string[] args) {

      //BenchmarkRunner.Run<InterlockedBenchmark>();

      //var bench = new TrueFalseSharingBenchmark();
      //Tester.Test("PLinqTest   ", () => bench.PLinqTest());
      //Tester.Test("AFourThreads", () => bench.AnotherFourThreads());
      //Tester.Test("SingleThread", bench.SingleThread);
      //Tester.Test("LinqTest    ", () => bench.LinqTest());
      //Tester.Test("ParallelTest", bench.ParallelTest);
      //Tester.Test("FourThreads ", bench.FourThreads);


      //BenchmarkRunner.Run<TrueFalseSharingBenchmark>();
    }


    private class SomeException : Exception {

    }

    private static void HandleException(SomeException ex) { }

    public static async void AnotherMethod() {

      IEnumerable<Task> tasks = new Task[] {
        AsyncMethod(), OtherAsyncMethod()
      };

      int result;
      try {
        result = await AsyncMethod(); // good
        await Task.WhenAll(tasks);    // good
        await Task.WhenAny(tasks);    // good
      }
      catch (SomeException ex) {
        HandleException(ex);
        return;
      }

      try {
        result = AsyncMethod().Result; // bad
        AsyncMethod().Wait();          // bad
        Task.WaitAll(tasks.ToArray()); // bad
      }
      catch (AggregateException ex) {
        if (ex.InnerException is SomeException) {
          HandleException((SomeException)ex.InnerException);
          return;
        }
      }

      object state = null;
      WebRequest wr = WebRequest
        .CreateHttp("http://github.com");

      await Task.Factory.FromAsync(
        wr.BeginGetResponse, 
        wr.EndGetResponse, 
        state);




      Task task = AsyncMethod();

      #region Some Code

      #endregion

      if (task.Status == TaskStatus.Faulted)
        HandleException((SomeException)task.Exception.InnerException);

      if (task.IsFaulted)
        HandleException((SomeException)task.Exception.InnerException);





    }

    public static async Task<int> OtherAsyncMethod() {
      return 1;
    }


    public static async Task<int> AsyncMethod() {

      CancellationTokenSource cancelationSource = new CancellationTokenSource();

      await Task.Factory.StartNew(
        // code of action will be executed on other context
        () => Thread.Sleep(10000),
        cancelationSource.Token,
        TCO.LongRunning | TCO.AttachedToParent | TCO.PreferFairness,
        scheduler
      ).ConfigureAwait(false);

      // Code after await will be executed on other context
      return 10;
    }
  }
}
// https://habrastorage.org/getpro/habr/post_images/eee/b72/59e/eeeb7259e80ef4fbf102de85b25c3073.jpg
// https://habrahabr.ru/company/intel/blog/143446/