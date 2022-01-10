using NUnit.Framework;

namespace BenchmarkInvestigations.Core.Tests;

public static class QueryStrategiesTests
{
	[Test]
	public static void GetValuesWithForEachAndTwoIfStatements() =>
		Assert.That(new QueryStrategies().GetValuesWithForEachAndTwoIfStatements().Count, Is.GreaterThan(0));

	[Test]
	public static void GetValuesWithForEachAndOneIfStatement() =>
		Assert.That(new QueryStrategies().GetValuesWithForEachAndOneIfStatement().Count, Is.GreaterThan(0));

	[Test]
	public static void GetValuesWithForEachAndOneIfStatementWithBooleanCheckFirst() =>
		Assert.That(new QueryStrategies().GetValuesWithForEachAndOneIfStatementWithBooleanCheckFirst().Count, Is.GreaterThan(0));

	[Test]
	public static void GetValuesWithForAndOneIfStatementWithBooleanCheckFirst() =>
		Assert.That(new QueryStrategies().GetValuesWithForAndOneIfStatementWithBooleanCheckFirst().Count, Is.GreaterThan(0));
}