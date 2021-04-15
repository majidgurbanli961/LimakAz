using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

using System.Security.Claims;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NETCore.MailKit.Core;

using ProjectFinal.Models;
using ProjectFinal.DataConnect;
using Microsoft.AspNetCore.Authorization;
using ProjectFinal.Models.PanelPage;

namespace ProjectFinal.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<DbPassportUserModel> user;
        private readonly SignInManager<DbPassportUserModel> signIn;
        private readonly IEmailService emailService;
        private readonly DbContextApp registerConnect;
        private readonly DbContextApp dbContext;

        public RegisterController(UserManager<DbPassportUserModel> user, SignInManager<DbPassportUserModel> signIn, IEmailService emailService, DbContextApp registerConnect, DbContextApp _dbContext)
        {
            this.user = user;
            this.signIn = signIn;
            this.emailService = emailService;
            this.registerConnect = registerConnect;
            this.dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUserSecond()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserSecond(PassportUserModel passportUser)
        {
            if (passportUser.agreeBox == false)
            {
                ModelState.AddModelError("agreeBox", "Zəhmət olmasa istifadəçi qaydaları ilə razı olun");
                return View(passportUser);



            }
            if (ModelState.IsValid)
            {
                DateTime lastDateTime = new DateTime(passportUser.Year, passportUser.Month, passportUser.Day);
                var howManyUsers = dbContext.Users.ToList();
                int customerid;
                if (howManyUsers.Count == 0)
                {
                    customerid = 10000000;
                }
                else
                {
                    customerid = dbContext.CustomUsers.Max(x => x.CustomerNumber)+1;
                }
                DbPassportUserModel finalUser = new DbPassportUserModel()
                {
                    UserName = passportUser.Email,
                    Email = passportUser.Email,
                    Name = passportUser.Name,
                    Surname = passportUser.Surname,
                    FinCode = passportUser.FinCode,
                    SeriaNumber = passportUser.SeriaNumber,
                    Sex = passportUser.Sex,
                    Address = passportUser.Address,
                    PhoneNumber = passportUser.MobilePhone,
                    BirthdayDate = lastDateTime,
                    CustomerNumber=customerid,
                    Citizenship=passportUser.Citizenship

                };
                var existedEmail = user.Users.FirstOrDefault(x => x.Email == finalUser.Email);
                var existedPhone = user.Users.FirstOrDefault(x => x.PhoneNumber == finalUser.PhoneNumber);
                var existedSeriaNumber = user.Users.FirstOrDefault(x => x.SeriaNumber == finalUser.SeriaNumber);
                var existedFinNumber = user.Users.FirstOrDefault(x => x.FinCode == finalUser.FinCode);
                if (existedEmail != null || existedPhone != null || existedSeriaNumber != null || existedFinNumber != null)
                {
                    if (existedEmail != null)
                    {
                        ModelState.AddModelError("Email", "Belə mail istifadə olunub");
                    }
                    if (existedPhone != null)
                    {
                        ModelState.AddModelError("MobilePhone", "Belə telefon nomrəsi istifadə olunub");
                    }
                    if (existedSeriaNumber != null)
                    {
                        ModelState.AddModelError("SeriaNumber", "Belə seriya nömrəsi nomrəsi istifadə olunub");
                    }
                    if (existedFinNumber != null)
                    {
                        ModelState.AddModelError("FinCode", "Belə Fin  nömrəsi nomrəsi istifadə olunub");
                    }


                }
                else
                {









                    var result = user.CreateAsync(finalUser, passportUser.Password).Result;
                    if (result.Succeeded)
                    {
                        await signIn.SignInAsync(finalUser, false);

                        var thResult = user.AddToRoleAsync(finalUser, "User").Result;
                        if (thResult.Succeeded)
                        {

                        }

                        
                        var signedBalanceUser = dbContext.CustomUsers.FirstOrDefault(x => x.UserName == finalUser.UserName);

                        AccountBalanceViewModel accountBalanceViewModel = new AccountBalanceViewModel()
                        {
                            AZNBalance = 0.00M,
                            TLBalance = 0.00M,
                            LastIncreasedAZNBalanceDate = DateTime.Now,
                            DbPassportUserModel = signedBalanceUser
                        };
                        dbContext.Balances.Add(accountBalanceViewModel);

                        dbContext.SaveChanges();




                        var code = await user.GenerateEmailConfirmationTokenAsync(finalUser);
                        var link = this.Url.ActionLink("EmailVerified", "Register", new { userId = finalUser.Id, code = code });
                        var message = new MimeMessage();
                        message.From.Add(new MailboxAddress("Limak", "limakazclone@gmail.com"));
                        message.To.Add(new MailboxAddress("Code academy", finalUser.Email));
                        message.Subject = "Test";
                        string customText = $"<a href={link}> Click Me<a/>";
                        var bodyBuilder = new BodyBuilder();
                        bodyBuilder.HtmlBody = $"<a href={link}> Click Me<a/>";

                        message.Body = bodyBuilder.ToMessageBody();


                        using (var client = new SmtpClient())
                        {
                            client.CheckCertificateRevocation = false;
                            client.Connect("smtp.gmail.com", 587, false);
                            client.Authenticate("limakazclone@gmail.com", "miko1999");
                            client.Send(message);
                        }
                        return RedirectToAction("PleaseVerify");

                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Parolda 1 boyuk herf 1 reqem ve 1 simvol olmalidir");

                    }

                }


            }
            return View(passportUser);
        }
        public async Task<IActionResult> EmailVerified(string userId, string code)
        {
            if(userId!=null && code != null)
            {

           

            var myuser = await user.FindByIdAsync(userId);
            var lastName = myuser.Name;
            var result = await user.ConfirmEmailAsync(myuser, code);
            if (result.Succeeded)
            {

                if (signIn.IsSignedIn(User) == true)
                {
                    var dalapresult = User.Identity.Name;
                }

            
              
                var isVerified = await user.IsEmailConfirmedAsync(myuser);
                ViewBag.IsVerified = isVerified;

                return View();


            }
            }
           


            return RedirectToAction("Error", "Home");

        }
        public IActionResult PleaseVerify()
        {

            var lastUser = User.Identity.Name;
            ViewBag.lastUser = lastUser;
            return View();
        }
        public IActionResult LogOut()
        {
            signIn.SignOutAsync();
            return RedirectToAction("SignIn");
        }
        public IActionResult SignIn(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!String.IsNullOrEmpty(returnUrl)){
                ViewBag.returnUrl = returnUrl;


            }
            else
            {
                ViewBag.returnUrl = "/";
                returnUrl = "/";
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel loginView,string returnUrl)
        {
           
            
            if (ModelState.IsValid)
            {

                var result = await signIn.PasswordSignInAsync(
                    loginView.Username,
                    loginView.Password,
                    loginView.RememberMe,
                    false);
                if (result.Succeeded)
                {
                    if (returnUrl == "/" || returnUrl==null)
                    {
                        return RedirectToAction("Index", "PanelPage");

                    }
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is not correct");
                }


            }
            ViewBag.returnUrl = returnUrl;

            return View(loginView);
        }
       
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPassportViewModel forgot)
        {
            if (ModelState.IsValid)
            {
                var customUser = await user.FindByEmailAsync(forgot.Email);
                if (customUser != null)
                {

                    var token = await user.GeneratePasswordResetTokenAsync(customUser);
                    var passwordResetLink = Url.Action("ResetPassword", "Register", new { email = forgot.Email, token = token }, Request.Scheme);
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Majid", "limakazclone@gmail.com"));
                    message.To.Add(new MailboxAddress("Code academy", customUser.Email));
                    message.Subject = "Registration";
                    message.Body = new TextPart("plain")
                    {
                        Text = passwordResetLink
                    };
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("limakazclone@gmail.com", "miko1999");
                        var bodyBuilder = new BodyBuilder();
                        bodyBuilder.HtmlBody = $"<a href={passwordResetLink}> Click Me<a/>";

                        message.Body = bodyBuilder.ToMessageBody();
                        client.Send(message);
                    }
                    return RedirectToAction("ForgotPasswordConfirmation");
                }
                ModelState.AddModelError("Email", "Belə mail yoxdur");



            }
            return View();

        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        public IActionResult ResetPassword(string email, string token)
        {
            if (email == null || token == null)
            {
                ModelState.AddModelError("", "Sehv token provide olunub");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel reset)
        {
            if (ModelState.IsValid)
            {
                var customuser = await user.FindByEmailAsync(reset.Email);
                var result = await user.ResetPasswordAsync(customuser, reset.Token, reset.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);


                }

            }
            return View(reset);
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public IActionResult CustomError()
        {
            return View();

        }
      
    }
}