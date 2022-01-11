# Results

Following is the test suite name and the results from that test, in alphabetical order. 

## `ArgumentNullCheckOverload`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                          Method |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|-------------------------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|
|                 PassToNullCheck | 4.069 ns | 0.1428 ns | 0.2048 ns |  1.00 |    0.00 | 0.0057 |      24 B |
| PassToNullCheckUsingThrowIfNull | 3.259 ns | 0.1246 ns | 0.1166 ns |  0.81 |    0.06 | 0.0057 |      24 B |
|            PassWithoutNullCheck | 3.295 ns | 0.0746 ns | 0.0698 ns |  0.82 |    0.05 | 0.0057 |      24 B |
```

Conclusion - Interesting that using `ArgumentNullCheck.ThrowIfNull()` is slightly faster than doing the null check yourself...it's the same as not doing a null check. I wouldn't read too much into this though.

## `AttributeLookup`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                                       Method | Categories |        Mean |     Error |      StdDev |      Median | Ratio | RatioSD |  Gen 0 | Allocated |
|--------------------------------------------- |----------- |------------:|----------:|------------:|------------:|------:|--------:|-------:|----------:|
|           FindMethodCountWith5UsingIsDefined |          5 |  1,941.0 ns |  37.76 ns |    40.40 ns |  1,957.8 ns |  9.16 |    0.23 | 0.0610 |     256 B |
|  FindMethodCountWith5UsingGetCustomAttribute |          5 |  4,619.1 ns |  47.15 ns |    44.11 ns |  4,632.2 ns | 21.77 |    0.28 | 0.2594 |   1,088 B |
|       FindMethodCountWith5UsingWellKnownName |          5 |    212.2 ns |   2.26 ns |     2.12 ns |    212.3 ns |  1.00 |    0.00 | 0.0610 |     256 B |
|                                              |            |             |           |             |             |       |         |        |           |
|          FindMethodCountWith10UsingIsDefined |         10 |  2,624.5 ns |  42.55 ns |    39.80 ns |  2,630.6 ns | 10.28 |    0.17 | 0.0801 |     336 B |
| FindMethodCountWith10UsingGetCustomAttribute |         10 |  6,639.1 ns | 112.67 ns |   105.39 ns |  6,640.4 ns | 26.00 |    0.61 | 0.3586 |   1,528 B |
|      FindMethodCountWith10UsingWellKnownName |         10 |    255.4 ns |   3.56 ns |     3.33 ns |    255.5 ns |  1.00 |    0.00 | 0.0801 |     336 B |
|                                              |            |             |           |             |             |       |         |        |           |
|          FindMethodCountWith20UsingIsDefined |         20 |  3,940.9 ns |  75.62 ns |    90.02 ns |  3,934.0 ns |  8.81 |    0.18 | 0.1144 |     496 B |
| FindMethodCountWith20UsingGetCustomAttribute |         20 | 10,890.3 ns | 128.11 ns |   119.84 ns | 10,846.7 ns | 24.41 |    0.47 | 0.5646 |   2,408 B |
|      FindMethodCountWith20UsingWellKnownName |         20 |    446.3 ns |   5.12 ns |     4.79 ns |    445.6 ns |  1.00 |    0.00 | 0.1183 |     496 B |
|                                              |            |             |           |             |             |       |         |        |           |
|          FindMethodCountWith50UsingIsDefined |         50 |  7,340.6 ns | 106.26 ns |    99.40 ns |  7,360.3 ns |  9.00 |    0.21 | 0.2289 |     976 B |
| FindMethodCountWith50UsingGetCustomAttribute |         50 | 24,979.0 ns | 481.26 ns | 1,015.15 ns | 24,605.9 ns | 31.98 |    1.05 | 1.0986 |   5,049 B |
|      FindMethodCountWith50UsingWellKnownName |         50 |    815.6 ns |  13.16 ns |    12.31 ns |    813.3 ns |  1.00 |    0.00 | 0.2327 |     976 B |
```

Conclusion - It is quicker and uses less memory to look up a method if it uses a well-known name. However, the advantage an attribute has is that it provides a bit of naming flexibility.

