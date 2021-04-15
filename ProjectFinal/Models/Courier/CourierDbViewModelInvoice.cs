using ProjectFinal.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.Courier
{
    public class CourierDbViewModelInvoice
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int CourierDbViewModelId { get; set; }
        public CourierDbViewModel CourierDbViewModel { get; set; }
    }
}
