using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class FormattingGuidsTests
{
	[Test]
	public static void Create()
	{
		var guids = new FormattingGuids();
		var formatResult = guids.CreateViaFormatString();
		var replaceResult = guids.CreateViaReplace();

		Assert.Multiple(() =>
		{
			Assert.That(formatResult, Is.Not.Null);
			Assert.That(() => Guid.ParseExact(formatResult, "N"), Throws.Nothing);
			Assert.That(formatResult, Is.EqualTo(replaceResult));
		});
	}
}