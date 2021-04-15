using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectFinal.Models.Courier;
using ProjectFinal.Models.Invoices;
using ProjectFinal.Models.MakeOrder;
using ProjectFinal.Models.PanelPage;
using ProjectFinal.Models.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class DbPassportUserModel : IdentityUser
    {
        

        public int SeriaNumber { get; set; }
        public string Citizenship { get; set; }

        public DateTime BirthdayDate { get; set; }
        public string Sex { get; set; }
        public string FinCode { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CustomerNumber { get; set; }




        public List<Invoice> Invoices { get; set; }
        public List<AccountBalanceViewModel> AccountBalanceViewModels { get; set; }
        public List<CourierDbViewModel> CourierDbViewModels { get; set; }
        public List<UserTransaction> Transactions { get; set; }
        public List<LinkOrder> Orders { get; set; }
      




    }
}
