using System;

namespace BenchmarkInvestigations
{
	public sealed class PersonViaSetters
		: IPerson
	{
		public PersonViaSetters(Guid id, string name, uint age)
		{
			this.Id = id;
			this.Name = name;
			this.Age = age;
		}

		public Guid Id { get; }
		public string Name { get; }
		public uint Age { get; }
	}
}