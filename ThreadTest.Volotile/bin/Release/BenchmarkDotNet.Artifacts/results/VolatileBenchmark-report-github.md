``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3630QM CPU 2.40GHz (Ivy Bridge), ProcessorCount=8
Frequency=2338438 Hz, Resolution=427.6359 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2110.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2110.0


```
 |          Method |      Mean |     Error |    StdDev |
 |---------------- |----------:|----------:|----------:|
 |    VolatileTest | 0.6588 ns | 0.0528 ns | 0.0542 ns |
 | InterlockedTest | 0.5824 ns | 0.0393 ns | 0.0368 ns |
 |          Simple | 0.6695 ns | 0.0510 ns | 0.0524 ns |
