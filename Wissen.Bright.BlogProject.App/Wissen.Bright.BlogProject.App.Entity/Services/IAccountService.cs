﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Bright.BlogProject.App.Entity.ViewModels;

namespace Wissen.Bright.BlogProject.App.Entity.Services
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task LogoutAsync();
        
        Task<List<RoleViewModel>> GetAllRoles();
        Task<String>CreateRoleAsync(RoleViewModel model);
    }
}
