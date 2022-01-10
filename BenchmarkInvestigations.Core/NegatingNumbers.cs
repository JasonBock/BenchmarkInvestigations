using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class NegatingNumbers
{
	[Benchmark]
	[ArgumentsSource(nameof(NegatingNumbers.GetValues))]
	public int NegateWithNegation(int value) => -value;

	[Benchmark]
	[ArgumentsSource(nameof(NegatingNumbers.GetValues))]
	public int NegateWithNegativeOne(int value) => value * -1;

	[Benchmark]
	[ArgumentsSource(nameof(NegatingNumbers.GetValues))]
	public int NegateWithString(int value) => value > 0 ? int.Parse("-" + value.ToString()) :
		value < 0 ? int.Parse(value.ToString()[1..]) : 0;

	public IEnumerable<int> GetValues()
	{
		yield return 1500;
		yield return -1500;
	}
}