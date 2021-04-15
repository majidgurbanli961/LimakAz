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

    public class AboutController : Controller
    {
        private readonly DbContextApp _data;
        private readonly IHostingEnvironment _hosting;
        public AboutController(DbContextApp data, IHostingEnvironment hosting)
        {
            //Yeni
            _data = data;
            _hosting = hosting;
        }
        public IActionResult Index()
        {
            var data = _data.Abouts.ToList();
            return View(data);
        }
        
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
     
        public IActionResult Create(About about)
        {
          
            if (about.Photo == null )
            {
                ModelState.AddModelError("Photo", "Şəkil Yükləyin");
                return View(about);
            }
            if (about.BodyText == null)
            {
                ModelState.AddModelError("BodyText", "Mətn Yazın");
                return View(about);
            }

            //Image Saved
            string filename = about.Photo.Save(_hosting.WebRootPath, "images/img2");
            about.Image = filename;
        

            
            _data.Abouts.Add(about);
            _data.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var slider = _data.Abouts.Find(Id);
            if (slider == null)
            {
                return NotFound();
            }


            return View(slider);
        }

        
      
        public IActionResult Delete(int? Id)
        {
            var data = _data.Abouts.Find(Id);
            if (data == null)
            {
                return NotFound();
            }
            _data.Abouts.Remove(data);
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
            var des = _data.Abouts.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, About about)
        {

            if (!ModelState.IsValid)
            {
                return View(about);
            }

            var newsfromdb = _data.Abouts.Find(about.Id);
            if (about.Photo != null)
            {


                RemoveImage(_hosting.WebRootPath, newsfromdb.Image);
                newsfromdb.Image = about.Photo.Save(_hosting.WebRootPath, "images/img2");
            }
            newsfromdb.BodyText = about.BodyText;
            _data.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
