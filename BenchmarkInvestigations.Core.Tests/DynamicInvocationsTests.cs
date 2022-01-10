using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests
{
	public static class DynamicInvocationsTests
	{
		[Test]
		public static void ReturnValueViaDirectCall() =>
			Assert.That(new DynamicInvocations().ReturnValueViaDirectCall(), Is.EqualTo(3));

		[Test]
		public static void ReturnValueViaDynamic() =>
			Assert.That(new DynamicInvocations().ReturnValueViaDynamic(), Is.EqualTo(3));
	}
}