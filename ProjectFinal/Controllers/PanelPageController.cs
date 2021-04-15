using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectFinal.DataConnect;
using ProjectFinal.Models;
using ProjectFinal.Models.Courier;
using ProjectFinal.Models.Invoices;
using ProjectFinal.Models.MakeOrder;
using ProjectFinal.Models.PanelPage;
using ProjectFinal.Models.Transactions;

namespace ProjectFinal.Controllers
{
    [Authorize]
    [CustomEmailVerification]


    public class PanelPageController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<DbPassportUserModel> signInManager;
        private readonly UserManager<DbPassportUserModel> userManager;
        private readonly IWebHostEnvironment webHost;
        private readonly DbContextApp dbContext;
        private string SignedUserName = "";
        private DbPassportUserModel user = new DbPassportUserModel();

        public PanelPageController(RoleManager<IdentityRole> _roleManager, SignInManager<DbPassportUserModel> _signInManager, UserManager<DbPassportUserModel> userManager, DbContextApp _dbContext, IWebHostEnvironment _webHost)
        {
            this.roleManager = _roleManager;
            this.signInManager = _signInManager;
            this.userManager = userManager;
            this.dbContext = _dbContext;
            this.webHost = _webHost;
        }


        public IActionResult Index()
        {

            IndexDataViewModels indexDataViewModels = new IndexDataViewModels();

            //await createRolesandUsers();

            if (signInManager.IsSignedIn(User) == true)
            {
                SignedUserName = User.Identity.Name;
                user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
            }

            ViewBag.Name = user.Name;
            ViewBag.Surname = user.Surname;
            ViewBag.BirthdayYear = user.BirthdayDate.Year;
            ViewBag.BirthdayMonth = user.BirthdayDate.Month;
            ViewBag.BirthdayDay = user.BirthdayDate.Day;
            ViewBag.Email = user.Email;
            ViewBag.Phone = user.PhoneNumber;
            ViewBag.Sex = user.Sex;
            ViewBag.Seria = user.SeriaNumber;
            ViewBag.Fin = user.FinCode;
            ViewBag.Citizenship = user.Citizenship;
            ViewBag.Address = user.Address;
            ViewBag.CustomerCode = user.CustomerNumber;
            var addressTurkey = dbContext.Addressesabroads.FirstOrDefault(x => x.CountryId == 1);
            if (addressTurkey != null)
            {
                ViewBag.TrCity = addressTurkey.City;
                ViewBag.TrIlce = addressTurkey.District;
                ViewBag.TrSemt = addressTurkey.DistrictTwo;
                ViewBag.TrZip = addressTurkey.ZIP;
                ViewBag.TrUlke = "Turkey";
                ViewBag.TrKimlik = addressTurkey.identityNumber;
                ViewBag.TrCep = addressTurkey.PhoneNumber;
                ViewBag.TrVergiNumara = addressTurkey.TaxNumber;
                ViewBag.TrVergiAddress = addressTurkey.TaxAdministration;



            }
            else
            {
                ViewBag.TrCity = " ";
                ViewBag.TrIlce = " ";
                ViewBag.TrSemt = " ";
                ViewBag.TrZip = " ";
                ViewBag.TrUlke = " ";
                ViewBag.TrKimlik = " ";
                ViewBag.TrCep = " ";
                ViewBag.TrVergiNumara = " ";
                ViewBag.TrVergiAddress = " ";









            }
            var addressUsa= dbContext.Addressesabroads.FirstOrDefault(x => x.CountryId == 2);
            if (addressUsa != null)
            {

                ViewBag.TrCity = addressUsa.City;
                ViewBag.TrIlce = addressUsa.District;
                ViewBag.TrSemt = addressUsa.DistrictTwo;
                ViewBag.TrZip = addressUsa.ZIP;
                ViewBag.TrUlke = "Usa";
                ViewBag.TrKimlik = addressUsa.identityNumber;
                ViewBag.TrCep = addressUsa.PhoneNumber;
                ViewBag.TrVergiNumara = addressUsa.TaxNumber;
                ViewBag.TrVergiAddress = addressUsa.TaxAdministration;


            }



            Rootobject jsonToObject = GetCurrency();
            indexDataViewModels.rootobject = jsonToObject;

            var userInvoices = dbContext.Invoices.Where(x => x.DbPassportUserModelId == user.Id).ToList();
            userInvoices = userInvoices.OrderByDescending(x => x.InvoiceDate).ToList();
            indexDataViewModels.Invoices = userInvoices;

            var Balance = dbContext.Balances.FirstOrDefault(x => x.DbPassportUserModelId == user.Id);
            indexDataViewModels.accountBalanceViewModel = Balance;

            var userTransactions = dbContext.Transactions.Where(x => x.DbPassportUserModelId == user.Id).ToList();
            indexDataViewModels.Transactions = userTransactions;

            var userOrders = dbContext.Orders.Where(x => x.DbPassportUserModelId == user.Id).ToList();
            userOrders = userOrders.OrderByDescending(x => x.OrderDate).ToList();
            indexDataViewModels.Orders = userOrders;

            indexDataViewModels.courierDbViewModels = dbContext.CourierDeliveries.Include(x => x.CourierDbViewModelInvoices).ThenInclude(x => x.Invoice).Where(x => x.DbPassportUserModelId == user.Id).ToList();
            indexDataViewModels.addressesabroad = dbContext.Addressesabroads.Include(x=>x.Country).ToList();
            return View(indexDataViewModels);
        }

