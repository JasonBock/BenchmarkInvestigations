using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class HashSetEnsureCapacityTests
{
	[Test]
	public static void GetCountNotUsingEnsureCapacity() =>
		Assert.That(new HashSetEnsureCapacity().GetCountNotUsingEnsureCapacity(), Is.EqualTo(9));

	[Test]
	public static void GetCountUsingEnsureCapacity() =>
		Assert.That(new HashSetEnsureCapacity().GetCountUsingEnsureCapacity(), Is.EqualTo(9));

	[Test]
	public static void GetCountSettingCapacity() =>
		Assert.That(new HashSetEnsureCapacity().GetCountSettingCapacity(), Is.EqualTo(9));
}