using NUnit.Framework;
using System.Numerics;

namespace BenchmarkInvestigations.Core.Tests;

public static class FibonacciApproachesTests
{
	[TestCaseSource(nameof(FibonacciApproachesTests.StartingValues))]
	public static void CalculateUsingList(BigInteger value) =>
		Assert.That(new FibonacciApproaches().CalculateUsingList(value), Is.GreaterThan(BigInteger.Zero));

	[TestCaseSource(nameof(FibonacciApproachesTests.StartingValues))]
	public static void CalculateUsingRecursive(BigInteger value) =>
		Assert.That(new FibonacciApproaches().CalculateUsingRecursive(value), Is.GreaterThan(BigInteger.Zero));

	[TestCaseSource(nameof(FibonacciApproachesTests.StartingValues))]
	public static void CalculateUsingLocals(BigInteger value) =>
		Assert.That(new FibonacciApproaches().CalculateUsingLocals(value), Is.GreaterThan(BigInteger.Zero));

	public static IEnumerable<BigInteger> StartingValues()
	{
		foreach (var value in new FibonacciApproaches().StartingValues())
		{
			yield return value;
		}
	}
}