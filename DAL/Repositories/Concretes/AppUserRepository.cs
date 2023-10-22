using DAL.Concrete;
using DAL.Repositories.Abstracts;
using EL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concretes
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserDal
    {
        UserManager<AppUser> _usermanager;
        public AppUserRepository(Context context, UserManager<AppUser> usermanager) : base(context)
        {
            _usermanager = usermanager;
        }

        public async Task<IdentityResult> CreateUSer(AppUser item, string password)
        {
            if (item.Email != null && password != null)
            {
                return await _usermanager.CreateAsync(item, password);
            }
            else
            {
                var errors = new List<IdentityError>();
                if (item.Email == null)
                {
                    errors.Add(new IdentityError { Description = "Email is required" });
                }
                if (password == null)
                {
                    errors.Add(new IdentityError { Description = "Password is required" });
                }
                return IdentityResult.Failed(errors.ToArray());
            }
        }
    }
}
