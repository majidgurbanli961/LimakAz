using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectFinal.DataConnect;
using ProjectFinal.Models.MakeOrder;
using Microsoft.EntityFrameworkCore;
namespace ProjectFinal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin,Moderator")]

    public class OrdersController : Controller
    {
        private readonly DbContextApp _data;

        public OrdersController(DbContextApp data)
        {
      
            _data = data;

        }
        public IActionResult OrdersIndex()
        {
            var data = _data.Orders.Include(x => x.DbPassportUserModel).OrderByDescending(x => x.id).ToList();

            return View(data);
        }


        [HttpGet]
        public IActionResult OrdersIndex(string search)
        {

            ViewData["Get"] = search;
            var query = from x in _data.Orders.Include(x => x.DbPassportUserModel).OrderByDescending(x => x.id) select x;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.DbPassportUserModel.CustomerNumber.ToString().Contains(search.ToLower()) || x.DbPassportUserModel.UserName.ToLower().Contains(search.ToLower()));
            }

            return View(query.ToList());

        }


        public IActionResult Delete(int? id)
        {
            var data = _data.Orders.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            _data.Orders.Remove(data);

            _data.SaveChanges();

            return RedirectToAction(nameof(OrdersIndex));
        }



        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var des = _data.Orders.Find(Id);
            if (des == null)
            {
                return NotFound();
            }

            return View(des);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, LinkOrder orders)
        {

            if (!ModelState.IsValid)
            {
                return View(orders);
            }

            var data = _data.Orders.Find(orders.id);
            if (data != null)
            {
                data.OrderStatus = orders.OrderStatus;
                data.OrderProductWeight = orders.OrderProductWeight;
                data.DeliveryMoney = orders.DeliveryMoney;
                data.CompanyName = orders.CompanyName;
                data.OrderStatus = orders.OrderStatus;
                data.OrderLink = orders.OrderLink;
                data.ProductAmount = orders.ProductAmount;
                data.ProductPrice = orders.ProductPrice;


                _data.SaveChanges();
            }

            return RedirectToAction(nameof(OrdersIndex));
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var data = _data.Orders.Find(Id);
            if (data == null)
            {
                return NotFound();
            }


            return View(data);
        }

    }
}
