using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class ListsAndCapacity
{
	[Params(5, 10, 50, 100, 500, 1000, 5000)]
	public int Count;

	[Benchmark]
	public int CreateWithoutCapacity()
	{
		var items = new List<int>();

		for (var i = 0; i < this.Count; i++)
		{
			items.Add(i);
		}

		return items.Count;
	}

	[Benchmark]
	public int CreateWith25PercentCapacity()
	{
		var items = new List<int>(this.Count / 4);

		for (var i = 0; i < this.Count; i++)
		{
			items.Add(i);
		}

		return items.Count;
	}

	[Benchmark]
	public int CreateWith50PercentCapacity()
	{
		var items = new List<int>(this.Count / 2);

		for (var i = 0; i < this.Count; i++)
		{
			items.Add(i);
		}

		return items.Count;
	}

	[Benchmark(Baseline = true)]
	public int CreateWithCapacity()
	{
		var items = new List<int>(this.Count);

		for (var i = 0; i < this.Count; i++)
		{
			items.Add(i);
		}

		return items.Count;
	}
}