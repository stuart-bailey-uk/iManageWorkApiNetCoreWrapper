namespace WorkWrapper.Documents.Models;

public class DocumentOperationPermissions
{
    public bool Archive { get; set; }

    public bool Copy { get; set; }

    public bool CreateNewVersion { get; set; }

    public bool Declare { get; set; }

    public bool Delete { get; set; }

    public bool Freeze { get; set; }

    public bool Lock { get; set; }

    public bool Move { get; set; }

    public bool Relate { get; set; }

    public bool Replace { get; set; }

    public bool Restore { get; set; }

    public bool SetSecurity { get; set; }

    public bool Undeclare { get; set; }

    public bool Unfreeze { get; set; }

    public bool Unlock { get; set; }

    public bool Update { get; set; }

    public bool WopiLock { get; set; }
}