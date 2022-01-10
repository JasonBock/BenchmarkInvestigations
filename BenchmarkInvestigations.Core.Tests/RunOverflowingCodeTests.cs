using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class RunOverflowingCodeTests
{
	[TestCaseSource(nameof(RunOverflowingCodeTests.GetValues))]
	public static void MultiplyWithNoChecked(int a, int b) =>
		Assert.That(new RunOverflowingCode().MultiplyWithNoChecked(a, b), Is.EqualTo(a * b));

	[TestCaseSource(nameof(RunOverflowingCodeTests.GetValues))]
	public static void MultiplyWithChecked(int a, int b) =>
		Assert.That(new RunOverflowingCode().MultiplyWithChecked(a, b), Is.EqualTo(a * b));

	public static IEnumerable<object[]> GetValues()
	{
		foreach (var value in new RunOverflowingCode().Values())
		{
			yield return value;
		}
	}
}