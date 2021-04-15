using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.DataConnect;

namespace ProjectFinal.Controllers
{
    public class ContactController : Controller
    {
        private readonly DbContextApp dbContext;

        public ContactController(DbContextApp dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var shops = dbContext.Shops.ToList();
            var shopContents = dbContext.ShopContents.ToList();
            for (int i = 0; i < shops.Count; i++)
            {
                var id = shops[i].Id;
                var shopContent = shops[i].GetCurrentShopContent(shops[i].Id);

            }

            ViewBag.ShopContent = shopContents;
            return View(shops);
        }
    }
}