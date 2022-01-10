using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class NegatingNumbersTests
{
	[TestCaseSource(nameof(NegatingNumbersTests.GetValues))]
	public static void NegateWithNegation(int value) =>
		Assert.That(new NegatingNumbers().NegateWithNegation(value), Is.EqualTo(value * -1));

	[TestCaseSource(nameof(NegatingNumbersTests.GetValues))]
	public static void NegateWithNegativeOne(int value) =>
		Assert.That(new NegatingNumbers().NegateWithNegativeOne(value), Is.EqualTo(value * -1));

	[TestCaseSource(nameof(NegatingNumbersTests.GetValues))]
	public static void NegateWithString(int value) =>
		Assert.That(new NegatingNumbers().NegateWithString(value), Is.EqualTo(value * -1));

	public static IEnumerable<int> GetValues()
	{
		foreach (var value in new NegatingNumbers().GetValues())
		{
			yield return value;
		}
	}
}