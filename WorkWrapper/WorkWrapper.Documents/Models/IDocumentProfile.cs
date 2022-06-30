using Newtonsoft.Json;
using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public interface IDocumentProfile : IWorkProfile
{
    string? Comment { get; set; }
    string? ContentType { get; set; }

    DateTime CreateDate { get; set; }

    DateTime? DeclaredDate { get; set; }

    int DocumentNumber { get; set; }

    DateTime EditDate { get; set; }

    string? Extension { get; set; }

    DateTime FileCreateDate { get; set; }

    DateTime FileEditDate { get; set; }

    bool IsInUse { get; set; }
    
    string? InUseBy { get; set; }
    
    bool? IsCheckedOut { get; set; }
    
    bool? IsDeclared { get; set; }
    
    bool? IsExternal { get; set; }
    
    bool? IsExternalAsNormal { get; set; }
    
    bool? IsHippa { get; set; }
    
    bool? IsRelated { get; set; }
    
    bool? IsRestorable { get; set; }
    
    string? Iwl { get; set; }
    
    string? LastUser { get; set; }

    int RetainDays { get; set; }
    
    string? WorkspaceId { get; set; }
    
    string? WorkspaceName { get; set; }

    LockType LockType { get; set; }
}