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

## `AttributeLookup`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                                       Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|           FindMethodCountWith5UsingIsDefined |  2,693.9 ns |  62.34 ns | 180.87 ns | 0.1068 |     - |     - |     448 B |
|  FindMethodCountWith5UsingGetCustomAttribute |  6,886.4 ns |  86.23 ns |  80.66 ns | 0.2518 |     - |     - |    1064 B |
|       FindMethodCountWith5UsingWellKnownName |    292.1 ns |   5.30 ns |   7.93 ns | 0.0610 |     - |     - |     256 B |
|          FindMethodCountWith10UsingIsDefined |  3,627.6 ns |  55.71 ns |  49.39 ns | 0.1259 |     - |     - |     528 B |
| FindMethodCountWith10UsingGetCustomAttribute | 10,247.8 ns | 203.05 ns | 189.93 ns | 0.3510 |     - |     - |    1504 B |
|      FindMethodCountWith10UsingWellKnownName |    418.8 ns |   7.96 ns |   8.52 ns | 0.0801 |     - |     - |     336 B |
|          FindMethodCountWith20UsingIsDefined |  5,067.4 ns |  52.91 ns |  44.18 ns | 0.1602 |     - |     - |     688 B |
| FindMethodCountWith20UsingGetCustomAttribute | 18,150.3 ns | 355.99 ns | 499.04 ns | 0.5493 |     - |     - |    2384 B |
|      FindMethodCountWith20UsingWellKnownName |    649.1 ns |  12.37 ns |  24.99 ns | 0.1183 |     - |     - |     496 B |
|          FindMethodCountWith50UsingIsDefined |  9,971.9 ns |  93.95 ns |  78.45 ns | 0.2747 |     - |     - |    1168 B |
| FindMethodCountWith50UsingGetCustomAttribute | 36,255.5 ns | 717.40 ns | 635.96 ns | 1.1597 |     - |     - |    5025 B |
|      FindMethodCountWith50UsingWellKnownName |  1,303.5 ns |  19.12 ns |  17.89 ns | 0.2327 |     - |     - |     976 B |
```

Conclusion - It is quicker and uses less memory to look up a method if it uses a well-known name. However, the advantage an attribute has is that it provides a bit of naming flexibility.

## `ComparingCases`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                   Method |       Level |       Mean |     Error |    StdDev |     Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------------ |-----------:|----------:|----------:|-----------:|------:|------:|------:|----------:|
| IsEnabledUsingDictionary |       Trace | 15.8581 ns | 0.8394 ns | 2.4751 ns | 15.7820 ns |     - |     - |     - |         - |
|     IsEnabledUsingSwitch |       Trace |  1.1732 ns | 0.1449 ns | 0.4134 ns |  1.0983 ns |     - |     - |     - |         - |
|         IsEnabledUsingIf |       Trace |  1.2271 ns | 0.1718 ns | 0.4789 ns |  1.2076 ns |     - |     - |     - |         - |

| IsEnabledUsingDictionary |       Debug |  8.6573 ns | 0.9249 ns | 2.7272 ns |  7.0957 ns |     - |     - |     - |         - |
|     IsEnabledUsingSwitch |       Debug |  1.4021 ns | 0.0528 ns | 0.0494 ns |  1.3995 ns |     - |     - |     - |         - |
|         IsEnabledUsingIf |       Debug |  0.6967 ns | 0.0432 ns | 0.0404 ns |  0.6932 ns |     - |     - |     - |         - |

| IsEnabledUsingDictionary |     Warning |  7.8176 ns | 0.1822 ns | 0.1789 ns |  7.8634 ns |     - |     - |     - |         - |
|     IsEnabledUsingSwitch |     Warning |  1.0544 ns | 0.0552 ns | 0.0658 ns |  1.0510 ns |     - |     - |     - |         - |
|         IsEnabledUsingIf |     Warning |  1.2853 ns | 0.0587 ns | 0.0653 ns |  1.2762 ns |     - |     - |     - |         - |

| IsEnabledUsingDictionary |       Error |  7.3820 ns | 0.1811 ns | 0.2156 ns |  7.4259 ns |     - |     - |     - |         - |
|     IsEnabledUsingSwitch |       Error |  1.1043 ns | 0.0590 ns | 0.0788 ns |  1.1135 ns |     - |     - |     - |         - |
|         IsEnabledUsingIf |       Error |  1.8791 ns | 0.0734 ns | 0.1099 ns |  1.8452 ns |     - |     - |     - |         - |

| IsEnabledUsingDictionary | Information |  7.1012 ns | 0.1646 ns | 0.1540 ns |  7.1020 ns |     - |     - |     - |         - |
|     IsEnabledUsingSwitch | Information |  1.3130 ns | 0.0564 ns | 0.0471 ns |  1.3277 ns |     - |     - |     - |         - |
|         IsEnabledUsingIf | Information |  1.7361 ns | 0.0576 ns | 0.0481 ns |  1.7303 ns |     - |     - |     - |         - |

| IsEnabledUsingDictionary |    Critical |  7.8286 ns | 0.1889 ns | 0.3594 ns |  7.8190 ns |     - |     - |     - |         - |
|     IsEnabledUsingSwitch |    Critical |  0.9075 ns | 0.0517 ns | 0.0933 ns |  0.8937 ns |     - |     - |     - |         - |
|         IsEnabledUsingIf |    Critical |  1.7687 ns | 0.0621 ns | 0.0519 ns |  1.7533 ns |     - |     - |     - |         - |
```

