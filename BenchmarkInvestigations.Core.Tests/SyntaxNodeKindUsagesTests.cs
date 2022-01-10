using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class SyntaxNodeKindUsagesTests
{
	private static readonly SyntaxNodeKindUsages usages = new();

	[OneTimeSetUp]
	public static void OneTimeSetUp() => SyntaxNodeKindUsagesTests.usages.GlobalSetup();

	[Test]
	public static void CheckKindUsingIsKind() =>
		Assert.That(SyntaxNodeKindUsagesTests.usages.CheckKindUsingIsKind(), Is.True);

	[Test]
	public static void CheckKindUsingKind() =>
		Assert.That(SyntaxNodeKindUsagesTests.usages.CheckKindUsingKind(), Is.True);

	[Test]
	public static void CheckKindUsingRawKind() =>
		Assert.That(SyntaxNodeKindUsagesTests.usages.CheckKindUsingRawKind(), Is.True);
}