        //================================================= GETS XML API AND CONVERTS IT TO JSON THEN RETURNS DESERIALIZED JSON OBJECT
        private Rootobject GetCurrency()
        {
            var client = new HttpClient();

            var xmlResult = client.GetStringAsync("https://cbar.az/currencies/21.10.2020.xml").Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);

            string jsonString = JsonConvert.SerializeXmlNode(doc);

            Rootobject jsonToObject = JsonConvert.DeserializeObject<Rootobject>(jsonString);

            return jsonToObject;
        }

        //================================================= GETS XML API AND CONVERTS IT TO JSON THEN RETURNS THE JSON ITSELF (FOR AJAX)
        public ActionResult GetCurrencyCalculator()
        {
            var client = new HttpClient();

            var xmlResult = client.GetStringAsync("https://cbar.az/currencies/21.10.2020.xml").Result;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);

            string jsonString = JsonConvert.SerializeXmlNode(doc);

            return Content(jsonString);
        }


        //================================================= CREATES ROLE
        private async Task createRolesandUsers()
        {
            var role = new IdentityRole();
            role.Name = "User";
            await roleManager.CreateAsync(role);
        }




        //=============================================================== DELETE LINK ORDER
        public IActionResult DeleteLinkOrder(int id)
        {
            var order = dbContext.Orders.FirstOrDefault(x => x.id == id);
            dbContext.Remove(order);
            var result = dbContext.SaveChanges();

            var balance = dbContext.Balances.FirstOrDefault(x => x.DbPassportUserModelId == order.DbPassportUserModelId);
            balance.TLBalance += order.ProductPrice;
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }



        //=============================================================== EDIT LINK ORDER
        public IActionResult EditLinkOrder(EditLinkOrder editLinkOrder)
        {
            if (ModelState.IsValid)
            {
                var order = dbContext.Orders.FirstOrDefault(x => x.id == editLinkOrder.OrderId);

                order.OrderComment = editLinkOrder.OrderComment;
                order.DeliveryAddress = editLinkOrder.DeliveryAddress;

                dbContext.SaveChanges();

                var json = JsonConvert.SerializeObject(order);

                return Content(json);
            }
            return RedirectToAction("Error", "Home");
        }




        //=============================================================== DELETE ORDER
        public IActionResult DeleteOrder(int id)
        {
            var order = dbContext.Orders.FirstOrDefault(x => x.id == id);
            dbContext.Remove(order);
            var result = dbContext.SaveChanges();

            return RedirectToAction("Index");
        }




        //=============================================================== DELETE INVOICE
        public IActionResult DeleteInvoice(int id)
        {
            var invoice = dbContext.Invoices.FirstOrDefault(x => x.id == id);
            dbContext.Remove(invoice);
            var result = dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        //=============================================================== EDIT INVOICE
        [HttpPost]
        public async Task<IActionResult> EditInvoice(EditInvoice editInvoice)
        {
            if (ModelState.IsValid)
            {
                var dbInvoice = dbContext.Invoices.FirstOrDefault(x => x.id == editInvoice.id);

                if (!string.IsNullOrEmpty(editInvoice.StoreName)
                    && !string.IsNullOrEmpty(editInvoice.InvoiceProductType)
                    && (editInvoice.InvoiceProductAmount != 0 || editInvoice.InvoiceProductAmount != null)
                    && (editInvoice.InvoiceProductPrice != 0 || editInvoice.InvoiceProductPrice != null)
                    && !string.IsNullOrEmpty(editInvoice.InvoiceFollowCode))
                {
                    dbInvoice.StoreName = editInvoice.StoreName;
                    dbInvoice.InvoiceProductType = editInvoice.InvoiceProductType;
                    dbInvoice.InvoiceProductAmount = editInvoice.InvoiceProductAmount;
                    dbInvoice.InvoiceFollowCode = editInvoice.InvoiceFollowCode;
                    dbInvoice.DeliveryOffice = editInvoice.DeliveryOffice;
                    dbInvoice.InvoiceComments = editInvoice.InvoiceComments;
                    dbInvoice.InvoiceProductPrice = editInvoice.InvoiceProductPrice;
                }


                //======================================== If there is any image submitted then this image is added to folder
                if (editInvoice.FormFile != null)
                {
                    var nameOfImage = Path.GetFileNameWithoutExtension(editInvoice.FormFile.FileName);
                    var extensionOfImage = Path.GetExtension(editInvoice.FormFile.FileName);
                    var guid = Guid.NewGuid();

                    var newFileName = nameOfImage + guid + extensionOfImage;


                    var rootPath = Path.Combine(webHost.WebRootPath, "Invoice", "InvoiceGallery", newFileName);

                    using (var fileStream = new FileStream(rootPath, FileMode.Create))
                    {
                        editInvoice.FormFile.CopyTo(fileStream);
                    }

                    dbInvoice.FileName = newFileName;
                }

                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        //=============================================================== INCREASE BALANCE (FROM AJAX REQUEST)
        [HttpPost]
        public IActionResult IncreaseBalance(AccountBalanceViewModel accountBalanceViewModel)
        {
            if (signInManager.IsSignedIn(User) == true)
            {
                SignedUserName = User.Identity.Name;
                user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
            }

            var balance = dbContext.Balances.FirstOrDefault(x => x.DbPassportUserModelId == user.Id);
            balance.LastIncreasedAZNBalanceDate = DateTime.Now;
            balance.AZNBalance += accountBalanceViewModel.AZNBalance;
            dbContext.SaveChanges();


            UserTransaction userTransaction = new UserTransaction()
            {
                TransactionType = 1, //================ 1 for medaxil, 2 for mexaric
                Amount = accountBalanceViewModel.AZNBalance,
                CurrencyType = 1, //=================== 1 for azn, 2 for try,
                Date = DateTime.Now,
                DbPassportUserModel = user
            };
            dbContext.Transactions.Add(userTransaction);
            dbContext.SaveChanges();

            AccountBalanceViewModel sendData = new AccountBalanceViewModel()
            {
                AZNBalance = balance.AZNBalance,
                LastIncreasedAZNBalanceDate = balance.LastIncreasedAZNBalanceDate
            };

            var serializedBalance = JsonConvert.SerializeObject(sendData);
            return Content(serializedBalance);
        }

        //=============================================================== ADDS PACKAGES(DELIVERED INVOICES) TO COURIER DELIVERIES LIST (FROM AJAX REQUEST)
        public IActionResult AddCourierDeliveries(CreateCourierViewModel createCourierViewModel)
        {
            if (ModelState.IsValid)
            {
                if (createCourierViewModel.IdOfInvoice == 0)
                {
                    ModelState.AddModelError("IdOfInvoice", "Bağlama mütləq seçilməlidir");
                }
                else
                {
                    if (signInManager.IsSignedIn(User) == true)
                    {
                        SignedUserName = User.Identity.Name;
                        user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
                    }

                    var invoice = dbContext.Invoices.FirstOrDefault(x => x.id == createCourierViewModel.IdOfInvoice);

                    CourierDbViewModel courierDbViewModel = new CourierDbViewModel()
                    {
                        AddressOfDelivery = createCourierViewModel.AddressOfDelivery,
                        District = createCourierViewModel.District,
                        Village = createCourierViewModel.Village,
                        Street = createCourierViewModel.Street,
                        House = createCourierViewModel.House,
                        PhoneNumber = createCourierViewModel.PhoneNumber,
                        InvoiceComments = createCourierViewModel.InvoiceComments,
                        DeliveredStatus = 1,
                        DbPassportUserModel = user
                    };

                    CourierDbViewModelInvoice courierDbViewModelInvoice = new CourierDbViewModelInvoice()
                    {
                        Invoice = invoice,
                        CourierDbViewModel = courierDbViewModel
                    };


                    courierDbViewModel.CourierDbViewModelInvoices.Add(courierDbViewModelInvoice);

                    dbContext.CourierDeliveries.Add(courierDbViewModel);

                    dbContext.SaveChanges();


                    //==================== RETURN DATA TO AJAX REQUEST
                    var newlyAddedCourier = dbContext.CourierDeliveries.Where(x => x.DbPassportUserModelId == user.Id).ToList().Last();

                    AjaxCourierViewModel ajaxCourierViewModel = new AjaxCourierViewModel()
                    {
                        id = newlyAddedCourier.id,
                        District = newlyAddedCourier.District,
                        Village = newlyAddedCourier.Village,
                        Street = newlyAddedCourier.Street,
                        House = newlyAddedCourier.House,
                        InvoiceComments = newlyAddedCourier.InvoiceComments,
                        PhoneNumber = newlyAddedCourier.PhoneNumber,
                        AddressOfDelivery = newlyAddedCourier.AddressOfDelivery
                    };

                    var jsonObject = JsonConvert.SerializeObject(ajaxCourierViewModel);

                    return Content(jsonObject);
                }
            }

            return null;
        }


        //=============================================================== DELETE COURIER ORDER
        public IActionResult DeleteCourierOrder(int id)
        {
            var courier = dbContext.CourierDeliveries.FirstOrDefault(x => x.id == id);
            dbContext.Remove(courier);
            var result = dbContext.SaveChanges();

            return RedirectToAction("Index");
        }



        //=============================================================== EDIT COURIER ORDER
        public IActionResult EditCourierDelivery(EditCourierViewModel editCourier)
        {
            if (ModelState.IsValid)
            {
                var courier = dbContext.CourierDeliveries.FirstOrDefault(x => x.id == editCourier.CourierId);

                courier.District = editCourier.District;
                courier.Village = editCourier.Village;
                courier.Street = editCourier.Street;
                courier.House = editCourier.House;
                courier.PhoneNumber = editCourier.PhoneNumber;
                courier.InvoiceComments = editCourier.InvoiceComments;
                courier.AddressOfDelivery = editCourier.AddressOfDelivery;

                dbContext.SaveChanges();

                var json = JsonConvert.SerializeObject(courier);

                return Content(json);
            }
            return RedirectToAction("Error", "Home");
        }


        //=============================================================== DOWNLOAD EXCELL(.xlsx) FILE AZN
        public IActionResult DownloadExcell()
        {
            if (signInManager.IsSignedIn(User) == true)
            {
                SignedUserName = User.Identity.Name;
                user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
            }

            var Transactions = dbContext.Transactions.Where(x => x.DbPassportUserModelId == user.Id && x.CurrencyType == 1);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Transactions");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Əməliyyat";
                worksheet.Cell(currentRow, 2).Value = "Məbləğ";
                worksheet.Cell(currentRow, 3).Value = "Tarix";


                foreach (var transaction in Transactions)
                {
                    worksheet.Columns().AdjustToContents();//============= this line makes cell width larger rspect to its content
                    currentRow++;
                    if (transaction.TransactionType == 1)
                    {
                        worksheet.Cell(currentRow, 1).Value = "Mədaxil";
                    }
                    else if (transaction.TransactionType == 2)
                    {
                        worksheet.Cell(currentRow, 1).Value = "Məxaric";
                    }
                    worksheet.Cell(currentRow, 2).Value = transaction.Amount;
                    worksheet.Cell(currentRow, 3).Value = transaction.Date.ToString("dd/MM/yyyy HH:mm:ss");
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ƏməliyyatlarAZN.xlsx"
                        );
                }
            }
        }



        //=============================================================== DOWNLOAD EXCELL(.xlsx) FILE TL
        public IActionResult DownloadExcellTL()
        {
            if (signInManager.IsSignedIn(User) == true)
            {
                SignedUserName = User.Identity.Name;
                user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
            }

            var Transactions = dbContext.Transactions.Where(x => x.DbPassportUserModelId == user.Id && x.CurrencyType == 2);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Transactions");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Əməliyyat";
                worksheet.Cell(currentRow, 2).Value = "Məbləğ";
                worksheet.Cell(currentRow, 3).Value = "Tarix";


                foreach (var transaction in Transactions)
                {
                    worksheet.Columns().AdjustToContents();//============= this line makes cell width larger rspect to its content
                    currentRow++;
                    if (transaction.TransactionType == 1)
                    {
                        worksheet.Cell(currentRow, 1).Value = "Mədaxil";
                    }
                    else if (transaction.TransactionType == 2)
                    {
                        worksheet.Cell(currentRow, 1).Value = "Məxaric";
                    }
                    worksheet.Cell(currentRow, 2).Value = transaction.Amount;
                    worksheet.Cell(currentRow, 3).Value = transaction.Date.ToString("dd/MM/yyyy HH:mm:ss");
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ƏməliyyatlarTL.xlsx"
                        );
                }
            }
        }





        //================================================== CHANGE USER SETTINGS
        [HttpPost]
        public JsonResult ChangeSetting(string name, string surname, string office, string customDate, string email, string phone)
        {

            var customMyUser = userManager.Users.FirstOrDefault(x => x.Email == email);
            var isTelephone = userManager.Users.FirstOrDefault(x => x.PhoneNumber == phone && x.Email != email);
            if (isTelephone != null)
            {
                return Json("No");
            }
            customMyUser.PhoneNumber = phone;
            dbContext.SaveChanges();

            return Json("Yes");

        }
        [HttpPost]
        public JsonResult ChangePassword(string oldPass, string newPass, string newPassConfirm)
        {

            var userName = User.Identity.Name;
            var user = userManager.Users.FirstOrDefault(x => x.Email == userName);
            var result = userManager.ChangePasswordAsync(user, oldPass, newPass).Result;
            var errors = result.Errors.ToList();

            foreach (var error in errors)
            {
                if (error.Code == "PasswordMismatch")
                {
                    return Json(" Parol yanlishdir");

                }
                else
                {
                    return Json("Daxil etdiyiniz yeni parol struktura aid deyil ");

                }

            }

            return Json("Parolunuz ugurla deyishdirildi");
        }
        [HttpPost]
        public JsonResult ChangePersonalInfo(string email, string seriaNumber, string fin, string citizenship, string gender, string city)
        {
            var myuser = userManager.Users.FirstOrDefault(x => x.Email != email && x.SeriaNumber.ToString() == seriaNumber);
            if (myuser != null)
            {
                return Json("Bele seria nomreli ve ya fin nomreli istifadeci var");
            }
            var secondMyUser = userManager.Users.FirstOrDefault(x => x.Email == email);
            secondMyUser.SeriaNumber = Convert.ToInt32(seriaNumber);
            secondMyUser.FinCode = fin;
            secondMyUser.Citizenship = citizenship;
            secondMyUser.Sex = gender;
            secondMyUser.Address = city;
            dbContext.SaveChanges();
            return Json("Melumatlariniz deyishdirildi");
        }
    }
}
