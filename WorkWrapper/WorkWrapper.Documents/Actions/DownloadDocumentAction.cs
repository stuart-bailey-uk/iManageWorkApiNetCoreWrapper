using WorkWrapper.Comms;
using WorkWrapper.Core;

namespace WorkWrapper.Documents.Actions;

/// <inheritdoc/>
public class DownloadDocumentAction : IDownloadDocumentAction
{
    private readonly IWorkApiClient _workApiClient;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="workApiClient">WorkApiClient implementation</param>
    public DownloadDocumentAction(IWorkApiClient workApiClient)
    {
        _workApiClient = workApiClient;
    }

    /// <inheritdoc/>
    public async Task<string> DownloadAsync(string documentId, string destinationPath)
    {
        var responseStream = await DownloadAsync(documentId);

        await using var destination = File.Open(destinationPath, FileMode.Create);

        await responseStream.CopyToAsync(destination);
        return destination.Name;
    }

    /// <inheritdoc />
    public async Task<Stream> DownloadAsync(string documentId)
    {
        var library = new LibraryExtractor().GetLibrary(documentId);

        // Get the stream to download to the path

        var responseStream = await _workApiClient
            .ForLibrary(library)
            .GetStreamAsync($"documents/{documentId}/download");

        if (responseStream == null)
            throw new WorkApiException("Download Stream is null", string.Empty);

        return responseStream;
    }
}