using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class DynamicPropertyUsageTests
{
	[Test]
	public static void CallDynamic() =>
		Assert.That(new DynamicPropertyUsage().CallDynamic(), Is.GreaterThan(0));

	[Test]
	public static void CallDirect() =>
		Assert.That(new DynamicPropertyUsage().CallDirect(), Is.GreaterThan(0));
}