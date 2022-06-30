using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions;

/// <summary>
/// Downloads a work document to a local file path
/// </summary>
public interface IDownloadDocumentAction
{
    /// <summary>
    /// Downloads a document
    /// </summary>
    /// <param name="documentId">[LIBRARY]![DOCNUM].[VERSION]</param>
    /// <param name="destinationPath">File path to download the document to</param>
    /// <returns>Path to the downloaded document</returns>
    Task<string> DownloadAsync(string documentId, string destinationPath);
}