namespace WorkWrapper.Documents.Models;

public interface IDocumentUploadRequest
{
    public IDocumentProfile DocProfile { get; }

    public bool WarningForRequiredAndDisabledFields { get; set; }

    public bool KeepLocked { get; set; }

    public bool InheritProfileFromFolder { get; set; }

    public IEnumerable<ITrustee> UserTrustees { get; set; }

    public IEnumerable<ITrustee> GroupTrustees { get; set; }
}