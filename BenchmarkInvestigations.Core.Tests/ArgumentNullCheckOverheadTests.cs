using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class ArgumentNullCheckOverheadTests
{
	[Test]
	public static void PassToNullCheck() =>
		Assert.That(new ArgumentNullCheckOverhead().PassToNullCheck(), Is.Not.Null);

	[Test]
	public static void PassWithoutNullCheck() =>
		Assert.That(new ArgumentNullCheckOverhead().PassWithoutNullCheck(), Is.Not.Null);
}