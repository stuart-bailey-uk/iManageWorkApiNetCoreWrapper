using System.Text;

namespace WorkWrapper.Core.Helpers
{
    /// <summary>
    /// Creates a Query String from an object
    /// </summary>
    public static class ConvertToQueryString
    {
        /// <summary>
        /// Creates a Query String from an object
        /// </summary>
        public static string Convert<T>(T objectToConvert)
        {
            if(objectToConvert == null)
                return string.Empty;

            var objectProperties = objectToConvert.GetType().GetProperties();

            var stringBuilder = new StringBuilder("?");

            foreach (var property in objectProperties)
            {
                //Get the value
                var value = property.GetValue(objectToConvert);

                //All properties nullable to only serialize values
                if (value == null)
                    continue;

                var transformedName = System.Text.RegularExpressions.Regex.Replace(property.Name, "(?<=.)([A-Z])", "_$0", System.Text.RegularExpressions.RegexOptions.Compiled);

                stringBuilder.Append($"{transformedName.ToLower().Trim()}={value.ToString().ToLower().Trim()}&");
            }

            var query = stringBuilder.ToString();

            return query.Length == 1 ? string.Empty : query.TrimEnd('&');
        }
    }
}
