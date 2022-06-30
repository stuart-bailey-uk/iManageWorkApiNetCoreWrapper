using WorkWrapper.Core.Exceptions;

namespace WorkWrapper.Core;

public class LibraryExtractor : IdValidator, ILibraryExtractor
{
    public string GetLibrary(string id)
    {
        var match = Validate(id);

        if(match.Success)
            return match.Groups[1].Value;

        throw new InvalidIdException(id);
    }
}