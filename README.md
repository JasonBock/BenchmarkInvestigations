# BenchmarkInvestigations

A random collection of performance tests I've done using [Benchmark.NET](https://benchmarkdotnet.org/). To be **very** clear, please, do **not** take these tests and their results and make incorrect conclusions. Meaning, just because my tests show that technique `A` is better than `B`, it doesn't mean that is a global truism.

Following are brief descriptions of each set of tests.

## `ArgumentNullCheckOverhead`

This is a test to see what happens when a null check is added for a parameter to a method.

## `DynamicInvocations`

This is a test to see how much cost is involved in using `dynamic` to call a method.

## `DynamicPropertyUsage`

This is a test to see the cost in using `dynamic` for property usage.

## `OverflowingIntegers`

This is a test to see what `checked` does to performance.