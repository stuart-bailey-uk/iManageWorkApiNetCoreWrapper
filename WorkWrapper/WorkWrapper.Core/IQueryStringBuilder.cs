namespace WorkWrapper.Core;

public interface IQueryStringBuilder
{
    IQueryStringBuilder AddOrUpdate(string parameter, string value);

    IQueryStringBuilder Remove(string parameter);

    string ToString(bool asAppend);

    bool HasQuery { get; }
}