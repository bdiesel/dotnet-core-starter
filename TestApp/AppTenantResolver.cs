using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp
{
    public class AppTenantResolver : ITenantResolver<AppTenant>
    {
        IEnumerable<AppTenant> tenants = new List<AppTenant>(new[]
        {
        new AppTenant {
            Name = "Brian's World",
            Hostnames = new[] { "localhost:52701" }
        }//,
        /*new AppTenant {
            Name = "Tenant 2",
            Hostnames = new[] { "localhost:6002" }
        }*/
    });

        public async Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<AppTenant> tenantContext = null;

            var tenant = tenants.FirstOrDefault(t =>
                t.Hostnames.Any(h => h.Equals(context.Request.Host.Value.ToLower())));

            if (tenant != null)
            {
                tenantContext = new TenantContext<AppTenant>(tenant);
            }

            return tenantContext;
        }
    }
}