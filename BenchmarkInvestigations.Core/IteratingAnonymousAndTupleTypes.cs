using BenchmarkDotNet.Attributes;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class IteratingAnonymousAndTupleTypes
{
	[Benchmark]
	public int IterateOverAnonymousTypes()
	{
		var length = 0;

		var friends = new[]
		{
				new
				{
					name = "Bruce Wayne",
					nickname = "Batman",
					hobbies = new[] {"dressing up", "crime-fighting", "parkour"}
				},
				new
				{
					name = "Natalia Romanova",
					nickname = "Black Widow",
					hobbies = new[] {"martial arts", "spying", "guns"}
				},
				new
				{
					name = "Arthur Curry",
					nickname = "Aquaman",
					hobbies = new[] {"surfing", "conversations", "fish"}
				}
			};

		foreach (var friend in friends)
		{
			length += $"{friend.name} ({friend.nickname}) likes {string.Join(", ", friend.hobbies)}.".Length;
		}

		return length;
	}

	[Benchmark(Baseline = true)]
	public int IterateOverTupleTypes()
	{
		var length = 0;

		var friends = new[]
		{
				(
					"Bruce Wayne",
					"Batman",
					new[] {"dressing up", "crime-fighting", "parkour"}
				),
				(
					"Natalia Romanova",
					"Black Widow",
					new[] {"martial arts", "spying", "guns"}
				),
				(
					"Arthur Curry",
					"Aquaman",
					new[] {"surfing", "conversations", "fish"}
				)
			};

		foreach (var (name, nickname, hobbies) in friends)
		{
			length += $"{name} ({nickname}) likes {string.Join(", ", hobbies)}.".Length;
		}

		return length;
	}
}