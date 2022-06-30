using System.Diagnostics.CodeAnalysis;

namespace WorkWrapper.Documents.Models;

[ExcludeFromCodeCoverage]
public class LockType
{
    public static readonly LockType Shared = new('S');
    public static readonly LockType Exclusive = new('E');

    internal char Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected LockType(char value)
    {
        this.Value = value;
    }
}