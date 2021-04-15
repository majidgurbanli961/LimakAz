using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.DataConnect;
using ProjectFinal.Extension;
using ProjectFinal.Models;
using static ProjectFinal.Utilities.Utilities;
namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class StoresController : Controller
    {
        private readonly DbContextApp _data;
        private readonly IHostingEnvironment _hosting;
        public StoresController(DbContextApp data, IHostingEnvironment hosting)
        {
            //Yeni
            _data = data;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            var data = _data.Stores.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Stores stores)
        {
            if (stores.Photo == null)
            {
                ModelState.AddModelError("Photo", "Şəkil Yükləyin");
                return View(stores);
            }


            string filename = stores.Photo.Save(_hosting.WebRootPath, "images/img2");
            stores.Image = filename;
              
            _data.Stores.Add(stores);
            _data.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var slider = _data.Stores.Find(Id);
            if (slider == null)
            {
                return NotFound();
            }


            return View(slider);
        }

     

        public IActionResult Delete(int? Id)
        {
            var data = _data.Stores.Find(Id);
            if (data == null)
            {
                return NotFound();
            }
            _data.Stores.Remove(data);
            RemoveImage(_hosting.WebRootPath, data.Image);
            _data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.Stores.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, Stores stores)
        {

            if (!ModelState.IsValid)
            {
                return View(stores);
            }

            var newsfromdb = _data.Stores.Find(stores.Id);
            if (stores.Photo != null)
            {


                RemoveImage(_hosting.WebRootPath, newsfromdb.Image);
                newsfromdb.Image = stores.Photo.Save(_hosting.WebRootPath, "images/img2");
            }
            newsfromdb.Title = stores.Title;
            _data.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
