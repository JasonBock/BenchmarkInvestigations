using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class DynamicPropertyUsageTests
{
	[Test]
	public static void CallApproaches()
	{
		var usage = new DynamicPropertyUsage();
		var dynamicResult = usage.CallDynamic();
		var directResult = usage.CallDirect();
		Assert.That(dynamicResult, Is.EqualTo(directResult));
	}
}