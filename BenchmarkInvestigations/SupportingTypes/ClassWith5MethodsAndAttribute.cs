using System;

namespace BenchmarkInvestigations.SupportingTypes
{
	public sealed class ClassWith5MethodsAndAttribute
	{
		void Method0() { }
		[Fetch]
		void Method1(Guid id) { }
		void Method2() { }
		[Fetch]
		void Method3(int id) { }
		void Method4() { }
	}
}
