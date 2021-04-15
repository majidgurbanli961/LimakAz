using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc7748;
using ProjectFinal.Areas.Admin.Models;
using ProjectFinal.DataConnect;
using ProjectFinal.Models;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="SuperAdmin")]
        
    
    public class SuperAdminController : Controller
    {
        private readonly UserManager<DbPassportUserModel> user;
        private readonly SignInManager<DbPassportUserModel> signIn;
        private readonly DbContextApp dbContext;
        private readonly RoleManager<IdentityRole> roleManager;
        

        public SuperAdminController(UserManager<DbPassportUserModel> user, SignInManager<DbPassportUserModel> signIn, DbContextApp _dbContext, RoleManager<IdentityRole> roleManager)
        {
            this.user = user;
            this.signIn = signIn;
            dbContext = _dbContext;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var users = user.Users.ToList();
            Dictionary<string, string> userAndRole = new Dictionary<string, string>();
            foreach (var muser in users)
            {
                var roleName = user.GetRolesAsync(muser).Result.ToList();
                if (roleName.Count <=0)
                {

                }
                else
                {
                userAndRole[muser.UserName]=roleName[0];
                     ViewBag.UserAndRole = userAndRole;

                }
            }
            return View();
        }
        public IActionResult GiveRoleToUser()
        {
           
               
            
            
            var users = user.Users.ToList();
            var roles = roleManager.Roles.ToList();
            SuperAdminViewModel superAdminView = new SuperAdminViewModel()
            {
                Users=users,
                Roles=roles
            };
            return View(superAdminView);
        }
        [HttpPost]
        public async  Task<IActionResult> GiveRoleToUser(string userId,string roleId)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await user.FindByIdAsync(userId);
                var rolesOfCurrentUser = await user.GetRolesAsync(currentUser);
                await user.RemoveFromRolesAsync(currentUser, rolesOfCurrentUser.ToArray());
                var currentRole = await  roleManager.FindByIdAsync(roleId);
                 var result = user.AddToRoleAsync(currentUser, currentRole.Name).Result;
                if (result.Succeeded)
                {

                }
            }
            var users = user.Users.ToList();
            var roles = roleManager.Roles.ToList();
            SuperAdminViewModel superAdminView = new SuperAdminViewModel()
            {
                Users = users,
                Roles = roles
            };
            return View(superAdminView);
        }
        public async Task<IActionResult> DeleteUser(string username)
        {
            var customUser = await user.FindByNameAsync(username);
            var fResult = dbContext.Balances.FirstOrDefault(x => x.DbPassportUserModelId == customUser.Id);
            dbContext.Balances.Remove(fResult);
            var result =  user.DeleteAsync(customUser).Result;
           
            return RedirectToAction("Index");
            
            

        }
        public IActionResult CustomError()
        {
            return View();
        }
    }
}