using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class HashSetEnsureCapacity
{
	[Benchmark(Baseline = true)]
	public int GetCountNotUsingEnsureCapacity()
	{
		var items = new HashSet<string>(3) { "a", "b", "c" };
		items.Add("d");
		items.Add("e");
		items.Add("f");
		items.Add("g");
		items.Add("h");
		items.Add("i");
		return items.Count;
	}

	[Benchmark]
	public int GetCountUsingEnsureCapacity()
	{
		var items = new HashSet<string>(3) { "a", "b", "c" };
		items.EnsureCapacity(9);
		items.Add("d");
		items.Add("e");
		items.Add("f");
		items.Add("g");
		items.Add("h");
		items.Add("i");
		return items.Count;
	}

	[Benchmark]
	public int GetCountSettingCapacity()
	{
		var items = new HashSet<string>(9) { "a", "b", "c" };
		items.Add("d");
		items.Add("e");
		items.Add("f");
		items.Add("g");
		items.Add("h");
		items.Add("i");
		return items.Count;
	}
}