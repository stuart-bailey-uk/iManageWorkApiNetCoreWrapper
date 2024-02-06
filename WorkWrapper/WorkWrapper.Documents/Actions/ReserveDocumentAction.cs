using WorkWrapper.Comms;
using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions
{
    public class ReserveDocumentAction
    {
        private readonly IWorkApiClient _workApiClient;

        public ReserveDocumentAction(IWorkApiClient workApiClient)
        {
            _workApiClient = workApiClient;
        }

        public async Task<IDataResponse<ReservedDocument>> ReserveDocumentAsync()
        {
            return await _workApiClient.GetAsync<DataResponse<ReservedDocument>>("documents/reserve");
        }
    }


}
