using System.Text;

namespace WorkWrapper.Core
{
    public class QueryStringBuilder : IQueryStringBuilder
    {
        private readonly List<QueryStringParameter> _parameters = new ();

        public IQueryStringBuilder AddOrUpdate(string parameter, string value)
        {
            var existingParameter = _parameters.SingleOrDefault(p =>
                p.Parameter.Equals(parameter, StringComparison.CurrentCultureIgnoreCase));

            if (existingParameter == null)
                _parameters.Add(new QueryStringParameter(parameter, value));
            else
                existingParameter.Value = value;

            return this;
        }

        public IQueryStringBuilder Remove(string parameter)
        {
            _parameters.RemoveAll(p => p.Parameter.Equals(parameter, StringComparison.CurrentCultureIgnoreCase));

            return this;
        }

        public string ToString(bool asAppend)
        {
            bool first = true;
            var builder = new StringBuilder();
            foreach (var parameter in _parameters)
            {
                if (first && !asAppend)
                {
                    builder.Append($"?{parameter}");
                    first = false;
                    continue;
                }
                builder.Append($"&{parameter}");
            }
            return builder.ToString();
        }

        public bool HasQuery => _parameters.Any();

        public override string ToString()
        {
            return ToString(false);
        }

        private class QueryStringParameter
        {
            public string Parameter { get; }
            public string Value { get; set; }

            internal QueryStringParameter(string parameter, string value)
            {
                Parameter = parameter;
                Value = value;
            }

            public override string ToString()
            {
                return $"{Parameter}={Value}";
            }
        }
    }
}
