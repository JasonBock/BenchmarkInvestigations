using NUnit.Framework;
using System.Numerics;

namespace BenchmarkInvestigations.Core.Tests;

public static class FibonacciApproachesTests
{
	[TestCaseSource(nameof(FibonacciApproachesTests.StartingValues))]
	public static void Calculate(BigInteger value)
	{
		var approaches = new FibonacciApproaches();
		var listResult = approaches.CalculateUsingList(value);
		var recursiveResult = approaches.CalculateUsingRecursive(value);
		var localsResult = approaches.CalculateUsingLocals(value);

		Assert.Multiple(() =>
		{
			Assert.That(listResult, Is.GreaterThan(BigInteger.Zero));
			Assert.That(listResult, Is.EqualTo(recursiveResult));
			Assert.That(listResult, Is.EqualTo(localsResult));
		});
	}

	public static IEnumerable<BigInteger> StartingValues()
	{
		foreach (var value in new FibonacciApproaches().StartingValues())
		{
			yield return value;
		}
	}
}