using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ThreadTest.BranchPrediction {

  public sealed class ArraySumBenchmark {

    private readonly int[] ordered, notOrdered;

    public ArraySumBenchmark() {

      ordered = Enumerable.Range(0, 1000).ToArray();
      Random r = new Random();
      notOrdered = ordered.OrderBy(f => r.Next()).ToArray();
    }

    [Benchmark(Baseline = true)]
    public int Ordered() => DoSum(ordered);

    [Benchmark]
    public int NotOrdered() => DoSum(notOrdered);

    private int DoSum(int[] arr) {

      int sum = 0;
      for (int i = 0; i < arr.Length; i++)
        if (arr[i] < 500)
          sum += arr[i];
      return sum;
    }
  }
}
