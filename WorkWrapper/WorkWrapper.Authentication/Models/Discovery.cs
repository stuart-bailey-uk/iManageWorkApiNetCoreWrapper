using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWrapper.Authentication.Models
{
    [ExcludeFromCodeCoverage]
    public class Discovery
    {
        public DiscoveryData? Data { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiscoveryData
    {
        public DiscoveryUser? User { get; set; }

        public DiscoveryWork? Work { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiscoveryUser
    {
        public int? CustomerId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiscoveryWork
    {
        public string? PreferredLibrary { get; set; }
    }
}
