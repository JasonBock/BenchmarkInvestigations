using System;
using System.Threading.Tasks;

namespace BenchmarkInvestigations.SupportingTypes
{
	public class GuidParser
	{
		public async Task<bool> TryParseGuid(string value)
		{
			if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
			{
				return false;
			}

			try
			{
				if(Guid.TryParse(value, out var guid))
				{
					return await Task.Run(() => true);
				}
				else
				{
					return await Task.Run(() => false);
				}
			}
			catch(Exception)
			{
				return false;
			}
		}
	}
}
