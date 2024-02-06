using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public interface IWorkProfile : IMetadataProfile, IBaseEntity
{
    WsType? WsType { get; }

    DefaultSecurity? DefaultSecurity { get; set; }

    string? Type { get; set; }

    DateTime? EditProfileDate { get; set; }

    string? Name { get; set; }

    string? Class { get; set; }

    string? SubClass { get; set; }
}

