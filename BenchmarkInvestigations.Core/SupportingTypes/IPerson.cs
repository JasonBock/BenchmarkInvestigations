namespace BenchmarkInvestigations.Core.SupportingTypes;

public interface IPerson
{
	Guid Id { get; }
	string Name { get; }
	uint Age { get; }
}