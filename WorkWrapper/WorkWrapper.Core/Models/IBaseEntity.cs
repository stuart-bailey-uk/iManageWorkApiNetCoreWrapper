namespace WorkWrapper.Core.Models;

public interface IBaseEntity
{
    string Id { get; set; }

    string? Database { get; set; }
}