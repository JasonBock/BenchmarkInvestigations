using BenchmarkDotNet.Attributes;
using System.Text;

#nullable disable

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class StringOperations
{
	private string data;

	[Params(100000, 1000000, 10000000, 100000000)]
	public int DataSize;

	[GlobalSetup]
	public void GlobalSetup()
	{
		var buffer = new byte[this.DataSize];
		new Random(309).NextBytes(buffer);

		const byte colonValue = (byte)':';

		// Random string
		// ASCII 34 - 126 - All ascii values beyond ! (34),
		// and not putting in ":" (58)
		for (var i = 0; i < buffer.Length; i++)
		{
			var value = (byte)(buffer[i] % 93 + 34);

			if (value == colonValue)
			{
				value = colonValue + 1;
			}

			buffer[i] = value;
		};

		// Ensuring that ":" is in the string, 1/2 through
		buffer[buffer.Length / 2] = colonValue;
		this.data = Encoding.ASCII.GetString(buffer);
	}

	[Benchmark]
	public string ReplaceWithMatch() => this.data.Replace(":", string.Empty);

	[Benchmark]
	public string ReplaceWithNoMatch() => this.data.Replace("!", string.Empty);

	[Benchmark]
	public string ContainsAndReplaceWithMatch()
	{
		if (this.data.Contains(":"))
		{
			return this.data.Replace(":", string.Empty);
		}

		return this.data;
	}

	[Benchmark]
	public string ContainsAndReplaceWithNoMatch()
	{
		if (this.data.Contains("!"))
		{
			return this.data.Replace("!", string.Empty);
		}

		return this.data;
	}
}