## `ComparingCases`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                         Method |       Level |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated |
|------------------------------- |------------ |----------:|----------:|----------:|------:|--------:|----------:|
|       IsEnabledUsingDictionary |       Trace | 6.2370 ns | 0.1465 ns | 0.1298 ns |  8.81 |    0.71 |         - |
|           IsEnabledUsingSwitch |       Trace | 0.7132 ns | 0.0416 ns | 0.0462 ns |  1.00 |    0.00 |         - |
| IsEnabledUsingSwitchExpression |       Trace | 0.7825 ns | 0.0323 ns | 0.0286 ns |  1.10 |    0.08 |         - |
|               IsEnabledUsingIf |       Trace | 0.5065 ns | 0.0357 ns | 0.0334 ns |  0.72 |    0.06 |         - |
|                                |             |           |           |           |       |         |           |
|       IsEnabledUsingDictionary |       Debug | 5.6642 ns | 0.0385 ns | 0.0360 ns |  7.37 |    0.25 |         - |
|           IsEnabledUsingSwitch |       Debug | 0.7696 ns | 0.0321 ns | 0.0250 ns |  1.00 |    0.00 |         - |
| IsEnabledUsingSwitchExpression |       Debug | 0.8008 ns | 0.0404 ns | 0.0358 ns |  1.04 |    0.08 |         - |
|               IsEnabledUsingIf |       Debug | 0.4888 ns | 0.0269 ns | 0.0238 ns |  0.64 |    0.04 |         - |
|                                |             |           |           |           |       |         |           |
|       IsEnabledUsingDictionary |     Warning | 5.6109 ns | 0.0615 ns | 0.0545 ns |  5.50 |    0.24 |         - |
|           IsEnabledUsingSwitch |     Warning | 1.0210 ns | 0.0426 ns | 0.0377 ns |  1.00 |    0.00 |         - |
| IsEnabledUsingSwitchExpression |     Warning | 1.0930 ns | 0.0319 ns | 0.0298 ns |  1.07 |    0.05 |         - |
|               IsEnabledUsingIf |     Warning | 0.4553 ns | 0.0351 ns | 0.0480 ns |  0.47 |    0.06 |         - |
|                                |             |           |           |           |       |         |           |
|       IsEnabledUsingDictionary |       Error | 5.5837 ns | 0.0846 ns | 0.0750 ns |  7.26 |    0.41 |         - |
|           IsEnabledUsingSwitch |       Error | 0.7719 ns | 0.0380 ns | 0.0356 ns |  1.00 |    0.00 |         - |
| IsEnabledUsingSwitchExpression |       Error | 0.7646 ns | 0.0269 ns | 0.0225 ns |  1.00 |    0.06 |         - |
|               IsEnabledUsingIf |       Error | 0.7829 ns | 0.0273 ns | 0.0242 ns |  1.02 |    0.06 |         - |
|                                |             |           |           |           |       |         |           |
|       IsEnabledUsingDictionary | Information | 5.9126 ns | 0.1389 ns | 0.1855 ns |  7.21 |    0.42 |         - |
|           IsEnabledUsingSwitch | Information | 0.8205 ns | 0.0421 ns | 0.0451 ns |  1.00 |    0.00 |         - |
| IsEnabledUsingSwitchExpression | Information | 0.7588 ns | 0.0370 ns | 0.0346 ns |  0.93 |    0.06 |         - |
|               IsEnabledUsingIf | Information | 1.3675 ns | 0.0349 ns | 0.0309 ns |  1.67 |    0.11 |         - |
|                                |             |           |           |           |       |         |           |
|       IsEnabledUsingDictionary |    Critical | 6.2725 ns | 0.1346 ns | 0.1259 ns |  8.52 |    0.26 |         - |
|           IsEnabledUsingSwitch |    Critical | 0.7371 ns | 0.0281 ns | 0.0263 ns |  1.00 |    0.00 |         - |
| IsEnabledUsingSwitchExpression |    Critical | 0.7932 ns | 0.0300 ns | 0.0251 ns |  1.08 |    0.04 |         - |
|               IsEnabledUsingIf |    Critical | 1.5953 ns | 0.0581 ns | 0.0669 ns |  2.16 |    0.12 |         - |
```

Conclusion - Don't use a `Dictionary<,>` to mimic a `switch` or `if`. And a `switch` (expression or "classic") does better than the `if` approach.

## `DictionaryRefValues`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|               Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated |
|--------------------- |---------:|----------:|----------:|------:|--------:|----------:|
| UpdateValueUsingCopy | 8.358 us | 0.1614 us | 0.2315 us |  1.00 |    0.00 |         - |
|  UpdateValueUsingRef | 4.311 us | 0.0859 us | 0.0989 us |  0.52 |    0.02 |         - |
```

