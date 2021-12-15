using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class HashCodeTechniques
{
	private readonly string value1 = "A value";
	private readonly string value2 = "Another value";
	private readonly Guid value3 = Guid.NewGuid();
	private readonly uint value4 = 43125;

	private readonly HashCodeRecord record =
		new("A value", "Another value", Guid.NewGuid(), 43125);

	[Benchmark(Baseline = true)]
	public int GetHashCodeFromHashCodeCombine() =>
		HashCode.Combine(this.value1, this.value2, this.value3, this.value4);

	[Benchmark]
	public int GetHashCodeFromTupleHashCode() =>
		(this.value1, this.value2, this.value3, this.value4).GetHashCode();

	[Benchmark]
	public int GetHashCodeFromXOR() =>
		this.value1.GetHashCode() ^ this.value2.GetHashCode() ^ this.value3.GetHashCode() ^ this.value4.GetHashCode();

	[Benchmark]
	public int GetHashCodeFromPrimeNumberUsage()
	{
		var hash = 17;
		hash = hash * 23 + this.value1.GetHashCode(StringComparison.CurrentCulture);
		hash = hash * 23 + this.value2.GetHashCode(StringComparison.CurrentCulture);
		hash = hash * 23 + this.value3.GetHashCode();
		hash = hash * 23 + this.value4.GetHashCode();
		return hash;
	}

	[Benchmark]
	public int GetHashCodeFromRecordImplementation() =>
		this.record.GetHashCode();
}

public record HashCodeRecord(string Value1, string Value2, Guid value3, uint value4);