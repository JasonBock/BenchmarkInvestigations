using BenchmarkDotNet.Attributes;
using BenchmarkInvestigations.SupportingTypes;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class ServiceControllerTests
{
	private readonly string value = Guid.NewGuid().ToString();
	private readonly ServiceController controller = new(new(new()));

	[Benchmark]
	public async Task<ServiceData?> GetData() =>
		await this.controller.GetAsync(this.value).ConfigureAwait(false);

	[Benchmark(Baseline = true)]
	public async Task<ServiceData?> BetterGetData() =>
		await this.controller.BetterGetAsync(this.value).ConfigureAwait(false);
}