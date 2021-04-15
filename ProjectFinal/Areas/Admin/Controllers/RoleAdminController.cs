using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinal.Areas.Admin.Models;
using ProjectFinal.Models;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]



    public class RoleAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleAdminController(UserManager<DbPassportUserModel> user, SignInManager<DbPassportUserModel> signIn, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        //public IActionResult CreateRole()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CreateRole(RoleViewModel role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityRole identityRole = new IdentityRole()
        //        {
        //            Name = role.RoleName
        //        };
        //        var result =   roleManager.CreateAsync(identityRole).Result;
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
                        
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(role);
        //}
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            var scResult=  roleManager.DeleteAsync(result).Result;
            return RedirectToAction("Index");

        }
        public async  Task<IActionResult> EditRole(string id)
        {
            var edittedRole = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            RoleViewModel roleViewModel = new RoleViewModel()
            {
                Id=edittedRole.Id,
                RoleName = edittedRole.Name
            };
            return View(roleViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleViewModel roleViewModel)
        {
            var edittedRole = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleViewModel.Id);
            edittedRole.Name = roleViewModel.RoleName;
            await roleManager.UpdateAsync(edittedRole);
            return RedirectToAction("Index");
            
        }
    }
}