using Castle.Components.DictionaryAdapter.Xml;
using DAL.Concrete;
using EL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Dependencies
{
    public static class ContextInjection
    {
        public static void ContextDependencies(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<Context>(options => options.UseSqlServer(configuration.GetConnectionString("PortfolioDB")).UseLazyLoadingProxies());

            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("PortfolioDB")).UseLazyLoadingProxies());

            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<Context>();
        }
    }
}
