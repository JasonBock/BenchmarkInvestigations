using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class IteratingAnonymousAndTupleTypesTests
{
	[Test]
	public static void IterateOverAnonymousTypes() =>
		Assert.That(new IteratingAnonymousAndTupleTypes().IterateOverAnonymousTypes(), Is.EqualTo(186));

	[Test]
	public static void IterateOverTupleTypes() =>
		Assert.That(new IteratingAnonymousAndTupleTypes().IterateOverTupleTypes(), Is.EqualTo(186));
}