using WorkWrapper.Core.Exceptions;
using Xunit;

namespace WorkWrapper.Core.Tests;

public class LibraryExtractorTests
{
    [Fact]
    public void ValidDocumentId_ExtractsLibrarySuccessfully()
    {
        //assign
        var id = "LIVE!1234.1";

        //act
        var extractor = new LibraryExtractor();
        var library = extractor.GetLibrary(id);

        //assert
        Assert.Equal("LIVE", library);
    }

    [Fact]
    public void ValidFolderId_ExtractsLibrarySuccessfully()
    {
        //assign
        var id = "LIVE!1234";

        //act
        var extractor = new LibraryExtractor();
        var library = extractor.GetLibrary(id);

        //assert
        Assert.Equal("LIVE", library);
    }

    [Fact]
    public void InvalidId_ThrowsException()
    {
        //assign
        var id = "123456.1";

        //act
        var extractor = new LibraryExtractor();

        //assert
        var exception = Assert.Throws<InvalidIdException>(() => extractor.GetLibrary(id));
    }
}