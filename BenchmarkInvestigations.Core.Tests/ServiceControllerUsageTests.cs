using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class ServiceControllerUsageTests
{
	[Test]
	public static async Task GetDataAsync() =>
		Assert.That(await new ServiceControllerUsage().GetDataAsync().ConfigureAwait(false), Is.Not.Null);

	[Test]
	public static async Task BetterGetDataAsync() =>
		Assert.That(await new ServiceControllerUsage().BetterGetDataAsync().ConfigureAwait(false), Is.Not.Null);
}