namespace BenchmarkInvestigations.Core.SupportingTypes;

public class ServiceController
{
	private readonly Service service;

	public ServiceController(Service service) =>
		this.service = service ?? throw new ArgumentNullException(nameof(service));

	public async Task<ServiceData?> GetAsync(string dataId)
	{
		if (string.IsNullOrEmpty(dataId))
		{
			return null;
		}

		if (await this.service.TryParseGuid(dataId).ConfigureAwait(false))
		{
			// This was an async call, ignored that.
			dataId = this.service.GetDataName(Guid.Parse(dataId)) ?? dataId;
		}

		return await this.service.GetData(dataId).ConfigureAwait(false);
	}

	public async Task<ServiceData> BetterGetAsync(string dataId)
	{
		if (Guid.TryParse(dataId, out var id))
		{
			// This was an async call, ignored that.
			dataId = this.service.GetDataName(id) ?? dataId;
		}

		return await this.service.GetData(dataId).ConfigureAwait(false);
	}
}