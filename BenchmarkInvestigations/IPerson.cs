using System;

namespace BenchmarkInvestigations
{
	public interface IPerson
	{
		Guid Id { get; }
		string Name { get; }
		uint Age { get; }
	}
}