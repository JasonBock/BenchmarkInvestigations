using System;
using System.Threading.Tasks;

namespace BenchmarkInvestigations.SupportingTypes
{
	public class Service
	{
		private readonly GuidParser parser;

		public Service(GuidParser parser) => 
			this.parser = parser ?? throw new ArgumentNullException(nameof(parser));

		public async Task<bool> TryParseGuid(string value)
		{
			if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
			{
				return false;
			}

			try
			{
				return await this.parser.TryParseGuid(value);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string GetDataName(Guid id) => "Joe";

		public Task<ServiceData> GetData(string userName) => Task.FromResult(new ServiceData());
	}
}