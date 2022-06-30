using System.Diagnostics.CodeAnalysis;

namespace WorkWrapper.Core.Exceptions;

[ExcludeFromCodeCoverage]
internal class InvalidIdException : Exception
{
    public InvalidIdException(string id) : base($"InvalidId: {id}")
    {

    }
}