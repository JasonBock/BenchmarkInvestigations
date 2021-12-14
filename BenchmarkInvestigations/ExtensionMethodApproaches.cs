using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class ExtensionMethodApproaches
{
	private readonly CustomerWithInstanceDeconstruct customerWithInstanceDeconstruct =
		new(Guid.NewGuid(), "Name", 33);
	private readonly CustomerWithExtensionDeconstruct customerWithExtensionDeconstruct =
		new(Guid.NewGuid(), "Name", 33);

	[Benchmark]
	public uint GetAgeWithExtensionDeconstruct()
	{
		var (_, _, age) = this.customerWithExtensionDeconstruct;
		return age;
	}

	[Benchmark(Baseline = true)]
	public uint GetAgeWithInstanceDeconstruct()
	{
		var (_, _, age) = this.customerWithInstanceDeconstruct;
		return age;
	}
}

public sealed class CustomerWithInstanceDeconstruct
{
	public CustomerWithInstanceDeconstruct(Guid id, string name, uint age) =>
		(this.Id, this.Name, this.Age) = (id, name, age);

	public void Deconstruct(out Guid id, out string name, out uint age) =>
		(id, name, age) = (this.Id, this.Name, this.Age);

	public uint Age { get; }
	public Guid Id { get; }
	public string Name { get; }
}

public sealed class CustomerWithExtensionDeconstruct
{
	public CustomerWithExtensionDeconstruct(Guid id, string name, uint age) =>
		(this.Id, this.Name, this.Age) = (id, name, age);

	public uint Age { get; }
	public Guid Id { get; }
	public string Name { get; }
}

public static class CustomerWithExtensionDeconstructExtensions
{
	public static void Deconstruct(this CustomerWithExtensionDeconstruct self,
		out Guid id, out string name, out uint age) =>
			(id, name, age) = (self.Id, self.Name, self.Age);
}