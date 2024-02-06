using WorkWrapper.Comms;

namespace WorkWrapper.Folders.Actions;

public class CreateFolderAction
{
    public CreateFolderAction(IWorkApiClient workApiClient)
    {
    }

    public async Task<IFolder> CreateFolderAsync(string parentId, IFolderCreationStrategy folderCreationStrategy)
    {

    }
}

public interface IFolderCreationStrategy { }
{
}