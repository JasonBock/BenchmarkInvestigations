namespace BenchmarkInvestigations.SupportingTypes;

public sealed class PersonViaTuple
	 : IPerson
{
	public PersonViaTuple(Guid id, string name, uint age) =>
		(this.Id, this.Name, this.Age) = (id, name, age);

	public Guid Id { get; }
	public string Name { get; }
	public uint Age { get; }
}