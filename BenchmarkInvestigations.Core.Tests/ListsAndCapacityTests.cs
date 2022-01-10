using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class ListsAndCapacityTests
{
	[Test]
	public static void CreateWithoutCapacity()
	{
		var tests = new ListsAndCapacity { Count = 1 };
		Assert.That(tests.CreateWithoutCapacity(), Is.EqualTo(1));
	}

	[Test]
	public static void CreateWith25PercentCapacity()
	{
		var tests = new ListsAndCapacity { Count = 1 };
		Assert.That(tests.CreateWith25PercentCapacity(), Is.EqualTo(1));
	}

	[Test]
	public static void CreateWith50PercentCapacity()
	{
		var tests = new ListsAndCapacity { Count = 1 };
		Assert.That(tests.CreateWith50PercentCapacity(), Is.EqualTo(1));
	}

	[Test]
	public static void CreateWithCapacity()
	{
		var tests = new ListsAndCapacity { Count = 1 };
		Assert.That(tests.CreateWithCapacity(), Is.EqualTo(1));
	}
}