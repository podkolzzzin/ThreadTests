``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-3630QM CPU 2.40GHz (Ivy Bridge), ProcessorCount=8
Frequency=2338438 Hz, Resolution=427.6359 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2110.0
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2110.0


```
 |     Method |       Mean |     Error |    StdDev |     Median | Scaled | ScaledSD |
 |----------- |-----------:|----------:|----------:|-----------:|-------:|---------:|
 |    Ordered |   647.6 ns |  6.781 ns |  6.343 ns |   647.4 ns |   1.00 |     0.00 |
 | NotOrdered | 2,938.5 ns |  9.853 ns |  8.227 ns | 2,940.1 ns |   4.54 |     0.04 |
 | Branshless | 3,137.2 ns | 62.574 ns | 83.534 ns | 3,089.0 ns |   4.85 |     0.13 |
