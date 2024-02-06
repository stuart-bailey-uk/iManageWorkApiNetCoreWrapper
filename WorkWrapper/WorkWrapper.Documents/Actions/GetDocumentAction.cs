using WorkWrapper.Comms;
using WorkWrapper.Core;
using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions;

public class GetDocumentAction : IGetDocumentAction
{
    private readonly IWorkApiClient _workApiClient;

    private readonly IQueryStringBuilder _queryParameters = new QueryStringBuilder();
    private bool _profileCheck;

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public GetDocumentAction(IWorkApiClient workApiClient)
    {
        _workApiClient = workApiClient;
    }

    /// <inheritdoc/>
    public IGetDocumentAction IncludeOperations()
    {
        _queryParameters.AddOrUpdate("include_operations", "true");

        return this;
    }

    /// <inheritdoc/>
    public IGetDocumentAction GetLatest()
    {
        _queryParameters.AddOrUpdate("is_latest", "true");

        return this;
    }

    /// <inheritdoc/>
    public IGetDocumentAction ParentId(string parentId)
    {
        _queryParameters.AddOrUpdate("parent_id", parentId);

        return this;
    }

    /// <inheritdoc/>
    public async Task<IDataResponse<WorkDocument>> GetDocumentAsync(string documentId)
    {
        var documentResponse = await _workApiClient.GetAsync<DataResponse<WorkDocument>>($"documents/{documentId}{_queryParameters}");

        return documentResponse;
    }
}