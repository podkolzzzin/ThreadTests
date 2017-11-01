``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3630QM CPU 2.40GHz (Ivy Bridge), ProcessorCount=8
Frequency=2338448 Hz, Resolution=427.6341 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2115.0


```
 |          Method | Count |         Mean |         Error |        StdDev |   Scaled | ScaledSD |
 |---------------- |------ |-------------:|--------------:|--------------:|---------:|---------:|
 |   NoInterlocked |  1000 |     338.6 ns |      3.205 ns |      2.502 ns |     1.00 |     0.00 |
 | WithInterlocked |  1000 |  11,274.0 ns |     87.891 ns |     73.393 ns |    33.30 |     0.31 |
 |        WithLock |  1000 |  22,869.3 ns |    442.426 ns |    434.522 ns |    67.55 |     1.33 |
 |      KernelWait |  1000 | 974,010.9 ns | 19,359.618 ns | 19,013.731 ns | 2,876.98 |    58.05 |
