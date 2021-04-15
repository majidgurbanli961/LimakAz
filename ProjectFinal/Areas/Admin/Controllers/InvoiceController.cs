using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.DataConnect;
using ProjectFinal.Models.Invoices;

using Microsoft.EntityFrameworkCore;
namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin,Moderator")]

    public class InvoiceController : Controller
    {
        private readonly DbContextApp _data;

        public InvoiceController(DbContextApp data)
        {
            //Yeni
            _data = data;
          
        }
        public IActionResult InvoiceIndex()
        {
            var data = _data.Invoices.Include(x => x.DbPassportUserModel).OrderByDescending(x => x.id).ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult InvoiceIndex(string search)
        {

            ViewData["Get"] = search;
            var query = from x in _data.Invoices.Include(x => x.DbPassportUserModel).OrderByDescending(x => x.id) select x;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.DbPassportUserModel.CustomerNumber.ToString().Contains(search.ToLower()) || x.DbPassportUserModel.UserName.ToLower().Contains(search.ToLower()));
            }

            return View(query.ToList());

        }


        public IActionResult Delete(int? id)
        {
            var data = _data.Invoices.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            _data.Invoices.Remove(data);

            _data.SaveChanges();

            return RedirectToAction(nameof(InvoiceIndex));
        }



        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.Invoices.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, Invoice invoice)
        {

            if (!ModelState.IsValid)
            {
                return View(invoice);
            }

            var data = _data.Invoices.Find(invoice.id);
            if (data != null)
            {
                data.InvoiceStatus = invoice.InvoiceStatus;
                data.InvoiceProductWeight = invoice.InvoiceProductWeight;
                data.DeliveryMoney = invoice.DeliveryMoney;
                data.StoreName = invoice.StoreName;
                data.InvoiceProductType = invoice.InvoiceProductType;
                data.InvoiceProductPrice = invoice.InvoiceProductPrice;
                data.InvoiceProductAmount = invoice.InvoiceProductAmount;
                data.InvoiceDate = invoice.InvoiceDate;
           

                _data.SaveChanges();
            }

            return RedirectToAction(nameof(InvoiceIndex));
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }


            var data = _data.Invoices.Find(Id);



            if (data == null)
            {
                return NotFound();
            }


            return View(data);
        }

    }
}
