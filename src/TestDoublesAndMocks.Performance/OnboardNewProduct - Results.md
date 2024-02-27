// * Summary *

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
Intel Core i7-14700KF, 1 CPU, 28 logical and 20 physical cores
.NET SDK 8.0.200-preview.23624.5
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


| Method                                              | Mean         | Error      | StdDev     | Ratio  | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------------------------------- |-------------:|-----------:|-----------:|-------:|--------:|-------:|-------:|----------:|------------:|
| OnboardNewProductUsingRocks                         |     74.29 ns |   0.511 ns |   0.478 ns |   0.65 |    0.01 | 0.0408 |      - |     704 B |        0.67 |
| OnboardNewProductUsingNSubstitute                   | 14,006.82 ns | 129.982 ns | 121.585 ns | 122.39 |    0.97 | 0.7324 | 0.6714 |   13400 B |       12.79 |
| OnboardNewProductUsingTestDouble                    |     60.24 ns |   0.229 ns |   0.203 ns |   0.53 |    0.00 | 0.0329 |      - |     568 B |        0.54 |
| OnboardNewProductUsingTestDoubleAndFluentInterfaces |    114.44 ns |   0.511 ns |   0.478 ns |   1.00 |    0.00 | 0.0607 |      - |    1048 B |        1.00 |