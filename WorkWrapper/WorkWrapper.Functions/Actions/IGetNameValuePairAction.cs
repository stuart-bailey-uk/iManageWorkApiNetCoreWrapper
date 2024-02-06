using WorkWrapper.Comms;
using WorkWrapper.Functions.Models;

namespace WorkWrapper.Functions.Actions;

public interface IGetNameValuePairAction
{
    Task<IDataResponse<List<NameValuePair>>?> GetNameValuePairsAsync(GetNameValuePairAction.NameValuePairType type, string containerId);
}