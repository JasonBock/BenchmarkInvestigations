using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class ArgumentNullCheckOverhead
{
	private readonly MightBeNull value = new();

	[Benchmark(Baseline = true)]
	public WithNullCheck PassToNullCheck() =>
		new(this.value);

	[Benchmark]
	public WithNullCheckUsingThrowIfNull PassToNullCheckUsingThrowIfNull() =>
		new(this.value);

	[Benchmark]
	public WithoutNullCheck PassWithoutNullCheck() =>
		new(this.value);
}

public class MightBeNull { }

public class WithNullCheck
{
	private readonly MightBeNull might;

	public WithNullCheck(MightBeNull might) =>
		this.might = might ?? throw new ArgumentNullException(nameof(might));
}

public class WithNullCheckUsingThrowIfNull
{
	private readonly MightBeNull might;

	public WithNullCheckUsingThrowIfNull(MightBeNull might)
	{
		ArgumentNullException.ThrowIfNull(might);
		this.might = might;
	}
}

public class WithoutNullCheck
{
	private readonly MightBeNull might;

	public WithoutNullCheck(MightBeNull might) =>
		this.might = might;
}