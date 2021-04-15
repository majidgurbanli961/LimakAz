using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.Courier
{
    public class EditCourierViewModel
    {
        public int CourierId { get; set; }
        public int AddressOfDelivery { get; set; }

        [Required(ErrorMessage = "Rayon qeyd olunmalıdır")]
        [StringLength(70, ErrorMessage = "Maximal uzunluq 70 herf olmalidir")]
        public string District { get; set; }

        [StringLength(70, ErrorMessage = "Maximal uzunluq 70 herf olmalidir")]
        public string Village { get; set; }

        [Required(ErrorMessage = "Küçə qeyd olunmalıdır")]
        [StringLength(70, ErrorMessage = "Maximal uzunluq 70 herf olmalidir")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Ev qeyd olunmalıdır")]
        [StringLength(70, ErrorMessage = "Maximal uzunluq 70 herf olmalidir")]
        public string House { get; set; }

        [Required(ErrorMessage = "Nömrənizi qeyd edin")]
        [StringLength(15, ErrorMessage = "Maximal uzunluq 15 reqem olmalidir")]
        public string PhoneNumber { get; set; }

        [StringLength(500, ErrorMessage = "Maximal uzunluq 500 herf olmalidir")]
        public string InvoiceComments { get; set; }
    }
}
