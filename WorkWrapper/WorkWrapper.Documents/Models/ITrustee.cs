using System.ComponentModel.DataAnnotations;
using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public interface ITrustee
{
    /// <summary>
    /// Id of the Trustee
    /// </summary>
    [MaxLength(32)]
    public string Id { get; set; }

    public AccessLevel AccessLevel { get; set; }
}