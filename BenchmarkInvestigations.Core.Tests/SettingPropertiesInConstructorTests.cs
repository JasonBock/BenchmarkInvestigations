using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class SettingPropertiesInConstructorTests
{
	[Test]
	public static void CreateViaSetters()
	{
		var person = new SettingPropertiesInConstructor().CreateViaSetters();
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
		var person = new SettingPropertiesInConstructor().CreateViaTuple();
		Assert.Multiple(() =>
		{
			Assert.That(person.Id, Is.Not.EqualTo(Guid.Empty));
			Assert.That(person.Age, Is.EqualTo(22));
			Assert.That(person.Name, Is.EqualTo("Jason"));
		});
	}
}