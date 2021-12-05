using BenchmarkDotNet.Attributes;
using BenchmarkInvestigations.SupportingTypes;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class RunConstruction
{
	[Benchmark]
	public IPerson CreateViaSetters() =>
		new PersonViaSetters(Guid.NewGuid(), "Jason", 22);

	[Benchmark(Baseline = true)]
	public IPerson CreateViaTuple() =>
		new PersonViaTuple(Guid.NewGuid(), "Jason", 22);
}