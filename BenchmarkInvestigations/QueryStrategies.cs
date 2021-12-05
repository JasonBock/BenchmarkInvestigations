using BenchmarkDotNet.Attributes;
using BenchmarkInvestigations.SupportingTypes;

namespace BenchmarkInvestigations
{
   [MemoryDiagnoser]
	public class QueryStrategies
	{
		private const int Children = 1000;
		private readonly Root root;

		public QueryStrategies()
		{
			var root = new Root();

			for (var i = 0; i < QueryStrategies.Children; i++)
			{
				var childOfRoot = new ChildOfRoot();

				for (var j = 0; j < QueryStrategies.Children; j++)
				{
					childOfRoot.Children.Add(
						new ChildOfChildOfRoot(Guid.NewGuid(), (State)(j % 3), j % 2 == 0));
				}

				root.Children.Add(childOfRoot);
			}

			this.root = root;
		}

		[Benchmark]
		public List<Guid> GetValuesWithForEachAndTwoIfStatements()
		{
			var results = new List<Guid>();

			foreach (var childOfRoot in this.root.Children)
			{
				foreach (var childOfChildOfRoot in childOfRoot.Children)
				{
					if (childOfChildOfRoot.State == State.Value1 && !childOfChildOfRoot.Switch)
					{
						results.Add(childOfChildOfRoot.IdGuid);
					}

					if (childOfChildOfRoot.State == State.Value2 && !childOfChildOfRoot.Switch)
					{
						results.Add(childOfChildOfRoot.IdGuid);
					}
				}
			}

			return results;
		}

		[Benchmark]
		public List<Guid> GetValuesWithForEachAndOneIfStatement()
		{
			var results = new List<Guid>();

			foreach (var childOfRoot in this.root.Children)
			{
				foreach (var childOfChildOfRoot in childOfRoot.Children)
				{
					if ((childOfChildOfRoot.State == State.Value1 || childOfChildOfRoot.State == State.Value2) && !childOfChildOfRoot.Switch)
					{
						results.Add(childOfChildOfRoot.IdGuid);
					}
				}
			}

			return results;
		}

		[Benchmark]
		public List<Guid> GetValuesWithForEachAndOneIfStatementWithBooleanCheckFirst()
		{
			var results = new List<Guid>();

			foreach (var childOfRoot in this.root.Children)
			{
				foreach (var childOfChildOfRoot in childOfRoot.Children)
				{
					if (!childOfChildOfRoot.Switch && (childOfChildOfRoot.State == State.Value1 || childOfChildOfRoot.State == State.Value2))
					{
						results.Add(childOfChildOfRoot.IdGuid);
					}
				}
			}

			return results;
		}

		[Benchmark(Baseline = true)]
		public List<Guid> GetValuesWithForAndOneIfStatementWithBooleanCheckFirst()
		{
			var results = new List<Guid>();

			for (var i = 0; i < this.root.Children.Count; i++)
			{
				var childOfRoot = this.root.Children[i];

				for (var j = 0; j < childOfRoot.Children.Count; j++)
				{
					var childOfChildOfRoot = childOfRoot.Children[j];

					if (!childOfChildOfRoot.Switch && (childOfChildOfRoot.State == State.Value1 || childOfChildOfRoot.State == State.Value2))
					{
						results.Add(childOfChildOfRoot.IdGuid);
					}
				}
			}

			return results;
		}
	}
}