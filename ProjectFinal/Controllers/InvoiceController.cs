using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFinal.DataConnect;
using ProjectFinal.Models;
using ProjectFinal.Models.Invoices;

namespace ProjectFinal.Controllers
{
    [Authorize]
    [CustomEmailVerification]
    public class InvoiceController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly SignInManager<DbPassportUserModel> signInManager;
        private readonly DbContextApp dbContext;
        private string SignedUserName = "";
        private DbPassportUserModel user = null;

        public InvoiceController(IWebHostEnvironment webHost, SignInManager<DbPassportUserModel> _signInManager, DbContextApp _dbContext)
        {
            this._webHost = webHost;
            this.signInManager = _signInManager;
            this.dbContext = _dbContext;
        }


        //================================================== CREATE INVOICE
        public IActionResult CreateInvoice()
        {
            return View();
        }



        //================================================ CREATE INVOICE FOR TRY
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(CreateInvoiceViewModel createInvoiceViewModel)
        {
            if (ModelState.IsValid)
            {
                if (signInManager.IsSignedIn(User) == true)
                {
                    SignedUserName = User.Identity.Name;
                    user = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == SignedUserName);
                }

                Invoice invoice = new Invoice()
                {
                    StoreName = createInvoiceViewModel.StoreName,
                    InvoiceProductType = createInvoiceViewModel.InvoiceProductType,
                    InvoiceProductAmount = createInvoiceViewModel.InvoiceProductAmount,
                    InvoiceProductPrice = createInvoiceViewModel.InvoiceProductPrice,
                    InvoiceFollowCode = createInvoiceViewModel.InvoiceFollowCode,
                    DeliveryOffice = createInvoiceViewModel.DeliveryOffice,
                    InvoiceDate = createInvoiceViewModel.InvoiceDate,
                    InvoiceComments = createInvoiceViewModel.InvoiceComments,
                    InvoiceProductWeight = null,
                    DeliveryMoney = null,
                    InvoiceTime = DateTime.Now.ToString("HH:mm"),
                    InvoiceStatus = 1,
                    InvoiceCountryIndex = createInvoiceViewModel.InvoiceCountryIndex,
                    DbPassportUserModel = user
                };

                if (invoice.InvoiceDate == null)
                {
                    invoice.InvoiceDate = DateTime.Now;
                }

                if (dbContext.Invoices.Count() > 0)
                {
                    invoice.InvoiceNumber = dbContext.Invoices.Max(x => x.InvoiceNumber) + 1;
                }
                else
                {
                    invoice.InvoiceNumber = 1;
                }

                //======================================== If there is any image submitted then this image is added to folder
                if (createInvoiceViewModel.FormFile != null)
                {
                    var nameOfImage = Path.GetFileNameWithoutExtension(createInvoiceViewModel.FormFile.FileName);
                    var extensionOfImage = Path.GetExtension(createInvoiceViewModel.FormFile.FileName);
                    var guid = Guid.NewGuid();

                    var newFileName = nameOfImage + guid + extensionOfImage;


                    var rootPath = Path.Combine(_webHost.WebRootPath, "Invoice", "InvoiceGallery", newFileName);

                    using (var fileStream = new FileStream(rootPath, FileMode.Create))
                    {
                        createInvoiceViewModel.FormFile.CopyTo(fileStream);
                    }

                    invoice.FileName = newFileName;
                }


                dbContext.Invoices.Add(invoice);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "PanelPage");
            }

            return View();
        }





        //================================================== CREATE INVOICE
        public IActionResult CreateInvoiceUSA()
        {
            return View();
        }



    }
}