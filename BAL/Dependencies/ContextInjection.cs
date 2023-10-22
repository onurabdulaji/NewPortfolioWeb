using DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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


        }
    }
}
