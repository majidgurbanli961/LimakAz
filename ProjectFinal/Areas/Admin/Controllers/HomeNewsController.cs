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


    public class HomeNewsController : Controller
    {
        //Yeni

        private readonly DbContextApp _data;
        private readonly IHostingEnvironment _hosting;


        public HomeNewsController(DbContextApp data, IHostingEnvironment hosting)
        {

            _data = data;
            _hosting = hosting;
        }


        public IActionResult IndexHomeNews(HomeNews news)
        {
            var data = _data.HomeNews.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HomeNews news)
        {
            if (news.Photo == null)
            {
                ModelState.AddModelError("Photo", "Sekil Yukleyin");
                return View(news);
            }


            string filename = news.Photo.Save(_hosting.WebRootPath, "images/img2");
            news.Image = filename;
            news.Date = DateTime.Now;
            
            _data.HomeNews.Add(news);
            _data.SaveChanges();
            return RedirectToAction(nameof(IndexHomeNews));
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var slider = _data.HomeNews.Find(Id);
            if (slider == null)
            {
                return NotFound();
            }


            return View(slider);
        }

      

        
        public IActionResult Delete(int? Id)
        {
            var data = _data.HomeNews.Find(Id);
            if (data == null)
            {
                return NotFound();
            }
            _data.HomeNews.Remove(data);
            RemoveImage(_hosting.WebRootPath, data.Image);
            _data.SaveChanges();

            return RedirectToAction(nameof(IndexHomeNews));
        }



        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.HomeNews.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, HomeNews slider)
        {

            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            var newsfromdb = _data.HomeNews.Find(slider.Id);

            if (slider.Photo != null)
            {


                RemoveImage(_hosting.WebRootPath, newsfromdb.Image);
                newsfromdb.Image = slider.Photo.Save(_hosting.WebRootPath, "images/img2");

            }
            newsfromdb.Title = slider.Title;
            newsfromdb.Description = slider.Description;
            _data.SaveChanges();
            return RedirectToAction(nameof(IndexHomeNews));
        }
    }
}
