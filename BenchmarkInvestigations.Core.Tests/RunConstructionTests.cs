using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class RunConstructionTests
{
	[Test]
	public static void CreateViaSetters()
	{
		var person = new RunConstruction().CreateViaSetters();
		Assert.Multiple(() =>
		{
			Assert.That(person.Id, Is.Not.EqualTo(Guid.Empty));
			Assert.That(person.Age, Is.EqualTo(22));
			Assert.That(person.Name, Is.EqualTo("Jason"));
		});
	}

	[Test]
	public static void CreateViaTuple()
	{
		var person = new RunConstruction().CreateViaTuple();
		Assert.Multiple(() =>
		{
			Assert.That(person.Id, Is.Not.EqualTo(Guid.Empty));
			Assert.That(person.Age, Is.EqualTo(22));
			Assert.That(person.Name, Is.EqualTo("Jason"));
		});
	}
}