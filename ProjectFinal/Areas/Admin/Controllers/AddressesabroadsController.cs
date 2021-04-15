using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinal.DataConnect;
using ProjectFinal.Models;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class AddressesabroadsController : Controller
    {
        private readonly DbContextApp _data;

        public AddressesabroadsController(DbContextApp data)
        {
            //Yeni
            _data = data;

        }
        public IActionResult Index()
        {
            var data = _data.Addressesabroads.Include(x => x.Country).ToList();
            return View(data);
        }





        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(addressesabroad address)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ModelOnly", "Hamisin Doldurun");
                return View(address);
            }
            _data.Addressesabroads.Add(address);
            _data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.Addressesabroads.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, addressesabroad adress)
        {

            if (!ModelState.IsValid)
            {
                return View(adress);
            }

            var data = _data.Addressesabroads.Find(adress.Id);
            if (data != null)
            {
                data.City = adress.City;
                data.District = adress.District;
                data.DistrictTwo = adress.DistrictTwo;
                data.CountryId = adress.CountryId;
                data.identityNumber = adress.identityNumber;
                data.TaxAdministration = adress.TaxAdministration;
                data.TaxNumber = adress.TaxNumber;
                data.PhoneNumber = adress.PhoneNumber;
                data.ZIP = adress.ZIP;



                _data.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }


      
        public IActionResult Delete(int? Id)
        {
            var data = _data.Addressesabroads.Find(Id);

            if (data == null)
            {
                return NotFound();
            }
            _data.Addressesabroads.Remove(data);

            _data.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }


            var data = _data.Addressesabroads.Find(Id);



            if (data == null)
            {
                return NotFound();
            }


            return View(data);
        }

    }
}

