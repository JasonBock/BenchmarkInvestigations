# BenchmarkInvestigations

A random collection of performance tests I've done using [Benchmark.NET](https://benchmarkdotnet.org/). To be **very** clear, please, do **not** take these tests and their results and make incorrect conclusions. Meaning, just because my tests show that technique `A` is better than `B`, it doesn't mean that is a global truism. The `results.md` file contains results for each test, but again, take that information as it is, and don't necessarily use that data to make sweeping, production-level changes in your code.

Following are brief descriptions of each set of tests.

## `ArgumentNullCheckOverhead`

This is a test to see what happens when a null check is added for a parameter to a method.

## `AttributeLookup`

This is a test to compare looking up a method by either a well-known name or by the existence of an attribute.

## `ComparingCases`

This looks at using a `Dictionary<,>` over a `switch` or `if`.

## `ConstructionViaTuples`

This is a test to see if there's any difference in assigining property values via "traditional" setting and tuples.

## `DynamicInvocations`

This is a test to see how much cost is involved in using `dynamic` to call a method.

## `DynamicPropertyUsage`

This is a test to see the cost in using `dynamic` for property usage.

## `FibonacciApproaches`

This is a test to see the differences in calculating the n-th number in the Fibonacci sequence.

## `IteratingAnonymousAndTupleTypes`

This is a test to compare using anonymous and tuple types.

## `ListsAndCapacity`

This is a test to see what happens when the capacity is set when a `List<>` is created.

## `NegatingNumbers`

This is a test to compare ways to negate a number. (If one wonders why I did this, I faintly remember running into the string parsing technique at a client I was working at, and I was trying to show that **maybe** there was a faster way to do it, along with handling negative numbers correctly.)

## `QueryStrategies`

This tests different ways to order conditional statements.

## `RunOverflowingCode`

This is a test to see what `checked` does to performance.

## `ServiceControllerTests`

This tested "interesting" `Guid` parsing code I found at a client. The service and controller layers are mimicked in the test.

## `StringOperations`

This looks to see if calling `Contains()` before `Replace()` helps.

## `SummationApproaches`

This tests different ways to get the sum of all the elements in a list.