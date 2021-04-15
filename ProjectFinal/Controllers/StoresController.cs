using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.DataConnect;

namespace ProjectFinal.Controllers
{
    public class StoresController : Controller
    {
        private readonly DbContextApp _data;

        public StoresController( DbContextApp data)
        {
      
            _data = data;
        }

        public IActionResult Index()
        {
            var data = _data.Stores.ToList();
            return View(data);
        }
    }
}
