using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class HashCodeTechniquesTests
{
	[Test]
	public static void GetHashCodeFromHashCodeCombine() =>
		Assert.That(() => new HashCodeTechniques().GetHashCodeFromHashCodeCombine(), Throws.Nothing);

	[Test]
	public static void GetHashCodeFromPrimeNumberUsage() =>
		Assert.That(() => new HashCodeTechniques().GetHashCodeFromPrimeNumberUsage(), Throws.Nothing);

	[Test]
	public static void GetHashCodeFromRecordImplementation() =>
		Assert.That(() => new HashCodeTechniques().GetHashCodeFromRecordImplementation(), Throws.Nothing);

	[Test]
	public static void GetHashCodeFromTupleHashCode() =>
		Assert.That(() => new HashCodeTechniques().GetHashCodeFromTupleHashCode(), Throws.Nothing);

	[Test]
	public static void GetHashCodeFromXOR() =>
		Assert.That(() => new HashCodeTechniques().GetHashCodeFromXOR(), Throws.Nothing);
}