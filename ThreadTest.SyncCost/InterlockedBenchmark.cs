using System.Threading;
using BenchmarkDotNet.Attributes;

namespace ThreadTest.SyncCost {

  public class InterlockedBenchmark {

    [Params(1000/*, 100000, 1000000, 10000000*/)]
    public int Count;
    private object syncObject = new object();

    [Benchmark(Baseline = true)]
    public int NoInterlocked() {

      int i = 0;
      for (; i < Count; i++)
        ;
      return i;
    }

    [Benchmark]
    public int WithInterlocked() {

      int i = 0;
      for (; i < Count; Interlocked.Increment(ref i))
        ;
      return i;
    }

    [Benchmark]
    public int WithLock() {

      int i = 0;
      for (; i < Count;) {
        lock (syncObject)
          i++;
      }
      return i;
    }

    [Benchmark]
    public int MutexWait() {

      Mutex mutex = new Mutex();
      int i = 0;
      for (; i < Count;) {
        mutex.WaitOne();
        try {
          i++;
        }
        finally {
          mutex.ReleaseMutex();
        }
      }
      return i;
    }

    [Benchmark]
    public int ReadWriteLockWait() {

      ReaderWriterLock rwLock = new ReaderWriterLock();
      int i = 0;
      for (; i < Count;) {
        rwLock.AcquireWriterLock(int.MaxValue);
        try {
          i++;
        }
        finally {
          rwLock.ReleaseWriterLock();
        }
      }
      return i;
    }

    [Benchmark]
    public int ReadWriteLockSlimWait() {

      ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
      int i = 0;
      for (; i < Count;) {
        rwLock.EnterWriteLock();
        try {
          i++;
        }
        finally {
          rwLock.ExitWriteLock();
        }
      }
      return i;
    }
  }
}
