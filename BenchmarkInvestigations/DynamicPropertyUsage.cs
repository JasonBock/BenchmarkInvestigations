using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class DynamicPropertyUsage
{
	private static readonly Data data = new() { Value = 10 };
	private static readonly int random = new Random().Next(1000);

	[Benchmark]
	public int CallDynamic() => DynamicPropertyUsage.GetValueViaDynamic(DynamicPropertyUsage.data);

	[Benchmark(Baseline = true)]
	public int CallDirect() => DynamicPropertyUsage.GetValueViaDirect(DynamicPropertyUsage.data);

	private static int GetValueViaDirect(Data data) => data.Value * DynamicPropertyUsage.random;

	private static int GetValueViaDynamic(dynamic data) => data.Value * DynamicPropertyUsage.random;
}

public class Data
{
	public int Value { get; set; }
}