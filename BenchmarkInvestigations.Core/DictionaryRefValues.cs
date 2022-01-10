using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class DictionaryRefValues
{
	private readonly Dictionary<int, int> items = new();

	[GlobalSetup]
	public void GlobalSetup()
	{
		for (var i = 0; i < 1000; i++)
		{
			this.items.Add(i, 0);
		}
	}

	[Benchmark(Baseline = true)]
	public int UpdateValueUsingCopy()
	{
		for (var i = 0; i < 1000; i++)
		{
			this.items[i]++;
		}

		return this.items.Count;
	}

	[Benchmark]
	public int UpdateValueUsingRef()
	{
		for (var i = 0; i < 1000; i++)
		{
			ref var value = ref CollectionsMarshal.GetValueRefOrNullRef(this.items, i);
			value++;
		}

		return this.items.Count;
	}
}