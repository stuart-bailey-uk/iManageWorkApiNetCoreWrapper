using System.Diagnostics.CodeAnalysis;

namespace WorkWrapper.Comms;

[ExcludeFromCodeCoverage]
public class WorkApiException : Exception
{
    public WorkApiException(Uri? requestMessageRequestUri) : base($"Error calling {requestMessageRequestUri}")
    {

    }

    public WorkApiException(string message) : base(message)
    {

    }
}

public class WorkApiObjectException : Exception
{
    public dynamic Response { get; }

    public WorkApiObjectException(Uri? requestMessageRequestUri, string response) : base($"Error calling {requestMessageRequestUri}")
    {
        Response = response;
    }

    public WorkApiObjectException(string message, string response) : base(message)
    {
        Response = response;
    }
}