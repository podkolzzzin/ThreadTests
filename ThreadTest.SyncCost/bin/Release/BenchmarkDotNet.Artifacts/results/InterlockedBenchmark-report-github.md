``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3630QM CPU 2.40GHz (Ivy Bridge), ProcessorCount=8
Frequency=2338448 Hz, Resolution=427.6341 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2115.0


```
 |                Method | Count |           Mean |         Error |        StdDev |   Scaled | ScaledSD |
 |---------------------- |------ |---------------:|--------------:|--------------:|---------:|---------:|
 |         NoInterlocked |  1000 |       455.6 ns |      3.059 ns |      2.862 ns |     1.00 |     0.00 |
 |       WithInterlocked |  1000 |    15,453.5 ns |    151.437 ns |    141.654 ns |    33.92 |     0.36 |
 |              WithLock |  1000 |    30,933.6 ns |    351.492 ns |    328.785 ns |    67.90 |     0.81 |
 |             MutexWait |  1000 | 1,301,543.2 ns | 19,803.436 ns | 17,555.228 ns | 2,856.83 |    40.96 |
 |     ReadWriteLockWait |  1000 |   115,131.5 ns |  1,019.006 ns |    795.573 ns |   252.71 |     2.27 |
 | ReadWriteLockSlimWait |  1000 |    61,322.2 ns |  1,217.614 ns |  2,431.707 ns |   134.60 |     5.35 |
