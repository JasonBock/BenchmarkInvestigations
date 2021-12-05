using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class FormattingGuids
{
	private readonly Guid value = Guid.NewGuid();

	[Benchmark(Baseline = true)]
	public string CreateViaFormatString() => this.value.ToString("N");

	[Benchmark]
	public string CreateViaReplace() => this.value.ToString().Replace("-", "");
}