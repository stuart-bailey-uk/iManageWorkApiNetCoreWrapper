using System.Text;
using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Core.Helpers;
using WorkWrapper.Core.Models;
using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions;

/// <inheritdoc/>
public class DocumentsSearchAction : IDocumentsSearchAction
{
    private readonly IWorkApiClient _workApiClient;

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public DocumentsSearchAction(IWorkApiClient workApiClient)
    {
        _workApiClient = workApiClient;
    }

    /// <inheritdoc/>
    public virtual async Task<IDataResponse<ResultsCollection<WorkDocument>>> SearchDocumentsAsync(IDocumentSearchProfile searchProfile,
        string? library = null)
    {
        var query = ConvertToQueryString.Convert(searchProfile);

        if (query == string.Empty)
            throw new ArgumentException("Search Profile contains no criteria");

        if (library == null)
            _workApiClient.ForPreferredLibrary();
        else
            _workApiClient.ForLibrary(library);

        var result = await _workApiClient.GetAsync<DataResponse<ResultsCollection<WorkDocument>>>($"documents{query}");

        return result ?? new DataResponse<ResultsCollection<WorkDocument>>();
    }
}