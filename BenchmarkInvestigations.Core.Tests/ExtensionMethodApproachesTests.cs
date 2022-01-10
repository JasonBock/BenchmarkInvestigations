using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class ExtensionMethodApproachesTests
{
	[Test]
	public static void GetAgeWithExtensionDeconstruct() =>
		Assert.That(new ExtensionMethodApproaches().GetAgeWithExtensionDeconstruct(), Is.EqualTo(33));

	[Test]
	public static void GetAgeWithInstanceDeconstruct() =>
		Assert.That(new ExtensionMethodApproaches().GetAgeWithInstanceDeconstruct(), Is.EqualTo(33));
}