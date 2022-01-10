using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class SummationApproaches
{
	[Benchmark]
	[ArgumentsSource(nameof(SummationApproaches.ValueGenerator))]
	public int AddUpUsingCountExtension(Holder holder)
	{
		var result = 0;
		var values = holder.Values;

		for (var i = 0; i < values.Count(); i++)
		{
			result += values[i];
		}

		return result;
	}

	[Benchmark(Baseline = true)]
	[ArgumentsSource(nameof(SummationApproaches.ValueGenerator))]
	public int AddUpUsingProperty(Holder holder)
	{
		var result = 0;
		var values = holder.Values;

		for (var i = 0; i < values.Count; i++)
		{
			result += values[i];
		}

		return result;
	}

	[Benchmark]
	[ArgumentsSource(nameof(SummationApproaches.ValueGenerator))]
	public int AddUpUsingSum(Holder holder) => holder.Values.Sum();

	public IEnumerable<Holder> ValueGenerator()
	{
		yield return new(Enumerable.Range(0, 50).ToList());
		yield return new(Enumerable.Range(0, 100).ToList());
		yield return new(Enumerable.Range(0, 500).ToList());
		yield return new(Enumerable.Range(0, 1000).ToList());
		yield return new(Enumerable.Range(0, 5000).ToList());
		yield return new(Enumerable.Range(0, 10000).ToList());
	}

	public sealed class Holder
	{
		public Holder(List<int> values) => this.Values = values;

		public override string ToString() => $"Count = {this.Values.Count}";

		public List<int> Values { get; }
	}
}