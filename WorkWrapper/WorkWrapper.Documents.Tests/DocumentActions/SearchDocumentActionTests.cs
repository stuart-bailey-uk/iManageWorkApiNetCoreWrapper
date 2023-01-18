using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Documents.Actions;
using WorkWrapper.Documents.Models;
using Xunit;

namespace WorkWrapper.Documents.Tests.DocumentActions
{
    public class SearchDocumentActionTests
    {
        [Fact]
        public async Task SearchDocument_Success_ReturnsResult()
        {
            //assign
            var searchCriteria = new StandardDocumentSearchProfile
            {
                Custom1 = "FOO",
                Class = "DOC"
            };

            var dataResponse = new DataResponse<ResultsCollection<WorkDocument>>
            {
                Data = new ResultsCollection<WorkDocument>
                {
                    Results = new List<WorkDocument>
                    {
                        new(),
                        new()
                    }
                }
            };

            var mWorkApiClient = new Mock<IWorkApiClient>();
            mWorkApiClient.Setup(m => m.GetAsync<DataResponse<ResultsCollection<WorkDocument>>>(It.IsAny<string>()))
                .ReturnsAsync(dataResponse);
            mWorkApiClient.Setup(m => m.ForPreferredLibrary()).Returns(mWorkApiClient.Object);

            //act
            var action = new DocumentsSearchAction(mWorkApiClient.Object);
            var response = await action.SearchDocumentsAsync(searchCriteria);

            //assert
            Assert.Equal(2, response?.Data?.Results.Count());
            mWorkApiClient.Verify(m =>
                m.GetAsync<IDataResponse<ResultsCollection<WorkDocument>>>(It.Is<string>(s =>
                    s == "documents?custom1=foo&class=doc")));
        }

        [Fact]
        public async Task SearchDocument_NoCriteria_ReturnsArgException()
        {
            //assign
            var searchCriteria = new StandardDocumentSearchProfile();

            var mWorkApiClient = new Mock<IWorkApiClient>();

            //act
            var action = new DocumentsSearchAction(mWorkApiClient.Object);
            
            //assert
            await Assert.ThrowsAsync<ArgumentException>(() => action.SearchDocumentsAsync(searchCriteria));
        }

    }
}
