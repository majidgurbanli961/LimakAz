using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ProjectFinal.DataConnect;
using ProjectFinal.Models;
using ProjectFinal.Models.HomeViewModels;

namespace ProjectFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<DbPassportUserModel> userManager;
        private readonly DbContextApp _data;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<DbPassportUserModel> signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<DbPassportUserModel> userManager, DbContextApp data, RoleManager<IdentityRole> _roleManager, SignInManager<DbPassportUserModel> _signInManager)
        {
            _logger = logger;
            this.userManager = userManager;
            _data = data;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }

        public async Task <IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel { HomeSliders = _data.HomeSliders.ToList(),
                HomeNews=_data.HomeNews.ToList()
            };
            if (User.IsInRole("USER"))
            {

            }
           
                                    

            if (signInManager.IsSignedIn(User) == true)
            {
              var   SignedUserName = User.Identity.Name;
               var  user = _data.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
                ViewBag.FullName = user.Name + user.Surname;
            }

            return View(model);
        }


        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            HomeViewModel model = new HomeViewModel() { HomeNews = _data.HomeNews.OrderByDescending(x=>x.Id).ToList(),HomeNew= _data.HomeNews.Find(Id) };
          
            if (model.HomeNew == null)
            {
                return NotFound();
            }


            return View(model);
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
