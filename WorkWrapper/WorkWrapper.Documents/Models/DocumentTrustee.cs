using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public class DocumentTrustee : ITrustee
{
    /// <inheritdoc />
    public string Id { get; set; }

    /// <inheritdoc />
    public AccessLevel AccessLevel { get; set; }
}