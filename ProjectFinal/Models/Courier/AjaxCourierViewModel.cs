using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.Courier
{
    public class AjaxCourierViewModel
    {
        public int id { get; set; }

        public int AddressOfDelivery { get; set; }

        public string District { get; set; }

        public string Village { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string PhoneNumber { get; set; }

        public string InvoiceComments { get; set; }
    }
}