Conclusion - Don't use a `Dictionary<,>` to mimic a `switch` or `if`.

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

## `FibonacciApproaches`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                  Method | start |                Mean |             Error |            StdDev |              Median |        Ratio |    RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |------ |--------------------:|------------------:|------------------:|--------------------:|-------------:|-----------:|-------:|------:|------:|----------:|
|      CalculateUsingList |     1 |            15.02 ns |          0.330 ns |          0.709 ns |            14.83 ns |         0.85 |       0.09 |      - |     - |     - |         - |
| CalculateUsingRecursive |     1 |            14.59 ns |          0.853 ns |          2.503 ns |            13.92 ns |         0.93 |       0.16 |      - |     - |     - |         - |
|    CalculateUsingLocals |     1 |            15.91 ns |          0.901 ns |          2.656 ns |            16.28 ns |         1.00 |       0.00 |      - |     - |     - |         - |
|                         |       |                     |                   |                   |                     |              |            |        |       |       |           |
|      CalculateUsingList |     3 |           151.50 ns |          2.997 ns |          3.077 ns |           151.71 ns |         2.27 |       0.07 | 0.0286 |     - |     - |     120 B |
| CalculateUsingRecursive |     3 |           179.19 ns |          3.604 ns |          9.619 ns |           178.41 ns |         2.69 |       0.07 |      - |     - |     - |         - |
|    CalculateUsingLocals |     3 |            66.88 ns |          1.370 ns |          1.282 ns |            66.33 ns |         1.00 |       0.00 |      - |     - |     - |         - |
|                         |       |                     |                   |                   |                     |              |            |        |       |       |           |
|      CalculateUsingList |     6 |           265.61 ns |          5.341 ns |          5.714 ns |           264.41 ns |         2.32 |       0.12 | 0.0648 |     - |     - |     272 B |
| CalculateUsingRecursive |     6 |         1,040.99 ns |         20.008 ns |         53.406 ns |         1,041.41 ns |         9.29 |       0.72 |      - |     - |     - |         - |
|    CalculateUsingLocals |     6 |           112.25 ns |          2.280 ns |          5.965 ns |           111.23 ns |         1.00 |       0.00 |      - |     - |     - |         - |
|                         |       |                     |                   |                   |                     |              |            |        |       |       |           |
|      CalculateUsingList |    12 |           299.66 ns |          9.566 ns |         26.823 ns |           291.30 ns |         1.59 |       0.15 | 0.1316 |     - |     - |     552 B |
| CalculateUsingRecursive |    12 |        16,789.03 ns |      1,535.818 ns |      4,528.395 ns |        18,447.64 ns |        69.88 |      18.99 |      - |     - |     - |         - |
|    CalculateUsingLocals |    12 |           196.09 ns |          3.961 ns |          8.000 ns |           196.23 ns |         1.00 |       0.00 |      - |     - |     - |         - |
|                         |       |                     |                   |                   |                     |              |            |        |       |       |           |
|      CalculateUsingList |    20 |           755.32 ns |         14.963 ns |         25.811 ns |           752.26 ns |         2.35 |       0.12 | 0.2594 |     - |     - |    1088 B |
| CalculateUsingRecursive |    20 |       892,330.81 ns |     17,606.757 ns |     28,928.407 ns |       891,717.09 ns |     2,780.91 |     144.58 |      - |     - |     - |         - |
|    CalculateUsingLocals |    20 |           323.16 ns |          6.394 ns |         12.472 ns |           324.18 ns |         1.00 |       0.00 |      - |     - |     - |         - |
|                         |       |                     |                   |                   |                     |              |            |        |       |       |           |
|      CalculateUsingList |    35 |         1,237.94 ns |         24.769 ns |         37.074 ns |         1,237.85 ns |         2.39 |       0.06 | 0.5093 |     - |     - |    2136 B |
| CalculateUsingRecursive |    35 | 1,262,866,745.45 ns | 24,879,472.607 ns | 39,461,480.038 ns | 1,259,147,000.00 ns | 2,433,558.20 | 112,587.12 |      - |     - |     - |      88 B |
|    CalculateUsingLocals |    35 |           524.35 ns |         10.404 ns |          9.223 ns |           526.07 ns |         1.00 |       0.00 |      - |     - |     - |         - |
```

Conclusion - Using local variables is the quickest and allocates the least amount of memory.

## `IteratingAnonymousAndTupleTypes`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                    Method |     Mean |   Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |---------:|--------:|---------:|------:|--------:|-------:|------:|------:|----------:|
| IterateOverAnonymousTypes | 432.8 ns | 8.65 ns | 16.25 ns |  1.07 |    0.04 | 0.2942 |     - |     - |    1.2 KB |
|     IterateOverTupleTypes | 410.3 ns | 7.66 ns |  9.96 ns |  1.00 |    0.00 | 0.2770 |     - |     - |   1.13 KB |
```

