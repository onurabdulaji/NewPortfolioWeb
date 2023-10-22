using DTO.Map.Mapper.Register;
using EL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ManagerServices.Abstracts
{
    public interface IAppUserManager : IGenericManager<AppUser>
    {
        Task<IdentityResult> CreateUser(AppUser item, string Password);
    }
}
