using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProjectFinal.DataConnect;
using ProjectFinal.Models;

namespace ProjectFinal.Controllers
{
    [Authorize]

    [CustomEmailVerification]

    public class QuestionsController : Controller
    {
        private readonly DbContextApp _data;

        public QuestionsController(DbContextApp data)
        {
            _data = data;
        }
        public IActionResult Index()
        {
            var data = _data.Questions.ToList();
            return View(data);
        }
    }
}
