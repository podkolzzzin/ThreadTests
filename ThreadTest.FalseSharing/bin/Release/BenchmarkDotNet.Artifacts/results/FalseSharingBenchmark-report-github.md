``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3630QM CPU 2.40GHz (Ivy Bridge), ProcessorCount=8
Frequency=2338448 Hz, Resolution=427.6341 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2115.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2115.0


```
 |       Method |      Mean |     Error |    StdDev |
 |------------- |----------:|----------:|----------:|
 |   TwoThreads | 110.49 ms | 2.2105 ms | 6.4481 ms |
 | SingleThread |  13.00 ms | 0.0563 ms | 0.0439 ms |
