using BAL.ManagerServices.Abstracts;
using BAL.ManagerServices.Concretes;
using Castle.Components.DictionaryAdapter.Xml;
using DTO.Map.Mapper.Register;
using EL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IAppUserManager _appuserManager;

        public RegisterController(IAppUserManager appuserManager)
        {
            _appuserManager = appuserManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterUserVM vmodel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = vmodel.Username,
                    Email = vmodel.Mail,
                    FirstName = vmodel.Name,
                    LastName = vmodel.Surname,
                    PhoneNumber = vmodel.Phone,
                    City = vmodel.City,
                    Country = vmodel.Country,
                };
                var result = await _appuserManager.CreateUser(user, vmodel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(vmodel);
        }
    }
}
