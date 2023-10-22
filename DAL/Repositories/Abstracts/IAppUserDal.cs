using EL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Abstracts
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<IdentityResult> CreateUSer(AppUser item, string password);
    }
}
