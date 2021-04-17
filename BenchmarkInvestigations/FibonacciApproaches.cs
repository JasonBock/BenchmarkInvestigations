using BenchmarkDotNet.Attributes;
using BenchmarkInvestigations.SupportingTypes;
using System.Collections.Generic;
using System.Numerics;

namespace BenchmarkInvestigations
{
	[MemoryDiagnoser]
	public class FibonacciApproaches
	{
		[Benchmark]
		[ArgumentsSource(nameof(FibonacciApproaches.StartingValues))]
		public BigInteger CalculateUsingList(BigInteger start) => FibonacciTechniques.CalculateViaList(start);
		
		[Benchmark]
		[ArgumentsSource(nameof(FibonacciApproaches.StartingValues))]
		public BigInteger CalculateUsingRecursive(BigInteger start) => FibonacciTechniques.CalculateViaRecursion(start);

		[Benchmark(Baseline = true)]
		[ArgumentsSource(nameof(FibonacciApproaches.StartingValues))]
		public BigInteger CalculateUsingLocals(BigInteger start) => FibonacciTechniques.CalculateViaLocals(start);

		public IEnumerable<BigInteger> StartingValues()
		{
			yield return 1;
			yield return 3;
			yield return 6;
			yield return 12;
			yield return 20;
			yield return 35;
		}
	}
}