# Results

Following is the test suite name and the results from that test, in alphabetical order. 

## `ArgumentNullCheckOverload`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|               Method |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|      PassToNullCheck | 6.686 ns | 0.1909 ns | 0.2548 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
| PassWithoutNullCheck | 5.521 ns | 0.1167 ns | 0.1034 ns |  0.81 |    0.03 | 0.0057 |     - |     - |      24 B |
```

Conclusion - There is a slight bit of overhead if you don't make a null check, but I'd always make the check.

## `ConstructionViaTuples`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|           Method |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
| CreateViaSetters | 63.33 ns | 1.333 ns | 1.779 ns |  1.02 |    0.02 | 0.0114 |     - |     - |      48 B |
|   CreateViaTuple | 61.59 ns | 1.085 ns | 0.962 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
```

Conclusion - There's no difference. Use whatever style you like.

## `DynamicInvocations`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                   Method |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| ReturnValueViaDirectCall |  0.0333 ns | 0.0222 ns | 0.0208 ns |     ? |       ? |      - |     - |     - |         - |
|    ReturnValueViaDynamic | 11.9144 ns | 0.2307 ns | 0.2564 ns |     ? |       ? | 0.0115 |     - |     - |      48 B |

// * Warnings *
BaselineCustomAnalyzer
  Summary -> A question mark '?' symbol indicates that it was not possible to compute the (Ratio, RatioSD) column(s) because the baseline value is too close to zero.
```

Conclusion - Don't use `dynamic` unless absolutely necessary.

## `DynamicPropertyUsage

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|      Method |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| CallDynamic | 14.0606 ns | 0.1445 ns | 0.1281 ns |     ? |       ? | 0.0115 |     - |     - |      48 B |
|  CallDirect |  0.0143 ns | 0.0144 ns | 0.0135 ns |     ? |       ? |      - |     - |     - |         - |

// * Warnings *
BaselineCustomAnalyzer
  Summary -> A question mark '?' symbol indicates that it was not possible to compute the (Ratio, RatioSD) column(s) because the baseline value is too close to zero.
ZeroMeasurement
  DynamicPropertyUsage.CallDirect: Default -> The method duration is indistinguishable from the empty method duration
