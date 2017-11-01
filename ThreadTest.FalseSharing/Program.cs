using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ThreadTest.FalseSharing {

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

  class Program {
    static void Main(string[] args) {
    }
  }
}