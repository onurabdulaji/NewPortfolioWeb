using BAL.ManagerServices.Abstracts;
using DAL.Repositories.Abstracts;
using DTO.Map.Mapper.Register;
using EL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ManagerServices.Concretes
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserManager
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal) : base(appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public async Task<IdentityResult> CreateUser(AppUser item, string password)
        {
            if (string.IsNullOrWhiteSpace(item.Email) || string.IsNullOrWhiteSpace(password))
            {
                var errors = new List<IdentityError>();
                if (string.IsNullOrEmpty(item.Email))
                {
                    errors.Add(new IdentityError { Description = "Email is required." });
                }
                if (string.IsNullOrEmpty(password))
                {
                    errors.Add(new IdentityError { Description = "Password is required." });
                }
                return IdentityResult.Failed(errors.ToArray());
            }

            // Şifreyi hashleyip kullanıcıyı kaydetme
            var result = await _appUserDal.CreateUSer(item, password);
            return result;
        }
    }
}
