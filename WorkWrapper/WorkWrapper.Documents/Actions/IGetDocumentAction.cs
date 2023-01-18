using WorkWrapper.Comms;
using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions;

/// <summary>
/// Gets a document based on its unique identifier
/// </summary>
public interface IGetDocumentAction
{
    /// <summary>
    /// Specifies to return a list of the user's allowed operations on the document.
    /// </summary>
    /// <returns></returns>
    IGetDocumentAction IncludeOperations();

    /// <summary>
    /// Specifies the latest document version regardless of the version in the id.
    /// </summary>
    /// <returns></returns>
    IGetDocumentAction GetLatest();

    /// <summary>
    /// Specifies the ID of the parent container.
    /// </summary>
    /// <param name="parentId"></param>
    /// <remarks>This can be a folder ID or workspace ID. The parent container can affect the operations allowed to be performed on the document.</remarks>
    /// <returns></returns>
    IGetDocumentAction ParentId(string parentId);

    /// <summary>
    /// Returns the document profile
    /// </summary>
    /// <param name="documentId"></param>
    /// <returns></returns>
    Task<IDataResponse<WorkDocument>> GetDocumentAsync(string documentId);
}