# BenchmarkInvestigations

A random collection of performance tests I've done using [Benchmark.NET](https://benchmarkdotnet.org/). To be **very** clear, please, do **not** take these tests and their results and make incorrect conclusions. Meaning, just because my tests show that technique `A` is better than `B`, it doesn't mean that is a global truism. The `results.md` file contains results for each test, but again, take that information as it is, and don't necessarily use that data to make sweeping, production-level changes in your code.

Following are brief descriptions of each set of tests.

## `ArgumentNullCheckOverhead`

This is a test to see what happens when a null check is added for a parameter to a method.

## `ConstructionViaTuples`

This is a test to see if there's any difference in assigining property values via "traditional" setting and tuples.

## `DynamicInvocations`

This is a test to see how much cost is involved in using `dynamic` to call a method.

## `DynamicPropertyUsage`

This is a test to see the cost in using `dynamic` for property usage.

## `ListsAndCapacity`

This is a test to see what happens when the capacity is set when a `List<>` is created.

## `RunOverflowingCode`

This is a test to see what `checked` does to performance.