using System;

namespace BenchmarkInvestigations.SupportingTypes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public sealed class FetchAttribute
		: Attribute
	{ }
}