Conclusion - Using `CollectionsMarshal.GetValueRefOrNullRef()` helps in terms of performance.

## `DynamicInvocations`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                   Method |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|----------:|
| ReturnValueViaDirectCall |  0.0051 ns | 0.0083 ns | 0.0078 ns |  0.0000 ns |     ? |       ? |      - |         - |
|    ReturnValueViaDynamic | 11.1695 ns | 0.2024 ns | 0.1794 ns | 11.1482 ns |     ? |       ? | 0.0115 |      48 B |
```

Conclusion - Don't use `dynamic` unless absolutely necessary.

## `DynamicPropertyUsage`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|      Method |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|------------ |-----------:|----------:|----------:|------:|--------:|-------:|----------:|
| CallDynamic | 14.3591 ns | 0.1602 ns | 0.1420 ns |     ? |       ? | 0.0115 |      48 B |
|  CallDirect |  0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |      - |         - |
```

Conclusion - Don't use `dynamic` unless absolutely necessary.

## `ExtensionMethodApproaches`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                         Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated |
|------------------------------- |---------:|----------:|----------:|------:|--------:|----------:|
| GetAgeWithExtensionDeconstruct | 2.536 ns | 0.0692 ns | 0.0648 ns |  0.90 |    0.04 |         - |
|  GetAgeWithInstanceDeconstruct | 2.833 ns | 0.0757 ns | 0.0708 ns |  1.00 |    0.00 |         - |
```

Conclusion - I've run this a few times, and which one is "better" will change, though the difference is very small. It doesn't seem to mattter much which approach you take. I was debating for my [AutoDeconstruct](https://github.com/JasonBock/autodeconstruct) to potentially try to make the generated `Deconstruct` method an instance method on a partial type, but that flexibility isn't needed.

## `FibonacciApproaches`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                  Method | start |              Mean |            Error |           StdDev |        Ratio |   RatioSD |  Gen 0 | Allocated |
|------------------------ |------ |------------------:|-----------------:|-----------------:|-------------:|----------:|-------:|----------:|
|      CalculateUsingList |     1 |          12.16 ns |         0.255 ns |         0.250 ns |         0.97 |      0.03 |      - |         - |
| CalculateUsingRecursive |     1 |          12.71 ns |         0.198 ns |         0.185 ns |         1.01 |      0.02 |      - |         - |
|    CalculateUsingLocals |     1 |          12.57 ns |         0.240 ns |         0.224 ns |         1.00 |      0.00 |      - |         - |
|                         |       |                   |                  |                  |              |           |        |           |
|      CalculateUsingList |     3 |          75.28 ns |         1.164 ns |         1.088 ns |         1.79 |      0.03 | 0.0286 |     120 B |
| CalculateUsingRecursive |     3 |         112.20 ns |         2.274 ns |         5.226 ns |         2.66 |      0.18 |      - |         - |
|    CalculateUsingLocals |     3 |          42.12 ns |         0.579 ns |         0.541 ns |         1.00 |      0.00 |      - |         - |
|                         |       |                   |                  |                  |              |           |        |           |
|      CalculateUsingList |     6 |         138.19 ns |         2.243 ns |         1.873 ns |         2.17 |      0.04 | 0.0648 |     272 B |
| CalculateUsingRecursive |     6 |         598.94 ns |         7.728 ns |         7.229 ns |         9.39 |      0.16 |      - |         - |
|    CalculateUsingLocals |     6 |          63.81 ns |         0.863 ns |         0.807 ns |         1.00 |      0.00 |      - |         - |
|                         |       |                   |                  |                  |              |           |        |           |
|      CalculateUsingList |    12 |         241.69 ns |         4.583 ns |         5.094 ns |         2.18 |      0.05 | 0.1316 |     552 B |
| CalculateUsingRecursive |    12 |      10,811.92 ns |       211.976 ns |       198.283 ns |        97.47 |      3.20 |      - |         - |
|    CalculateUsingLocals |    12 |         111.08 ns |         2.246 ns |         2.307 ns |         1.00 |      0.00 |      - |         - |
|                         |       |                   |                  |                  |              |           |        |           |
|      CalculateUsingList |    20 |         378.38 ns |         6.785 ns |         6.347 ns |         2.04 |      0.06 | 0.2599 |   1,088 B |
| CalculateUsingRecursive |    20 |     519,669.51 ns |    10,205.211 ns |    10,480.000 ns |     2,796.87 |     77.63 |      - |       1 B |
|    CalculateUsingLocals |    20 |         185.58 ns |         3.728 ns |         4.438 ns |         1.00 |      0.00 |      - |         - |
|                         |       |                   |                  |                  |              |           |        |           |
|      CalculateUsingList |    35 |         650.24 ns |         9.340 ns |         9.591 ns |         2.10 |      0.05 | 0.5102 |   2,136 B |
| CalculateUsingRecursive |    35 | 716,410,333.33 ns | 8,265,608.125 ns | 7,731,654.969 ns | 2,312,269.10 | 47,865.98 |      - |   4,040 B |
|    CalculateUsingLocals |    35 |         309.92 ns |         5.951 ns |         5.566 ns |         1.00 |      0.00 |      - |         - |
```