```
Conclusion - Don't use `dynamic` unless absolutely necessary.

## `ListsAndCapacity`
```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|-------:|------:|----------:|
|       CreateWithoutCapacity |     5 |     35.84 ns |   0.741 ns |   0.728 ns |  2.14 |    0.07 |  0.0306 |      - |     - |     128 B |
| CreateWith25PercentCapacity |     5 |     58.94 ns |   1.214 ns |   2.158 ns |  3.60 |    0.15 |  0.0459 |      - |     - |     192 B |
| CreateWith50PercentCapacity |     5 |     44.59 ns |   0.852 ns |   0.981 ns |  2.66 |    0.07 |  0.0382 |      - |     - |     160 B |
|          CreateWithCapacity |     5 |     16.71 ns |   0.357 ns |   0.367 ns |  1.00 |    0.00 |  0.0191 |      - |     - |      80 B |
|                             |       |              |            |            |       |         |         |        |       |           |
|       CreateWithoutCapacity |    10 |     60.87 ns |   1.142 ns |   1.812 ns |  2.07 |    0.10 |  0.0516 |      - |     - |     216 B |
| CreateWith25PercentCapacity |    10 |     71.29 ns |   1.428 ns |   2.048 ns |  2.42 |    0.10 |  0.0592 |      - |     - |     248 B |
| CreateWith50PercentCapacity |    10 |     42.04 ns |   0.772 ns |   0.793 ns |  1.42 |    0.05 |  0.0344 |      - |     - |     144 B |
|          CreateWithCapacity |    10 |     29.59 ns |   0.607 ns |   0.789 ns |  1.00 |    0.00 |  0.0229 |      - |     - |      96 B |
|                             |       |              |            |            |       |         |         |        |       |           |
|       CreateWithoutCapacity |    50 |    165.25 ns |   3.159 ns |   2.955 ns |  1.58 |    0.03 |  0.1547 |      - |     - |     648 B |
| CreateWith25PercentCapacity |    50 |    168.82 ns |   3.290 ns |   3.078 ns |  1.61 |    0.03 |  0.2027 |      - |     - |     848 B |
| CreateWith50PercentCapacity |    50 |    119.18 ns |   2.316 ns |   2.574 ns |  1.14 |    0.03 |  0.0918 |      - |     - |     384 B |
|          CreateWithCapacity |    50 |    104.57 ns |   1.456 ns |   1.362 ns |  1.00 |    0.00 |  0.0612 |      - |     - |     256 B |
|                             |       |              |            |            |       |         |         |        |       |           |
|       CreateWithoutCapacity |   100 |    287.27 ns |   5.652 ns |   5.287 ns |  1.42 |    0.04 |  0.2828 |      - |     - |    1184 B |
| CreateWith25PercentCapacity |   100 |    257.57 ns |   5.106 ns |  10.881 ns |  1.28 |    0.07 |  0.1931 |      - |     - |     808 B |
| CreateWith50PercentCapacity |   100 |    221.05 ns |   2.951 ns |   2.616 ns |  1.10 |    0.02 |  0.1624 |      - |     - |     680 B |
|          CreateWithCapacity |   100 |    202.32 ns |   4.035 ns |   4.318 ns |  1.00 |    0.00 |  0.1090 |      - |     - |     456 B |
|                             |       |              |            |            |       |         |         |        |       |           |
|       CreateWithoutCapacity |   500 |  1,220.92 ns |  20.813 ns |  18.450 ns |  1.14 |    0.03 |  1.0281 |      - |     - |    4304 B |
| CreateWith25PercentCapacity |   500 |  1,153.37 ns |  17.949 ns |  16.789 ns |  1.08 |    0.03 |  0.8621 |      - |     - |    3608 B |
| CreateWith50PercentCapacity |   500 |  1,125.85 ns |  21.557 ns |  22.137 ns |  1.05 |    0.03 |  0.7362 |      - |     - |    3080 B |
|          CreateWithCapacity |   500 |  1,068.03 ns |  21.023 ns |  23.367 ns |  1.00 |    0.00 |  0.4902 |      - |     - |    2056 B |
|                             |       |              |            |            |       |         |         |        |       |           |
|       CreateWithoutCapacity |  1000 |  2,499.51 ns |  41.300 ns |  38.632 ns |  1.11 |    0.02 |  2.0103 |      - |     - |    8424 B |
| CreateWith25PercentCapacity |  1000 |  2,404.99 ns |  46.189 ns |  45.364 ns |  1.07 |    0.02 |  1.6975 |      - |     - |    7104 B |
| CreateWith50PercentCapacity |  1000 |  2,335.61 ns |  46.628 ns |  49.891 ns |  1.03 |    0.03 |  1.4534 |      - |     - |    6080 B |
|          CreateWithCapacity |  1000 |  2,249.43 ns |  41.324 ns |  36.633 ns |  1.00 |    0.00 |  0.9689 |      - |     - |    4056 B |
|                             |       |              |            |            |       |         |         |        |       |           |
|       CreateWithoutCapacity |  5000 | 13,895.02 ns | 103.212 ns |  86.187 ns |  1.23 |    0.03 | 15.6708 | 1.5564 |     - |   65840 B |
| CreateWith25PercentCapacity |  5000 | 12,178.68 ns | 179.142 ns | 158.805 ns |  1.08 |    0.02 |  8.3618 |      - |     - |   35104 B |
| CreateWith50PercentCapacity |  5000 | 11,832.44 ns | 190.233 ns | 247.356 ns |  1.05 |    0.04 |  7.1564 |      - |     - |   30080 B |
|          CreateWithCapacity |  5000 | 11,287.50 ns | 211.479 ns | 217.173 ns |  1.00 |    0.00 |  4.7760 |      - |     - |   20056 B |
```
Conclusion - If you know what the capacity is, use that when the list is constructed. Even a decent guess is better than nothing.

## `RunOverflowingCode`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                Method |     i |     j |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------ |------ |----------:|----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
| MultiplyWithNoChecked |     3 |     7 | 0.0145 ns | 0.0148 ns | 0.0152 ns | 0.0158 ns |     ? |       ? |     - |     - |     - |         - |
|   MultiplyWithChecked |     3 |     7 | 0.2668 ns | 0.0314 ns | 0.0385 ns | 0.2707 ns |     ? |       ? |     - |     - |     - |         - |
|                       |       |       |           |           |           |           |       |         |       |       |       |           |
| MultiplyWithNoChecked |    12 |    44 | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|   MultiplyWithChecked |    12 |    44 | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|                       |       |       |           |           |           |           |       |         |       |       |       |           |
| MultiplyWithNoChecked |   243 | 48319 | 0.0044 ns | 0.0099 ns | 0.0083 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|   MultiplyWithChecked |   243 | 48319 | 0.0227 ns | 0.0212 ns | 0.0208 ns | 0.0213 ns |     ? |       ? |     - |     - |     - |         - |
|                       |       |       |           |           |           |           |       |         |       |       |       |           |
| MultiplyWithNoChecked |  4315 |  9199 | 0.0145 ns | 0.0145 ns | 0.0234 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|   MultiplyWithChecked |  4315 |  9199 | 0.2705 ns | 0.0229 ns | 0.0215 ns | 0.2739 ns |     ? |       ? |     - |     - |     - |         - |
|                       |       |       |           |           |           |           |       |         |       |       |       |           |
| MultiplyWithNoChecked | 10000 | 10000 | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |     - |     - |     - |         - |
|   MultiplyWithChecked | 10000 | 10000 | 0.2656 ns | 0.0155 ns | 0.0137 ns | 0.2633 ns |     ? |       ? |     - |     - |     - |         - |
```

Conclusion - Putting `checked` in your code may be slower, but it's so fast it probably won't matter.