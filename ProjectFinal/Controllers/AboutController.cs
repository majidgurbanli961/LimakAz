using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.DataConnect;

namespace ProjectFinal.Controllers
{
    public class AboutController : Controller
    {
        private readonly DbContextApp _data;

        public AboutController(DbContextApp data)
        {

            _data = data;
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index()
        {
            var data = _data.Abouts.ToList();
            return View(data);
        }
    }
}