Conclusion - Using local variables is the quickest and allocates the least amount of memory.

## `FormattingGuids`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                Method |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|
| CreateViaFormatString | 24.59 ns | 0.412 ns | 0.365 ns |  1.00 |    0.00 | 0.0210 |      88 B |
|      CreateViaReplace | 97.10 ns | 1.629 ns | 1.444 ns |  3.95 |    0.06 | 0.0440 |     184 B |
```

Conclusion - Use what's built-in to .NET.

## `HashCodeTechniques`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                              Method |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------ |----------:|---------:|---------:|------:|--------:|-------:|----------:|
|      GetHashCodeFromHashCodeCombine |  23.11 ns | 0.275 ns | 0.257 ns |  1.00 |    0.00 |      - |         - |
|        GetHashCodeFromTupleHashCode |  35.98 ns | 0.750 ns | 0.770 ns |  1.56 |    0.05 |      - |         - |
|                  GetHashCodeFromXOR |  17.80 ns | 0.381 ns | 0.424 ns |  0.77 |    0.02 |      - |         - |
|     GetHashCodeFromPrimeNumberUsage | 485.36 ns | 8.995 ns | 8.414 ns | 21.01 |    0.49 | 0.0153 |      64 B |
| GetHashCodeFromRecordImplementation |  22.96 ns | 0.241 ns | 0.225 ns |  0.99 |    0.02 |      - |         - |
```

