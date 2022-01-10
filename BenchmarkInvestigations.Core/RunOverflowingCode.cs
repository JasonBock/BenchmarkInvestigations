using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class RunOverflowingCode
{
	public IEnumerable<object[]> Values()
	{
		yield return new object[] { 3, 7 };
		yield return new object[] { 12, 44 };
		yield return new object[] { 243, 48319 };
		yield return new object[] { 4315, 9199 };
		yield return new object[] { 10000, 10000 };
	}

	[Benchmark(Baseline = true)]
	[ArgumentsSource(nameof(Values))]
	public int MultiplyWithNoChecked(int i, int j) => i * j;

	[Benchmark]
	[ArgumentsSource(nameof(Values))]
	public int MultiplyWithChecked(int i, int j) => checked(i * j);
}