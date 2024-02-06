using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Functions.Models;

namespace WorkWrapper.Functions.Actions;

public class GetNameValuePairAction : IGetNameValuePairAction
{
    private readonly IWorkApiClient _workApiClient;

    public GetNameValuePairAction(IWorkApiClient workApiClient)
    {
        _workApiClient = workApiClient;
    }

    /// <inheritdoc />
    public async Task<IDataResponse<List<NameValuePair>>?> GetNameValuePairsAsync(NameValuePairType type, string containerId)
    {
        var response = await _workApiClient.GetAsync<DataResponse<List<NameValuePair>>>($"{type.ToString().ToLower()}/{containerId}/name-value-pairs", NameValuePairSerializationSettings());

        return response;
    }

    public enum NameValuePairType
    {
        Documents,
        Folders,
        Workspaces
    }

    private JsonSerializerSettings NameValuePairSerializationSettings()
    {
        return new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new NameValuePairConverter()
            }
        };
    }
}