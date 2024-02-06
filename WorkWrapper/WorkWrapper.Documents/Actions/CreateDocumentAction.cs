using System.Text;
using WorkWrapper.Comms;
using WorkWrapper.Documents.Models;

namespace WorkWrapper.Documents.Actions
{
    public class CreateDocumentAction
    {
        private readonly IWorkApiClient _workApiClient;

        public CreateDocumentAction(IWorkApiClient workApiClient)
        {
            _workApiClient = workApiClient;
        }

        public async Task<IDataResponse<WorkDocument>> CreateDocumentAsync(IDocumentUploadRequest documentUploadRequest, string folderId, Stream fileContent)
        {
            documentUploadRequest.DocProfile.Size = fileContent.Length;

            var boundary = "-----------------------" + DateTime.Now.Ticks;
            using var httpContent = new MultipartFormDataContent(boundary);

            httpContent.Headers.Remove("Content-Type");
            httpContent.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);

            var json = WorkSerializer.SerializeObject(documentUploadRequest);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            stringContent.Headers.Add("Content-Disposition", "form-data; name=\"profile\"; filename=\"blob\"");
            httpContent.Add(stringContent, "json");

            var fileName = $"{documentUploadRequest.DocProfile.Name}.{documentUploadRequest.DocProfile.Extension}";

            var streamContent = new StreamContent(fileContent, 10485760);
            streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + fileName + "\"");
            httpContent.Add(streamContent, "file", fileName);

            return await _workApiClient.SendAsync<DataResponse<WorkDocument>>(HttpMethod.Post, $"folders/{folderId}/documents", httpContent);
        }
    }
}
