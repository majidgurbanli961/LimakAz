using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.DataConnect;
using ProjectFinal.Models.Courier;
using Microsoft.EntityFrameworkCore;

namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin,Moderator")]

    public class CourierController : Controller
    {

        private readonly DbContextApp _data;

        public CourierController(DbContextApp data)
        {
          
            _data = data;

        }
        public IActionResult CourierIndex()
        {
            var data = _data.CourierDeliveries.Include(x => x.DbPassportUserModel).OrderByDescending(x => x.id).ToList();

            return View(data);
        }

      
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.CourierDeliveries.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, CourierDbViewModel courier)
        {

          

            var data = _data.CourierDeliveries.Find(courier.id);
         
                data.PhoneNumber = courier.PhoneNumber;
                data.DeliveredStatus = courier.DeliveredStatus;
                data.Street = courier.Street;
                data.House = courier.House;
                data.InvoiceComments = courier.InvoiceComments;
       


                _data.SaveChanges();
           

            return RedirectToAction(nameof(CourierIndex));
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var data = _data.CourierDeliveries.Find(Id);
            if (data == null)
            {
                return NotFound();
            }


            return View(data);
        }
     
     
        
        public IActionResult Delete(int? id)
        {
            var data = _data.CourierDeliveries.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            _data.CourierDeliveries.Remove(data);

            _data.SaveChanges();

            return RedirectToAction(nameof(CourierIndex));
        }
    }
}
