using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations
{
	public class DynamicInvocations
	{
		[Benchmark(Baseline = true)]
		public int ReturnValueViaDirectCall()
		{
			var generator = new NumberGenerator();
			return generator.ReturnValue(2);
		}

		[Benchmark]
		public int ReturnValueViaDynamic()
		{
			dynamic generator = new NumberGenerator();
			return generator.ReturnValue(2);
		}
	}

	public class NumberGenerator
	{
		public int ReturnValue(int x) => x++;
	}
}