using BenchmarkDotNet.Attributes;
using BenchmarkInvestigations.Core.SupportingTypes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class ServiceControllerUsage
{
	private readonly string value = Guid.NewGuid().ToString();
	private readonly ServiceController controller = new(new(new()));

	[Benchmark]
	public async Task<ServiceData?> GetDataAsync() =>
		await this.controller.GetAsync(this.value).ConfigureAwait(false);

	[Benchmark(Baseline = true)]
	public async Task<ServiceData?> BetterGetDataAsync() =>
		await this.controller.BetterGetAsync(this.value).ConfigureAwait(false);
}