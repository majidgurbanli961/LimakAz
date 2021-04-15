using ProjectFinal.Models.Courier;
using ProjectFinal.Models.Invoices;
using ProjectFinal.Models.MakeOrder;
using ProjectFinal.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.PanelPage
{
    public class IndexDataViewModels
    {
        //Yeni
        public Rootobject rootobject { get; set; }
        public List<Invoice> Invoices { get; set; }
        public AccountBalanceViewModel accountBalanceViewModel { get; set; }
        public List<CourierDbViewModel> courierDbViewModels { get; set; }
        public List<UserTransaction> Transactions { get; set; }
        public List<LinkOrder> Orders { get; set; }

        //==================== MODELS FOR FORM SUBMIT
        public EditInvoice EditInvoice { get; set; }
        public CreateCourierViewModel createCourierViewModel { get; set; }
        public EditCourierViewModel editCourierViewModel { get; set; }
        public List<addressesabroad> addressesabroad { get; set; }
        public EditLinkOrder editLinkOrder { get; set; }
        //==================== MODELS FOR FORM SUBMIT
    }
}