Conclusion - This was from [an article](https://medium.com/rocket-mortgage-technology-blog/whats-in-a-hash-code-cf21c6f0b57c) I wrote on hash codes. I couldn't find the source code for the benchmark tests I wrote, so I redid them here. As you can see, using `HashCode.Combine()` has good performance and is a one-liner, so it's simple to use.

## `HashSetEnsureCapacity`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                         Method |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|
| GetCountNotUsingEnsureCapacity | 196.0 ns | 3.94 ns | 4.21 ns |  1.00 |    0.00 | 0.1817 |     760 B |
|    GetCountUsingEnsureCapacity | 146.6 ns | 1.18 ns | 1.10 ns |  0.75 |    0.02 | 0.1070 |     448 B |
|        GetCountSettingCapacity | 112.4 ns | 1.30 ns | 1.16 ns |  0.57 |    0.01 | 0.0802 |     336 B |
```

Conclusion - Set the capacity right away, but if you don't know the count right away, use `EnsureCapacity()` when you can.

## `IteratingAnonymousAndTupleTypes`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                    Method |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|-------------------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|
| IterateOverAnonymousTypes | 268.1 ns | 4.99 ns | 4.67 ns |  1.03 |    0.02 | 0.2427 |   1,016 B |
|     IterateOverTupleTypes | 260.7 ns | 3.98 ns | 3.72 ns |  1.00 |    0.00 | 0.2255 |     944 B |
```

Conclusion - Tuple types might be **slightly** better. I need to do more investigations in this area.

## `ListsAndCapacity`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|-------:|----------:|
|       CreateWithoutCapacity |     5 |     32.13 ns |   0.632 ns |   0.702 ns |  2.14 |    0.09 |  0.0306 |      - |     128 B |
| CreateWith25PercentCapacity |     5 |     51.00 ns |   1.027 ns |   1.183 ns |  3.40 |    0.10 |  0.0459 |      - |     192 B |
| CreateWith50PercentCapacity |     5 |     39.08 ns |   0.790 ns |   0.910 ns |  2.61 |    0.10 |  0.0382 |      - |     160 B |
|          CreateWithCapacity |     5 |     14.92 ns |   0.327 ns |   0.469 ns |  1.00 |    0.00 |  0.0191 |      - |      80 B |
|                             |       |              |            |            |       |         |         |        |           |
|       CreateWithoutCapacity |    10 |     53.64 ns |   0.838 ns |   0.784 ns |  2.21 |    0.06 |  0.0516 |      - |     216 B |
| CreateWith25PercentCapacity |    10 |     60.65 ns |   1.245 ns |   1.574 ns |  2.51 |    0.08 |  0.0592 |      - |     248 B |
| CreateWith50PercentCapacity |    10 |     35.97 ns |   0.704 ns |   0.723 ns |  1.49 |    0.04 |  0.0344 |      - |     144 B |
|          CreateWithCapacity |    10 |     24.26 ns |   0.482 ns |   0.451 ns |  1.00 |    0.00 |  0.0229 |      - |      96 B |
|                             |       |              |            |            |       |         |         |        |           |
|       CreateWithoutCapacity |    50 |    158.55 ns |   2.146 ns |   1.903 ns |  1.54 |    0.07 |  0.1547 |      - |     648 B |
| CreateWith25PercentCapacity |    50 |    148.24 ns |   2.867 ns |   2.394 ns |  1.43 |    0.05 |  0.2027 |      - |     848 B |
| CreateWith50PercentCapacity |    50 |    123.85 ns |   2.390 ns |   2.454 ns |  1.22 |    0.05 |  0.0918 |      - |     384 B |
|          CreateWithCapacity |    50 |     99.48 ns |   2.008 ns |   3.722 ns |  1.00 |    0.00 |  0.0612 |      - |     256 B |
|                             |       |              |            |            |       |         |         |        |           |
|       CreateWithoutCapacity |   100 |    264.37 ns |   4.614 ns |   4.316 ns |  1.35 |    0.04 |  0.2828 |      - |   1,184 B |
| CreateWith25PercentCapacity |   100 |    218.38 ns |   4.357 ns |   4.662 ns |  1.12 |    0.04 |  0.1931 |      - |     808 B |
| CreateWith50PercentCapacity |   100 |    206.97 ns |   3.982 ns |   3.724 ns |  1.06 |    0.04 |  0.1624 |      - |     680 B |
|          CreateWithCapacity |   100 |    195.00 ns |   3.868 ns |   4.604 ns |  1.00 |    0.00 |  0.1090 |      - |     456 B |
|                             |       |              |            |            |       |         |         |        |           |
|       CreateWithoutCapacity |   500 |  1,147.34 ns |  22.764 ns |  22.358 ns |  1.11 |    0.03 |  1.0281 |      - |   4,304 B |
| CreateWith25PercentCapacity |   500 |  1,090.24 ns |  21.476 ns |  22.054 ns |  1.05 |    0.03 |  0.8621 |      - |   3,608 B |
| CreateWith50PercentCapacity |   500 |  1,074.77 ns |  20.871 ns |  29.258 ns |  1.04 |    0.02 |  0.7362 |      - |   3,080 B |
|          CreateWithCapacity |   500 |  1,035.84 ns |  19.933 ns |  19.577 ns |  1.00 |    0.00 |  0.4902 |      - |   2,056 B |
|                             |       |              |            |            |       |         |         |        |           |
|       CreateWithoutCapacity |  1000 |  2,330.82 ns |  30.426 ns |  28.460 ns |  1.09 |    0.02 |  2.0103 |      - |   8,424 B |
| CreateWith25PercentCapacity |  1000 |  2,296.93 ns |  45.587 ns |  60.857 ns |  1.07 |    0.03 |  1.6975 |      - |   7,104 B |
| CreateWith50PercentCapacity |  1000 |  2,219.11 ns |  30.380 ns |  25.369 ns |  1.04 |    0.02 |  1.4534 |      - |   6,080 B |
|          CreateWithCapacity |  1000 |  2,131.68 ns |  29.825 ns |  26.439 ns |  1.00 |    0.00 |  0.9689 |      - |   4,056 B |
|                             |       |              |            |            |       |         |         |        |           |
|       CreateWithoutCapacity |  5000 | 13,192.44 ns | 190.556 ns | 159.123 ns |  1.21 |    0.03 | 15.6708 | 0.3510 |  65,840 B |
| CreateWith25PercentCapacity |  5000 | 11,640.89 ns |  81.732 ns |  68.250 ns |  1.06 |    0.02 |  8.3618 |      - |  35,104 B |
| CreateWith50PercentCapacity |  5000 | 11,341.75 ns | 197.699 ns | 184.928 ns |  1.03 |    0.03 |  7.1564 |      - |  30,080 B |
|          CreateWithCapacity |  5000 | 10,970.10 ns | 215.065 ns | 211.223 ns |  1.00 |    0.00 |  4.7760 |      - |  20,056 B |
```

Conclusion - If you know what the capacity is, use that when the list is constructed. Even a decent guess is better than nothing.

## `NegatingNumbers`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                Method | value |       Mean |     Error |    StdDev |     Median |  Gen 0 | Allocated |
|---------------------- |------ |-----------:|----------:|----------:|-----------:|-------:|----------:|
|    NegateWithNegation | -1500 |  0.0309 ns | 0.0228 ns | 0.0288 ns |  0.0237 ns |      - |         - |
| NegateWithNegativeOne | -1500 |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |      - |         - |
|      NegateWithString | -1500 | 35.4101 ns | 0.5009 ns | 0.4686 ns | 35.3010 ns | 0.0153 |      64 B |
|    NegateWithNegation |  1500 |  0.0000 ns | 0.0000 ns | 0.0000 ns |  0.0000 ns |      - |         - |
| NegateWithNegativeOne |  1500 |  0.0030 ns | 0.0114 ns | 0.0112 ns |  0.0000 ns |      - |         - |
|      NegateWithString |  1500 | 31.4379 ns | 0.3468 ns | 0.3244 ns | 31.5060 ns | 0.0153 |      64 B |
```

Conclusion - Just...don't parse strings to negate numbers when you already have the value as an `int`.

## `QueryStrategies`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                                                     Method |     Mean |     Error |    StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------------------------------------------------------- |---------:|----------:|----------:|------:|--------:|---------:|---------:|---------:|----------:|
|                     GetValuesWithForEachAndTwoIfStatements | 5.719 ms | 0.1132 ms | 0.3117 ms |  0.99 |    0.08 | 250.0000 | 218.7500 | 218.7500 |     16 MB |
|                      GetValuesWithForEachAndOneIfStatement | 5.827 ms | 0.1416 ms | 0.4154 ms |  1.01 |    0.10 | 242.1875 | 210.9375 | 210.9375 |     16 MB |
| GetValuesWithForEachAndOneIfStatementWithBooleanCheckFirst | 5.783 ms | 0.1261 ms | 0.3699 ms |  0.99 |    0.08 | 242.1875 | 210.9375 | 210.9375 |     16 MB |
|     GetValuesWithForAndOneIfStatementWithBooleanCheckFirst | 5.828 ms | 0.1160 ms | 0.3234 ms |  1.00 |    0.00 | 234.3750 | 203.1250 | 203.1250 |     16 MB |
```

Conclusion - Not much. I'm not sure why I even wrote this test in the first place. I guess `GetValuesWithForAndOneIfStatementWithBooleanCheckFirst()` is the "best" way to do ... whatever it is this query is supposed to do :P.

## `RunOverflowingCode`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                Method |     i |     j |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated |
|---------------------- |------ |------ |----------:|----------:|----------:|----------:|------:|--------:|----------:|
| MultiplyWithNoChecked |     3 |     7 | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |     ? |       ? |         - |
|   MultiplyWithChecked |     3 |     7 | 0.0171 ns | 0.0206 ns | 0.0192 ns | 0.0122 ns |     ? |       ? |         - |
|                       |       |       |           |           |           |           |       |         |           |
| MultiplyWithNoChecked |    12 |    44 | 0.0019 ns | 0.0047 ns | 0.0046 ns | 0.0000 ns |     ? |       ? |         - |
|   MultiplyWithChecked |    12 |    44 | 0.2220 ns | 0.0166 ns | 0.0155 ns | 0.2245 ns |     ? |       ? |         - |
|                       |       |       |           |           |           |           |       |         |           |
| MultiplyWithNoChecked |   243 | 48319 | 0.0042 ns | 0.0087 ns | 0.0119 ns | 0.0000 ns |     ? |       ? |         - |
|   MultiplyWithChecked |   243 | 48319 | 0.2611 ns | 0.0253 ns | 0.0237 ns | 0.2745 ns |     ? |       ? |         - |
|                       |       |       |           |           |           |           |       |         |           |
| MultiplyWithNoChecked |  4315 |  9199 | 0.0056 ns | 0.0095 ns | 0.0080 ns | 0.0000 ns |     ? |       ? |         - |
|   MultiplyWithChecked |  4315 |  9199 | 0.0001 ns | 0.0006 ns | 0.0005 ns | 0.0000 ns |     ? |       ? |         - |
|                       |       |       |           |           |           |           |       |         |           |
| MultiplyWithNoChecked | 10000 | 10000 | 0.0028 ns | 0.0045 ns | 0.0042 ns | 0.0000 ns |     ? |       ? |         - |
|   MultiplyWithChecked | 10000 | 10000 | 0.2653 ns | 0.0080 ns | 0.0063 ns | 0.2643 ns |     ? |       ? |         - |
```

Conclusion - Putting `checked` in your code may be slower, but it's so fast it probably won't matter.

## `ServiceControllerUsage`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|             Method |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------- |------------:|---------:|---------:|------:|--------:|-------:|----------:|
|       GetDataAsync | 1,356.52 ns | 3.597 ns | 3.365 ns | 16.52 |    0.22 | 0.1698 |     712 B |
| BetterGetDataAsync |    82.14 ns | 1.252 ns | 1.110 ns |  1.00 |    0.00 | 0.0573 |     240 B |
```

Conclusion - Just use `Guid.TryParse()`. The code I found, I quickly removed.

## `SettingPropertiesInConstructor`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|           Method |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|----------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|
| CreateViaSetters | 62.54 ns | 0.756 ns | 0.707 ns |  1.01 |    0.02 | 0.0114 |      48 B |
|   CreateViaTuple | 61.93 ns | 1.244 ns | 1.222 ns |  1.00 |    0.00 | 0.0114 |      48 B |
```

Conclusion - There's no difference. Use whatever style you like.

## `StringOperations`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                        Method |  DataSize |          Mean |         Error |        StdDev |    Gen 0 |    Gen 1 |    Gen 2 |     Allocated |
|------------------------------ |---------- |--------------:|--------------:|--------------:|---------:|---------:|---------:|--------------:|
|              ReplaceWithMatch |    100000 |     20.809 us |     0.2416 us |     0.2260 us |  62.4695 |  62.4695 |  62.4695 |     200,045 B |
|            ReplaceWithNoMatch |    100000 |      4.386 us |     0.0393 us |     0.0348 us |        - |        - |        - |             - |
|   ContainsAndReplaceWithMatch |    100000 |     22.786 us |     0.2182 us |     0.2041 us |  62.4695 |  62.4695 |  62.4695 |     200,045 B |
| ContainsAndReplaceWithNoMatch |    100000 |      4.313 us |     0.0813 us |     0.0760 us |        - |        - |        - |             - |

|              ReplaceWithMatch |   1000000 |  2,196.043 us |    22.4370 us |    20.9876 us | 284.1797 | 284.1797 | 284.1797 |   2,000,113 B |
|            ReplaceWithNoMatch |   1000000 |     42.927 us |     0.8326 us |     1.1396 us |        - |        - |        - |             - |
|   ContainsAndReplaceWithMatch |   1000000 |  2,204.845 us |    22.4045 us |    20.9572 us | 284.1797 | 284.1797 | 284.1797 |   2,000,113 B |
| ContainsAndReplaceWithNoMatch |   1000000 |     43.450 us |     0.5949 us |     0.5565 us |        - |        - |        - |             - |

|              ReplaceWithMatch |  10000000 |  7,417.568 us |   337.9446 us |   996.4374 us | 265.6250 | 265.6250 | 265.6250 |  20,000,114 B |
|            ReplaceWithNoMatch |  10000000 |  1,084.370 us |    20.8054 us |    27.0528 us |        - |        - |        - |           1 B |
|   ContainsAndReplaceWithMatch |  10000000 |  7,848.238 us |   380.0616 us | 1,120.6203 us | 265.6250 | 265.6250 | 265.6250 |  20,000,114 B |
| ContainsAndReplaceWithNoMatch |  10000000 |  1,101.468 us |    20.8917 us |    25.6569 us |        - |        - |        - |           1 B |

|              ReplaceWithMatch | 100000000 | 79,597.911 us | 1,218.5486 us | 1,139.8311 us | 125.0000 | 125.0000 | 125.0000 | 200,001,531 B |
|            ReplaceWithNoMatch | 100000000 | 11,875.081 us |   231.7425 us |   247.9619 us |        - |        - |        - |           8 B |
|   ContainsAndReplaceWithMatch | 100000000 | 73,993.114 us | 1,457.8907 us | 2,591.3992 us |        - |        - |        - | 200,000,093 B |
| ContainsAndReplaceWithNoMatch | 100000000 | 11,968.341 us |   215.2022 us |   201.3003 us |        - |        - |        - |           8 B |
```

Conclusion - Calling `Contains()` before you call `Replace()` is ambiguous if it's faster or not.

## `SummationApproaches`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                   Method |        holder |         Mean |        Error |       StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------:|-------------:|-------------:|------:|--------:|-------:|----------:|
| AddUpUsingCountExtension |    Count = 50 |    234.06 ns |     3.443 ns |     3.221 ns |  6.69 |    0.21 |      - |         - |
|       AddUpUsingProperty |    Count = 50 |     34.97 ns |     0.705 ns |     0.755 ns |  1.00 |    0.00 |      - |         - |
|            AddUpUsingSum |    Count = 50 |    305.85 ns |     6.066 ns |     6.491 ns |  8.75 |    0.26 | 0.0095 |      40 B |
|                          |               |              |              |              |       |         |        |           |
| AddUpUsingCountExtension |   Count = 100 |    457.12 ns |     8.891 ns |    10.918 ns |  7.37 |    0.20 |      - |         - |
|       AddUpUsingProperty |   Count = 100 |     62.48 ns |     1.121 ns |     1.049 ns |  1.00 |    0.00 |      - |         - |
|            AddUpUsingSum |   Count = 100 |    586.57 ns |     7.811 ns |     7.306 ns |  9.39 |    0.20 | 0.0095 |      40 B |
|                          |               |              |              |              |       |         |        |           |
| AddUpUsingCountExtension |   Count = 500 |  2,233.77 ns |    44.330 ns |    56.063 ns |  7.85 |    0.26 |      - |         - |
|       AddUpUsingProperty |   Count = 500 |    284.14 ns |     4.770 ns |     4.462 ns |  1.00 |    0.00 |      - |         - |
|            AddUpUsingSum |   Count = 500 |  2,876.94 ns |    56.914 ns |    74.005 ns | 10.23 |    0.32 | 0.0076 |      40 B |
|                          |               |              |              |              |       |         |        |           |
| AddUpUsingCountExtension |  Count = 1000 |  4,382.97 ns |    85.149 ns |   124.810 ns |  8.07 |    0.28 |      - |         - |
|       AddUpUsingProperty |  Count = 1000 |    539.73 ns |     5.030 ns |     4.705 ns |  1.00 |    0.00 |      - |         - |
|            AddUpUsingSum |  Count = 1000 |  5,545.66 ns |   110.695 ns |   113.676 ns | 10.25 |    0.22 | 0.0076 |      40 B |
|                          |               |              |              |              |       |         |        |           |
| AddUpUsingCountExtension |  Count = 5000 | 21,794.23 ns |   418.888 ns |   482.393 ns |  8.34 |    0.22 |      - |         - |
|       AddUpUsingProperty |  Count = 5000 |  2,620.43 ns |    48.715 ns |    45.568 ns |  1.00 |    0.00 |      - |         - |
|            AddUpUsingSum |  Count = 5000 | 29,305.86 ns |   449.074 ns |   420.065 ns | 11.19 |    0.29 |      - |      40 B |
|                          |               |              |              |              |       |         |        |           |
| AddUpUsingCountExtension | Count = 10000 | 42,606.05 ns |   851.240 ns | 1,374.594 ns |  8.01 |    0.32 |      - |         - |
|       AddUpUsingProperty | Count = 10000 |  5,304.34 ns |   101.984 ns |   109.122 ns |  1.00 |    0.00 |      - |         - |
|            AddUpUsingSum | Count = 10000 | 58,235.28 ns | 1,162.299 ns | 1,141.533 ns | 10.98 |    0.31 |      - |      40 B |
```

Conclusion - Don't use `Sum()` in high-perf scenarios. Just do a `for` loop and manually add up the values, and use `.Count`, **not** the `Count()` extension method.

## `SyntaxNodeKindUsages`

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-1065G7 CPU 1.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated |
|---------------------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|
|  CheckKindUsingIsKind | 0.8443 ns | 0.0229 ns | 0.0203 ns | 0.8392 ns |  1.00 |    0.00 |         - |
|    CheckKindUsingKind | 1.7159 ns | 0.0180 ns | 0.0168 ns | 1.7213 ns |  2.03 |    0.06 |         - |
| CheckKindUsingRawKind | 0.0109 ns | 0.0175 ns | 0.0146 ns | 0.0053 ns |  0.01 |    0.02 |         - |
```

Conclusion - `RawKind` is the fastest, but `IsKind` is recommended.