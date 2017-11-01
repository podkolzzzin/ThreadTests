``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3630QM CPU 2.40GHz (Ivy Bridge), ProcessorCount=8
Frequency=2338448 Hz, Resolution=427.6341 ns, Timer=TSC
  [Host] : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2115.0 DEBUG


```
 |                Method | Count | Mean | Error | Scaled | ScaledSD |
 |---------------------- |------ |-----:|------:|-------:|---------:|
 |         NoInterlocked |  1000 |   NA |    NA |      ? |        ? |
 |       WithInterlocked |  1000 |   NA |    NA |      ? |        ? |
 |              WithLock |  1000 |   NA |    NA |      ? |        ? |
 |             MutexWait |  1000 |   NA |    NA |      ? |        ? |
 |     ReadWriteLockWait |  1000 |   NA |    NA |      ? |        ? |
 | ReadWriteLockSlimWait |  1000 |   NA |    NA |      ? |        ? |

Benchmarks with issues:
  InterlockedBenchmark.NoInterlocked: DefaultJob [Count=1000]
  InterlockedBenchmark.WithInterlocked: DefaultJob [Count=1000]
  InterlockedBenchmark.WithLock: DefaultJob [Count=1000]
  InterlockedBenchmark.MutexWait: DefaultJob [Count=1000]
  InterlockedBenchmark.ReadWriteLockWait: DefaultJob [Count=1000]
  InterlockedBenchmark.ReadWriteLockSlimWait: DefaultJob [Count=1000]
