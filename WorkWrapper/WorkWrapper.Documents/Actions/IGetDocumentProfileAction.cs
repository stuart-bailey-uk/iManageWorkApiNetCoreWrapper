using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions;

/// <summary>
/// Retrieves the profile for a document
/// </summary>
public interface IGetDocumentProfileAction
{
    /// <summary>
    /// Gets the document profile
    /// </summary>
    /// <param name="documentId">[LIBRARY]![DOCNUM].[VERSION]</param>
    /// <returns>Work Document Profile</returns>
    Task<IWorkDocument?> GetAsync(string documentId);
}