using System.Net;
using Newtonsoft.Json;

namespace WorkWrapper.Comms.ErrorResponses
{
    public interface IErrorResponse
    {
        public string? Code { get; set; }

        public string? CodeMessage { get; set; }

        List<ErrorMessage>? Messages { get; set; }

    }

    public class ErrorMessage
    {
        public string? Code { get; set; }

        public string? CodeMessage { get; set; }

        public string? Field { get; set; }

        public dynamic? Data { get; set; }
    }

    public class BadRequest400 : IErrorResponse
    {
        public string? DmsVersion { get; set; }

        public string? Transaction { get; set; }
        public string? Code { get; set; }
        public string? CodeMessage { get; set; }
        public List<ErrorMessage>? Messages { get; set; }
    }

    public class Unauthorized401 : IErrorResponse
    {
        public string? DmsVersion { get; set; }

        public string? Transaction { get; set; }
        public string? Code { get; set; }
        public string? CodeMessage { get; set; }
        public List<ErrorMessage>? Messages { get; set; }
    }

    public class NotFound404 : IErrorResponse
    {
        public string? Code { get; set; }
        public string? CodeMessage { get; set; }
        public List<ErrorMessage>? Messages { get; set; }
    }

    public class ErrorResponseFactory
    {
        public static async Task<Exception> Create(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();

            var type = responseMessage.StatusCode switch
            {
                HttpStatusCode.BadRequest => typeof(BadRequest400),
                HttpStatusCode.Unauthorized => typeof(Unauthorized401),
                HttpStatusCode.NotFound => typeof(NotFound404),
                _ => throw new WorkApiException("Unexpected Api Error", content)
            };

            var exception = JsonConvert.DeserializeObject(content, type);

            return JsonConvert.DeserializeObject(content, type) is not IErrorResponse response ? 
                new WorkApiException($"Error Deserializing {type.Name} Response", content) : 
                new WorkApiException(response, content);
        }
    }
}
