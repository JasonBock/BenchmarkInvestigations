using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class ComparingCasesTests
{
	[TestCase(LogLevel.Trace, true)]
	[TestCase(LogLevel.Debug, true)]
	[TestCase(LogLevel.Warning, false)]
	[TestCase(LogLevel.Error, true)]
	[TestCase(LogLevel.Information, false)]
	[TestCase(LogLevel.Critical, true)]
	public static void IsEnabledUsingDictionary(LogLevel level, bool isEnabled)
	{
		var cases = new ComparingCases() { Level = level };
		Assert.That(cases.IsEnabledUsingDictionary(), Is.EqualTo(isEnabled));
	}

	[TestCase(LogLevel.Trace, true)]
	[TestCase(LogLevel.Debug, true)]
	[TestCase(LogLevel.Warning, false)]
	[TestCase(LogLevel.Error, true)]
	[TestCase(LogLevel.Information, false)]
	[TestCase(LogLevel.Critical, true)]
	public static void IsEnabledUsingSwitch(LogLevel level, bool isEnabled)
	{
		var cases = new ComparingCases() { Level = level };
		Assert.That(cases.IsEnabledUsingSwitch(), Is.EqualTo(isEnabled));
	}

	[TestCase(LogLevel.Trace, true)]
	[TestCase(LogLevel.Debug, true)]
	[TestCase(LogLevel.Warning, false)]
	[TestCase(LogLevel.Error, true)]
	[TestCase(LogLevel.Information, false)]
	[TestCase(LogLevel.Critical, true)]
	public static void IsEnabledUsingSwitchExpression(LogLevel level, bool isEnabled)
	{
		var cases = new ComparingCases() { Level = level };
		Assert.That(cases.IsEnabledUsingSwitchExpression(), Is.EqualTo(isEnabled));
	}

	[TestCase(LogLevel.Trace, true)]
	[TestCase(LogLevel.Debug, true)]
	[TestCase(LogLevel.Warning, false)]
	[TestCase(LogLevel.Error, true)]
	[TestCase(LogLevel.Information, false)]
	[TestCase(LogLevel.Critical, true)]
	public static void IsEnabledUsingIf(LogLevel level, bool isEnabled)
	{
		var cases = new ComparingCases() { Level = level };
		Assert.That(cases.IsEnabledUsingIf(), Is.EqualTo(isEnabled));
	}
}