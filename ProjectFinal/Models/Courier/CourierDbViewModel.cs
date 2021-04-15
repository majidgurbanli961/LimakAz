using ProjectFinal.Models.Invoices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.Courier
{
    public class CourierDbViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int? DeliveredStatus { get; set; }

        public int AddressOfDelivery { get; set; }

        [Required(ErrorMessage = "Rayon qeyd olunmalıdır")]
        [StringLength(70)]
        public string District { get; set; }

        [StringLength(70)]
        public string Village { get; set; }

        [Required(ErrorMessage = "Küçə qeyd olunmalıdır")]
        [StringLength(70)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Ev qeyd olunmalıdır")]
        [StringLength(70)]
        public string House { get; set; }

        [Required(ErrorMessage = "Nömrənizi qeyd edin")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string InvoiceComments { get; set; }


        public DbPassportUserModel DbPassportUserModel { get; set; }
        public string DbPassportUserModelId { get; set; }

        //public Invoice Invoice { get; set; }
        //public int InvoiceId { get; set; }

        public ICollection<CourierDbViewModelInvoice> CourierDbViewModelInvoices { get; set; } = new List<CourierDbViewModelInvoice>();
    }
}
