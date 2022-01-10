using NUnit.Framework;
using static BenchmarkInvestigations.Core.SummationApproaches;

namespace BenchmarkInvestigations.Core.Tests;

public static class SummationApproachesTests
{
	[TestCaseSource(nameof(SummationApproachesTests.ValueGenerator))]
	public static void AddUp(Holder holder)
	{
		var extensionResult = new SummationApproaches().AddUpUsingCountExtension(holder);
		var propertyResult = new SummationApproaches().AddUpUsingProperty(holder);
		var sumResult = new SummationApproaches().AddUpUsingSum(holder);

		Assert.That(extensionResult, Is.EqualTo(propertyResult));
		Assert.That(extensionResult, Is.EqualTo(sumResult));
	}

	public static IEnumerable<Holder> ValueGenerator()
	{
		foreach (var value in new SummationApproaches().ValueGenerator())
		{
			yield return value;
		}
	}
}