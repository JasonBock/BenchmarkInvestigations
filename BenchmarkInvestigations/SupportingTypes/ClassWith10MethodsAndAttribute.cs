using System;

namespace BenchmarkInvestigations.SupportingTypes
{
	public sealed class ClassWith10MethodsAndAttribute
	{
		void Method0() { }
		[Fetch]
		void Method1(Guid id) { }
		void Method2() { }
		void Method3() { }
		void Method4() { }
		void Method5() { }
		void Method6() { }
		void Method7() { }
		[Fetch]
		void Method8(int id) { }
		void Method9() { }
	}
}
