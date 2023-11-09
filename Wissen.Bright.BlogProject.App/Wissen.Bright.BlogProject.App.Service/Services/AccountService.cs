using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Bright.BlogProject.App.DataAccess.Identity;
using Wissen.Bright.BlogProject.App.Entity.Services;
using Wissen.Bright.BlogProject.App.Entity.ViewModels;

namespace Wissen.Bright.BlogProject.App.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateRoleAsync(RoleViewModel model)
        {
            string message = string.Empty;
            var role = new AppRole()
            {
                Name = model.Name,
                Description=model.Description,
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                message = "Ok";
            }

                
            else
            {
                foreach (var error in result.Errors)
                {
                    message = error.Description;
                }
                //ModelState.AddModelError("", "Rol kayıt işlemi gerçekleşmedi.");
            }
            return View(model);
        }

        public async Task<string> CreateUserAsync(RegisterViewModel model)
        {
            string message = string.Empty;
            var user = new AppUser()
            {
                Name = model.FirstName,
                Surname = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Username
            };
            var identityResult = await _userManager.CreateAsync(user, model.ConfirmPassword);

            if (identityResult.Succeeded)
            {
                message = "OK";
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    message = error.Description;
                }
            }
            return message;
        }
        public async Task<string> FindByNameAsync(LoginViewModel model)
        {
            string message = string.Empty;
            var user = await _userManager.FindByNameAsync(model.Username);
            if(user == null)
            {
                message = "user not found";
                return message;
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);  
            if (signInResult.Succeeded)
            {
                message = "OK";
            }
            return message;
        }

        public Task<List<RoleViewModel>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}
	}
}
