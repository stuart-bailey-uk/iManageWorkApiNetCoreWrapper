using System.Text.RegularExpressions;

namespace WorkWrapper.Core;

public abstract class IdValidator
{
    public virtual string Pattern => "([A-z]+)(!)([0-9.]+)";

    protected virtual Match Validate(string id)
    {
        var regex = new Regex(Pattern);

        return regex.Match(id);
    }
}