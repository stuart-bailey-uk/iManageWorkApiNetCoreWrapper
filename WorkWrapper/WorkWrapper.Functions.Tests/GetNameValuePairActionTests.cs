using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Functions.Models;
using WorkWrapper.Session;

namespace WorkWrapper.Functions.Tests;

public class NameValuePairConverterTests
{
    [Fact]
    public async Task Request_Success_ReturnsData()
    {
        //assign
        const string json = "{ \"data\": {\"trial_date\": \"2021-01-15T15:00:00.000000Z\",  \"prefix_document_name\": \"true\"} }";

        //act
        var response =
            JsonConvert.DeserializeObject<DataResponse<List<NameValuePair>>>(json, new NameValuePairConverter());

        //assert
        Assert.NotNull(response?.Data);
        Assert.Equal(2, response!.Data!.Count);
    }
}