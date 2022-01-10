using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class StringOperationsTests
{
	private static readonly StringOperations operations = new();

	[OneTimeSetUp]
	public static void OneTimeSetUp()
	{
		StringOperationsTests.operations.DataSize = 100;
		StringOperationsTests.operations.GlobalSetup();
	}

	[Test]
	public static void ReplaceWithMatch() =>
		Assert.That(StringOperationsTests.operations.ReplaceWithMatch().Length, Is.GreaterThan(0));

	[Test]
	public static void ReplaceWithNoMatch() =>
		Assert.That(StringOperationsTests.operations.ReplaceWithNoMatch().Length, Is.GreaterThan(0));

	[Test]
	public static void ContainsAndReplaceWithMatch() =>
		Assert.That(StringOperationsTests.operations.ContainsAndReplaceWithMatch().Length, Is.GreaterThan(0));

	[Test]
	public static void ContainsAndReplaceWithNoMatch() =>
		Assert.That(StringOperationsTests.operations.ContainsAndReplaceWithNoMatch().Length, Is.GreaterThan(0));
}