Conclusion - Tuple types might be **slightly** better. I need to do more investigations in this area.

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

## `NegatingNumbers`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                Method | value |       Mean |     Error |    StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------ |-----------:|----------:|----------:|-----------:|-------:|------:|------:|----------:|
|    NegateWithNegation | -1500 |  0.0285 ns | 0.0277 ns | 0.0296 ns |  0.0173 ns |      - |     - |     - |         - |
| NegateWithNegativeOne | -1500 |  0.0863 ns | 0.0361 ns | 0.0572 ns |  0.0822 ns |      - |     - |     - |         - |
|      NegateWithString | -1500 | 69.2971 ns | 1.4136 ns | 2.1587 ns | 69.1029 ns | 0.0153 |     - |     - |      64 B |
|    NegateWithNegation |  1500 |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |      - |     - |     - |         - |
| NegateWithNegativeOne |  1500 |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |      - |     - |     - |         - |
|      NegateWithString |  1500 | 63.3428 ns | 1.2574 ns | 2.0304 ns | 63.7585 ns | 0.0153 |     - |     - |      64 B |
```

Conclusion - Just...don't parse strings to negate numbers when you already have the value as an `int`.

## `QueryStrategies`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                                                     Method |      Mean |     Error |    StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------------------------------------------------------- |----------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|
|                     GetValuesWithForEachAndTwoIfStatements |  9.525 ms | 0.1885 ms | 0.2316 ms |  1.42 |    0.08 | 265.6250 | 234.3750 | 234.3750 |     16 MB |
|                      GetValuesWithForEachAndOneIfStatement | 10.270 ms | 0.2050 ms | 0.2013 ms |  1.54 |    0.08 | 281.2500 | 250.0000 | 250.0000 |     16 MB |
| GetValuesWithForEachAndOneIfStatementWithBooleanCheckFirst |  9.854 ms | 0.1637 ms | 0.1367 ms |  1.47 |    0.08 | 281.2500 | 250.0000 | 250.0000 |     16 MB |
|     GetValuesWithForAndOneIfStatementWithBooleanCheckFirst |  6.694 ms | 0.1323 ms | 0.2905 ms |  1.00 |    0.00 | 234.3750 | 203.1250 | 203.1250 |     16 MB |
```

