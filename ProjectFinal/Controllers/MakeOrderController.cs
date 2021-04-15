using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinal.DataConnect;
using ProjectFinal.Models;
using ProjectFinal.Models.MakeOrder;
using ProjectFinal.Models.Transactions;

namespace ProjectFinal.Controllers
{
    [Authorize]
    [CustomEmailVerification]
    public class MakeOrderController : Controller
    {
        private readonly SignInManager<DbPassportUserModel> signInManager;
        private readonly DbContextApp dbContext;
        private string SignedUserName = "";
        private DbPassportUserModel user = null;

        public MakeOrderController(SignInManager<DbPassportUserModel> _signInManager, DbContextApp _dbContext)
        {
            this.signInManager = _signInManager;
            this.dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User) == true)
            {
                SignedUserName = User.Identity.Name;
                user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
            }

            var userBalance = dbContext.Balances.FirstOrDefault(x => x.DbPassportUserModelId == user.Id);

            return View(userBalance);
        }


        public IActionResult CreateOrder(LinkOrder linkOrder)
        {
            if (ModelState.IsValid)
            {
                if (signInManager.IsSignedIn(User) == true)
                {
                    SignedUserName = User.Identity.Name;
                    user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);

                    //===================== GETS THE BALANCE OF SIGNED USER
                    var userBalance = dbContext.Balances.FirstOrDefault(x => x.DbPassportUserModelId == user.Id);
                    userBalance.TLBalance -= linkOrder.ProductPrice;
                    dbContext.SaveChanges();

                    //==================== ADDS TRANSACTION WHEN MONEY IS SPENT
                    UserTransaction userTransaction = new UserTransaction()
                    {
                        TransactionType = 2, //================ 1 for medaxil, 2 for mexaric
                        Amount = linkOrder.ProductPrice,
                        CurrencyType = 2, //=================== 1 for azn, 2 for try,
                        Date = DateTime.Now,
                        DbPassportUserModel = user
                    };
                    dbContext.Transactions.Add(userTransaction);
                    dbContext.SaveChanges();

                    LinkOrder dbLinkOrder = new LinkOrder()
                    {
                        OrderLink = linkOrder.OrderLink,
                        ProductPrice = linkOrder.ProductPrice,
                        ProductAmount = linkOrder.ProductAmount,
                        OrderComment = linkOrder.OrderComment,
                        DeliveryAddress = linkOrder.DeliveryAddress,
                        PaymentMethod = linkOrder.PaymentMethod,
                        DbPassportUserModel = user,
                        OrderDate = DateTime.Now,
                        OrderStatus = 10
                    };


                    if (dbContext.Orders.Count() > 0)
                    {
                        dbLinkOrder.OrderNumber = dbContext.Orders.Max(x => x.OrderNumber) + 1;
                    }
                    else
                    {
                        dbLinkOrder.OrderNumber = 1;
                    }


                    dbContext.Orders.Add(dbLinkOrder);
                    dbContext.SaveChanges();

                    return Json(new { redirectUrl = Url.Action("Index", "PanelPage") });
                }

            }

            return RedirectToAction("Index", "MakeOrder");
        }

    }
}