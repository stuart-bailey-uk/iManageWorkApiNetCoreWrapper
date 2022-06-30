using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWrapper.Comms;
using WorkWrapper.Core.Models;
using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions
{
    /// <summary>
    /// Searches for documents based on their profile
    /// </summary>
    public interface IDocumentsSearchAction
    {
        /// <summary>
        /// Returns a list of document profiles
        /// </summary>
        /// <param name="searchProfile">Search Criteria</param>
        /// <param name="library">Library to search, defaults to users Preferred Library</param>
        /// <returns>Collection of document profiles</returns>
        Task<IDataResponse<ResultsCollection<WorkDocument>>> SearchDocumentsAsync(IDocumentSearchProfile searchProfile,
            string? library = null);
    }
}
