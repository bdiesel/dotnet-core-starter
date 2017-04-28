using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TestApp
{
    public class MultiTenancyOptions
    {
        public Collection<AppTenant> Tenants { get; set; }
    }
}
