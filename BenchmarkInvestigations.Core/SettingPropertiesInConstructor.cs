using BenchmarkDotNet.Attributes;
using BenchmarkInvestigations.Core.SupportingTypes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class SettingPropertiesInConstructor
{
	[Benchmark]
	public IPerson CreateViaSetters() =>
		new PersonViaSetters(Guid.NewGuid(), "Jason", 22);

	[Benchmark(Baseline = true)]
	public IPerson CreateViaTuple() =>
		new PersonViaTuple(Guid.NewGuid(), "Jason", 22);
}