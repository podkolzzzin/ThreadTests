using System;
using BenchmarkDotNet.Running;

namespace ThreadTest.SyncCost {

  class Program {

    static void Main(string[] args) {

      Console.WindowWidth = Math.Min(140, Console.LargestWindowWidth);

      BenchmarkRunner.Run<InterlockedBenchmark>();
    }
  }
}
