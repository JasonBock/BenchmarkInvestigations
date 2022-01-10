using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests
{
	public static class AttributeLookupTests
	{
		[Test]
		public static void FindMethodCountWith5UsingIsDefined() =>
			Assert.That(new AttributeLookup().FindMethodCountWith5UsingIsDefined(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith5UsingGetCustomAttribute() =>
			Assert.That(new AttributeLookup().FindMethodCountWith5UsingGetCustomAttribute(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith5UsingWellKnownName() =>
			Assert.That(new AttributeLookup().FindMethodCountWith5UsingWellKnownName(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith10UsingIsDefined() =>
			Assert.That(new AttributeLookup().FindMethodCountWith10UsingIsDefined(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith10UsingGetCustomAttribute() =>
			Assert.That(new AttributeLookup().FindMethodCountWith10UsingGetCustomAttribute(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith10UsingWellKnownName() =>
			Assert.That(new AttributeLookup().FindMethodCountWith10UsingWellKnownName(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith20UsingIsDefined() =>
			Assert.That(new AttributeLookup().FindMethodCountWith20UsingIsDefined(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith20UsingGetCustomAttribute() =>
			Assert.That(new AttributeLookup().FindMethodCountWith20UsingGetCustomAttribute(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith20UsingWellKnownName() =>
			Assert.That(new AttributeLookup().FindMethodCountWith20UsingWellKnownName(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith50UsingIsDefined() =>
			Assert.That(new AttributeLookup().FindMethodCountWith50UsingIsDefined(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith50UsingGetCustomAttribute() =>
			Assert.That(new AttributeLookup().FindMethodCountWith50UsingGetCustomAttribute(), Is.EqualTo(2));

		[Test]
		public static void FindMethodCountWith50UsingWellKnownName() =>
			Assert.That(new AttributeLookup().FindMethodCountWith50UsingWellKnownName(), Is.EqualTo(2));
	}
}