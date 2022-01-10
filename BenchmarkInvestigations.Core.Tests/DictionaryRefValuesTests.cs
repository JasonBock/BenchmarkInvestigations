using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests
{
	public static class DictionaryRefValuesTests
	{
		private static readonly DictionaryRefValues values = new();

		[OneTimeSetUp]
		public static void OneTimeSetUp() => DictionaryRefValuesTests.values.GlobalSetup();

		[Test]
		public static void UpdateValueUsingCopy() =>
			Assert.That(DictionaryRefValuesTests.values.UpdateValueUsingCopy(), Is.EqualTo(1000));

		[Test]
		public static void UpdateValueUsingRef() =>
			Assert.That(DictionaryRefValuesTests.values.UpdateValueUsingRef(), Is.EqualTo(1000));
	}
}