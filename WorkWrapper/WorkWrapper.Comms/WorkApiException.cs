using System.Diagnostics.CodeAnalysis;
using WorkWrapper.Comms.ErrorResponses;

namespace WorkWrapper.Comms;

[ExcludeFromCodeCoverage]
public class WorkApiException : Exception
{
    private readonly string _data;

    public IErrorResponse? ErrorResponse { get; }

    public bool HasDetails => ErrorResponse != null;

    public WorkApiException(IErrorResponse errorResponse, string textResponse) : base(errorResponse.GetType().Name)
    {
        ErrorResponse = errorResponse;
    }

    public WorkApiException(string message, string data) : base(message)
    {
        _data = data;
    }

    public string TextData => _data;
}