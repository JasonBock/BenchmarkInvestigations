using BenchmarkDotNet.Attributes;
using System.Text;
using System;

#nullable disable

namespace BenchmarkInvestigations
{
	[MemoryDiagnoser]
	public class StringOperations
	{
		private string data;

		[Params(100000, 1000000, 10000000, 100000000)]
		public int DataSize;

		[GlobalSetup]
		public void Setup()
		{
			var buffer = new byte[this.DataSize];
			new Random(309).NextBytes(buffer);

			// Random string
			// ASCII 34 - 126 - All ascii values beyond ! (34)
			for (var i = 0; i < buffer.Length; i++) 
			{ 
				buffer[i] = (byte)(buffer[i] % 93 + 34); 
			};

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
}