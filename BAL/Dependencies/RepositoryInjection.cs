using BAL.ManagerServices.Abstracts;
using BAL.ManagerServices.Concretes;
using DAL.Repositories.Abstracts;
using DAL.Repositories.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Dependencies
{
    public static class RepositoryInjection
    {
        public static void RepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericManager<>), typeof(BaseManager<>));

            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAppUserDal, AppUserRepository>();

        }
    }
}
