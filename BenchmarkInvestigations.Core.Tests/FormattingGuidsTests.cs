using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class FormattingGuidsTests
{
	[Test]
	public static void CreateViaFormatString() =>
		Assert.That(new FormattingGuids().CreateViaFormatString().Length, Is.EqualTo(32));

	[Test]
	public static void CreateViaReplace() =>
		Assert.That(new FormattingGuids().CreateViaReplace().Length, Is.EqualTo(32));
}