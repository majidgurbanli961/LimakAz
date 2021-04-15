using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProjectFinal.DataConnect;
using ProjectFinal.Models;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]


    public class RulesController : Controller
    {

        //Yeni

        private readonly DbContextApp _data;

        public RulesController(DbContextApp data)
        {
            _data = data;
        }
        public IActionResult Index(RulesAccardion rules)
        {
            var data = _data.RulesAccardions.ToList();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(RulesAccardion rules)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ModelOnly", "Hamisin Doldurun");
                return View(rules);
            }
            _data.RulesAccardions.Add(rules);
            _data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    

      
        public IActionResult Delete(int? Id)
        {
            var data = _data.RulesAccardions.Find(Id);
            if (data == null)
            {
                return NotFound();
            }
            _data.RulesAccardions.Remove(data);
         
            _data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.RulesAccardions.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, RulesAccardion rules)
        {

            if (!ModelState.IsValid)
            {
                return View(rules);
            }

            var data = _data.RulesAccardions.Find(rules.Id);
            if (data !=null)
            {
                data.Header = rules.Header;
                data.Body = rules.Body;
              
                _data.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var data = _data.RulesAccardions.Find(Id);
            if (data == null)
            {
                return NotFound();
            }


            return View(data);
        }
    }
}
