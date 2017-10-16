using BenchmarkDotNet.Running;

namespace ThreadTest.BranchPrediction {
  class Program {
    static void Main(string[] args) {

      BenchmarkRunner.Run<ArraySumBenchmark>();
    }
  }
}