Conclusion - Not much. I'm not sure why I even wrote this test in the first place. I guess `GetValuesWithForAndOneIfStatementWithBooleanCheckFirst()` is the "best" way to do ... whatever it is this query is supposed to do :P.

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

## `ServiceControllerTests`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|        Method |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|       GetData | 3,154.7 ns | 57.07 ns | 112.65 ns | 3,128.2 ns | 10.81 |    1.27 | 0.1602 |     - |     - |     671 B |
| BetterGetData |   227.3 ns | 23.59 ns |  69.57 ns |   186.0 ns |  1.00 |    0.00 | 0.0572 |     - |     - |     240 B |
```

Conclusion - Just use `Guid.TryParse()`. The code I found, I quickly removed.

## `StringOperations`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                        Method |  DataSize |           Mean |         Error |         StdDev |         Median |    Gen 0 |    Gen 1 |    Gen 2 |   Allocated |
|------------------------------ |---------- |---------------:|--------------:|---------------:|---------------:|---------:|---------:|---------:|------------:|
|              ReplaceWithMatch |    100000 |     127.229 us |     2.1016 us |      1.9658 us |     126.970 us |  62.2559 |  62.2559 |  62.2559 |    197642 B |
|            ReplaceWithNoMatch |    100000 |      73.501 us |     1.3959 us |      2.2141 us |      72.743 us |        - |        - |        - |           - |
|   ContainsAndReplaceWithMatch |    100000 |     124.462 us |     2.4757 us |      2.6490 us |     123.088 us |  62.2559 |  62.2559 |  62.2559 |    197642 B |
| ContainsAndReplaceWithNoMatch |    100000 |       5.428 us |     0.0821 us |      0.0685 us |       5.413 us |        - |        - |        - |           - |

|              ReplaceWithMatch |   1000000 |   1,713.108 us |    33.9153 us |     40.3738 us |   1,716.266 us | 281.2500 | 281.2500 | 281.2500 |   1976827 B |
|            ReplaceWithNoMatch |   1000000 |     726.649 us |    14.0113 us |     14.9920 us |     721.296 us |        - |        - |        - |           - |
|   ContainsAndReplaceWithMatch |   1000000 |   1,742.666 us |    33.3783 us |     31.2221 us |   1,751.157 us | 281.2500 | 281.2500 | 281.2500 |   1976827 B |
| ContainsAndReplaceWithNoMatch |   1000000 |      54.506 us |     0.8572 us |      0.7158 us |      54.440 us |        - |        - |        - |           - |

|              ReplaceWithMatch |  10000000 |  17,688.318 us |   542.8703 us |  1,600.6654 us |  18,410.989 us | 125.0000 | 125.0000 | 125.0000 |  19765884 B |
|            ReplaceWithNoMatch |  10000000 |   7,396.635 us |   147.4766 us |    137.9497 us |   7,361.126 us |        - |        - |        - |           - |
|   ContainsAndReplaceWithMatch |  10000000 |  19,438.944 us | 1,069.8380 us |  2,982.2806 us |  19,078.938 us | 125.0000 | 125.0000 | 125.0000 |  19765884 B |
| ContainsAndReplaceWithNoMatch |  10000000 |   1,755.135 us |    38.8317 us |    114.4962 us |   1,707.325 us |        - |        - |        - |           - |

|              ReplaceWithMatch | 100000000 | 268,758.871 us | 5,759.9171 us | 16,892.8399 us | 265,907.150 us |        - |        - |        - | 206045656 B |
|            ReplaceWithNoMatch | 100000000 |  71,066.351 us | 1,389.0588 us |  1,756.7146 us |  70,890.186 us |        - |        - |        - |           - |
|   ContainsAndReplaceWithMatch | 100000000 | 186,730.890 us | 3,434.1530 us |  5,033.7369 us | 185,002.233 us |        - |        - |        - | 206045624 B |
| ContainsAndReplaceWithNoMatch | 100000000 |  12,901.955 us |    69.0338 us |     64.5743 us |  12,893.541 us |        - |        - |        - |           - |
```

