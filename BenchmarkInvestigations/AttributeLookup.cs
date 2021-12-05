using BenchmarkDotNet.Attributes;
using BenchmarkInvestigations.SupportingTypes;
using System.Reflection;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class AttributeLookup
{
	private const string FetchMethod = "DataPortal_Fetch";

	[Benchmark]
	public int FindMethodCountWith5UsingIsDefined() =>
		typeof(ClassWith5MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.IsDefined(typeof(FetchAttribute))).Count();

	[Benchmark]
	public int FindMethodCountWith5UsingGetCustomAttribute() =>
		typeof(ClassWith5MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.GetCustomAttribute<FetchAttribute>() != null).Count();

	[Benchmark]
	public int FindMethodCountWith5UsingWellKnownName() =>
		typeof(ClassWith5MethodsAndWellKnownName)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.Name == FetchMethod).Count();

	[Benchmark]
	public int FindMethodCountWith10UsingIsDefined() =>
		typeof(ClassWith10MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.IsDefined(typeof(FetchAttribute))).Count();

	[Benchmark]
	public int FindMethodCountWith10UsingGetCustomAttribute() =>
		typeof(ClassWith10MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.GetCustomAttribute<FetchAttribute>() != null).Count();

	[Benchmark]
	public int FindMethodCountWith10UsingWellKnownName() =>
		typeof(ClassWith10MethodsAndWellKnownName)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.Name == FetchMethod).Count();

	[Benchmark]
	public int FindMethodCountWith20UsingIsDefined() =>
		typeof(ClassWith20MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.IsDefined(typeof(FetchAttribute))).Count();

	[Benchmark]
	public int FindMethodCountWith20UsingGetCustomAttribute() =>
		typeof(ClassWith20MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.GetCustomAttribute<FetchAttribute>() != null).Count();

	[Benchmark]
	public int FindMethodCountWith20UsingWellKnownName() =>
		typeof(ClassWith20MethodsAndWellKnownName)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.Name == FetchMethod).Count();

	[Benchmark]
	public int FindMethodCountWith50UsingIsDefined() =>
		typeof(ClassWith50MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.IsDefined(typeof(FetchAttribute))).Count();

	[Benchmark]
	public int FindMethodCountWith50UsingGetCustomAttribute() =>
		typeof(ClassWith50MethodsAndAttribute)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.GetCustomAttribute<FetchAttribute>() != null).Count();

	[Benchmark]
	public int FindMethodCountWith50UsingWellKnownName() =>
		typeof(ClassWith50MethodsAndWellKnownName)
			.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(_ => _.Name == FetchMethod).Count();
}