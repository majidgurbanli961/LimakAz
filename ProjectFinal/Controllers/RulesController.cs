using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ProjectFinal.DataConnect;
using ProjectFinal.Models;

namespace ProjectFinal.Controllers
{
  
        public class RulesController : Controller
        {


            private readonly DbContextApp _data;

            public RulesController(DbContextApp data)
            {
                _data = data;
            }
            public IActionResult Index()
            {
                var data = _data.RulesAccardions.ToList();
                return View(data);
            }

    
        }
    
}
