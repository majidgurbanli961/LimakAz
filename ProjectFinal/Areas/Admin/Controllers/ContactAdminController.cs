using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectFinal.Areas.Admin.Models;
using ProjectFinal.DataConnect;
using ProjectFinal.Extension;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]



    public class ContactAdminController : Controller
    {
        private readonly DbContextApp dbContext;
        private readonly IHostingEnvironment hosting;

        public ContactAdminController( DbContextApp dbContext, IHostingEnvironment hosting)
        {
            this.dbContext = dbContext;
            this.hosting = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateShop()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateShop(Shop shop)
        {
            if (ModelState.IsValid)
            {
                await dbContext.Shops.AddAsync(shop);
                var result = await dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return RedirectToAction("SeeAllShops");
                }
            }
            return View();
        }
        public async Task<IActionResult> SeeAllShops()
        {
            var shops = await dbContext.Shops.ToListAsync();


            return View(shops);
        }
        public async Task<IActionResult> DeleteShop(int id)
        {
            var deletedResult = await dbContext.Shops.FirstOrDefaultAsync(x => x.Id == id);
            dbContext.Shops.Remove(deletedResult);
            var scResult = await dbContext.SaveChangesAsync();
            return RedirectToAction("SeeAllShops");


        }
        public async Task<IActionResult> EditShop(int id)
        {
            var edittedShop = await dbContext.Shops.FirstOrDefaultAsync(x => x.Id == id);


            return View(edittedShop);
        }
        [HttpPost]
        public async Task<IActionResult> EditShop(Shop shop)
        {
            var edittedShop = await dbContext.Shops.FirstOrDefaultAsync(x => x.Id == shop.Id);
            edittedShop.ShopAdress = shop.ShopAdress;
            await dbContext.SaveChangesAsync();
            return RedirectToAction("SeeAllShops");

        }
        public async Task<IActionResult> CreateShopContent()
        {
            var shops = await dbContext.Shops.ToListAsync();
            ViewBag.Shops = shops;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateShopContent(ShopContent shopContent)
        {
            
            var shops = await dbContext.Shops.ToListAsync();
            ViewBag.Shops = shops;
            
            await dbContext.ShopContents.AddAsync(shopContent);
            await dbContext.SaveChangesAsync();


            return RedirectToAction("SeeAllShopContent");
        }
        public async Task<IActionResult> SeeAllShopContent()
        {
            var allShops = await dbContext.Shops.ToListAsync();
            return View(allShops);
        }
        public JsonResult SeeAllShopContentAjax(int id)
        {
            var allShopContents =   dbContext.ShopContents.Where(x => x.ShopId == id).ToList();
            return Json(allShopContents);
        }
        public JsonResult DeleteShopContent(int id)
        {
            var deleteResult =   dbContext.ShopContents.FirstOrDefault(x => x.Id == id);
             dbContext.ShopContents.Remove(deleteResult);
            var result= dbContext.SaveChanges();
            
            return Json(result);


        }
        public async Task<IActionResult> EditShopContent(int id)

        {
            var shops = await dbContext.Shops.ToListAsync();
            ViewBag.Shops = shops;
            var edittedShopContent = await dbContext.ShopContents.FirstOrDefaultAsync(x => x.Id == id);
            return View(edittedShopContent);

        }
        [HttpPost]
        public async Task<IActionResult> EditShopContent(ShopContent shopContent)
        {
            var shops = await dbContext.Shops.ToListAsync();
            ViewBag.Shops = shops;
          
            var edittedContent = await dbContext.ShopContents.FirstOrDefaultAsync(x => x.Id == shopContent.Id);
           
            var a = 5;
            edittedContent.CustomText = shopContent.CustomText;
            await dbContext.SaveChangesAsync();
            return RedirectToAction("SeeAllShopContent");

        }

    }
}