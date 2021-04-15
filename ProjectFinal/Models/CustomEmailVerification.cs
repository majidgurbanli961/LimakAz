using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectFinal.DataConnect;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class CustomEmailVerification : Attribute, IActionFilter
    {

        

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var contextApp = context.HttpContext.RequestServices.GetService<DbContextApp>();
            var customUserName = context.HttpContext.User.Identity.Name;
            if (contextApp.CustomUsers.FirstOrDefault(x => x.UserName == customUserName).EmailConfirmed == false)
            {
                context.Result = new RedirectResult("/register/pleaseverify");


            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }


      

    }
}
