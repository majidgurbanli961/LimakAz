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
    [Authorize(Roles = "Admin,SuperAdmin,Moderator")]

    public class HomeController : Controller


    {

        //Yeni
        private readonly DbContextApp _data;
        private readonly IHostingEnvironment _hosting;


        public HomeController(DbContextApp data, IHostingEnvironment hosting)
        {

            _data = data;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult IndexHomeSlider()
        {
            var data = _data.HomeSliders.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeSlider slider)
        {
            if (slider.Photo==null)
            {
                ModelState.AddModelError("Photo", "Sekil Yukleyin");
                return View(slider);
            }


            string filename = slider.Photo.Save(_hosting.WebRootPath, "images/img2");
            slider.Image = filename;
            _data.HomeSliders.Add(slider);
            _data.SaveChanges();
            return RedirectToAction(nameof(IndexHomeSlider));
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var slider = _data.HomeSliders.Find(Id);
            if (slider == null)
            {
                return NotFound();
            }


            return View(slider);
        }

       

     
        public IActionResult Delete(int? Id)
        {
            var data = _data.HomeSliders.Find(Id);
            if (data == null)
            {
                return NotFound();
            }
            _data.HomeSliders.Remove(data);
            RemoveImage(_hosting.WebRootPath, data.Image);
            _data.SaveChanges();

            return RedirectToAction(nameof(IndexHomeSlider));
        }



        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.HomeSliders.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, HomeSlider slider)
        {

            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            var newsfromdb = _data.HomeSliders.Find(slider.Id);
            if (slider.Photo != null)
            {
               

                RemoveImage(_hosting.WebRootPath, newsfromdb.Image);
                newsfromdb.Image = slider.Photo.Save(_hosting.WebRootPath, "images/img2");
            }
   
            _data.SaveChanges();
            return RedirectToAction(nameof(IndexHomeSlider));
        }
    }
}