Conclusion - Calling `Contains()` before you call `Replace()` is ambiguous if it's faster or not.

## `SummationApproaches`

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT


|                   Method |        holder |         Mean |        Error |       StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |-------------- |-------------:|-------------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
| AddUpUsingCountExtension |    Count = 50 |    281.01 ns |     5.277 ns |     5.183 ns |  7.00 |    0.19 |      - |     - |     - |         - |
|       AddUpUsingProperty |    Count = 50 |     40.20 ns |     0.794 ns |     0.742 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            AddUpUsingSum |    Count = 50 |    372.95 ns |     6.569 ns |    10.032 ns |  9.30 |    0.37 | 0.0095 |     - |     - |      40 B |
|                          |               |              |              |              |       |         |        |       |       |           |
| AddUpUsingCountExtension |   Count = 100 |    755.92 ns |    15.209 ns |    27.035 ns |  8.42 |    0.49 |      - |     - |     - |         - |
|       AddUpUsingProperty |   Count = 100 |     90.45 ns |     1.842 ns |     3.679 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            AddUpUsingSum |   Count = 100 |    699.76 ns |    12.633 ns |    15.514 ns |  7.81 |    0.37 | 0.0095 |     - |     - |      40 B |
|                          |               |              |              |              |       |         |        |       |       |           |
| AddUpUsingCountExtension |   Count = 500 |  3,905.81 ns |   102.903 ns |   288.551 ns |  8.43 |    1.31 |      - |     - |     - |         - |
|       AddUpUsingProperty |   Count = 500 |    425.10 ns |     7.456 ns |     6.610 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            AddUpUsingSum |   Count = 500 |  4,615.15 ns |    50.327 ns |    47.076 ns | 10.87 |    0.24 | 0.0076 |     - |     - |      40 B |
|                          |               |              |              |              |       |         |        |       |       |           |
| AddUpUsingCountExtension |  Count = 1000 |  5,426.87 ns |    97.996 ns |   149.650 ns |  9.19 |    0.42 |      - |     - |     - |         - |
|       AddUpUsingProperty |  Count = 1000 |    591.79 ns |    11.467 ns |    13.651 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            AddUpUsingSum |  Count = 1000 |  6,325.12 ns |    96.580 ns |    99.180 ns | 10.64 |    0.25 | 0.0076 |     - |     - |      40 B |
|                          |               |              |              |              |       |         |        |       |       |           |
| AddUpUsingCountExtension |  Count = 5000 | 39,817.34 ns |   792.298 ns |   912.411 ns |  9.64 |    0.38 |      - |     - |     - |         - |
|       AddUpUsingProperty |  Count = 5000 |  4,129.38 ns |    81.423 ns |   108.697 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            AddUpUsingSum |  Count = 5000 | 44,835.02 ns |   860.023 ns | 1,087.654 ns | 10.87 |    0.39 |      - |     - |     - |      40 B |
|                          |               |              |              |              |       |         |        |       |       |           |
| AddUpUsingCountExtension | Count = 10000 | 53,232.41 ns |   829.423 ns |   775.843 ns |  8.74 |    0.29 |      - |     - |     - |         - |
|       AddUpUsingProperty | Count = 10000 |  6,075.35 ns |   119.751 ns |   155.710 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            AddUpUsingSum | Count = 10000 | 65,168.32 ns | 1,290.457 ns | 1,677.959 ns | 10.73 |    0.41 |      - |     - |     - |      40 B |
```

Conclusion - Don't use `Sum()` in high-perf scenarios. Just do a `for` loop and manually add up the values, and use `.Count`, **not** the `Count()` extension method.