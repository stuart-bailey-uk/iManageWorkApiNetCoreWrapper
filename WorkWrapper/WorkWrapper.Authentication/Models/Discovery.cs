using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWrapper.Authentication.Models
{
    public class Discovery
    {
        public DiscoveryData? Data { get; set; }
    }

    public class DiscoveryData
    {
        public DiscoveryUser? User { get; set; }

        public DiscoveryWork? Work { get; set; }
    }

    public class DiscoveryUser
    {
        public int? CustomerId { get; set; }
    }

    public class DiscoveryWork
    {
        public string? PreferredLibrary { get; set; }
    }
}
