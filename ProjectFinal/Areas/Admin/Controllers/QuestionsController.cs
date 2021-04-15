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


    public class QuestionsController : Controller
    {

        private readonly DbContextApp _data;

        public QuestionsController(DbContextApp data)
        {
            //Yeni
            _data = data;
        }
        public IActionResult Index(Questions questions)
        {
            var data = _data.Questions.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Questions questions)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ModelOnly", "Hamisin Doldurun");
                return View(questions);
            }
            _data.Questions.Add(questions);
            _data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



      
        public IActionResult Delete(int? Id)
        {
            var data = _data.Questions.Find(Id);
            if (data == null)
            {
                return NotFound();
            }
            _data.Questions.Remove(data);

            _data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.Questions.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, Questions questions)
        {

            if (!ModelState.IsValid)
            {
                return View(questions);
            }

            var data = _data.Questions.Find(questions.Id);
            if (data != null)
            {
                data.Header = questions.Header;
                data.Body = questions.Body;

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
            var slider = _data.Questions.Find(Id);
            if (slider == null)
            {
                return NotFound();
            }


            return View(slider);
        }

    }
}

