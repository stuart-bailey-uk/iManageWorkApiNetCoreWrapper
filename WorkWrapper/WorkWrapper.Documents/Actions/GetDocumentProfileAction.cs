using WorkWrapper.Comms;
using WorkWrapper.Core;
using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions;

/// <inheritdoc />
public class GetDocumentProfileAction : IGetDocumentProfileAction
{
    private readonly IWorkApiClient _workApiClient;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="workApiClient">WorkApiClient implementation</param>
    public GetDocumentProfileAction(IWorkApiClient workApiClient)
    {
        _workApiClient = workApiClient;
    }

    /// <inheritdoc />
    public virtual async Task<IWorkDocument?> GetAsync(string documentId)
    {
        var library = new LibraryExtractor().GetLibrary(documentId);

        var response = await _workApiClient
            .ForLibrary(library)
            .GetAsync<DataResponse<WorkDocument>>($"documents/{documentId}");

        return response?.Data;
    }
}