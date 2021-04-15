using Microsoft.AspNetCore.Http;
using ProjectFinal.Models.Courier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.Invoices
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string InvoiceProductType { get; set; }

        [Required]
        public int? InvoiceProductAmount { get; set; }

        [Required]
        public decimal? InvoiceProductPrice { get; set; }

        [Required]
        public string InvoiceFollowCode { get; set; }

        [Required]
        public int DeliveryOffice { get; set; }

        public DateTime? InvoiceDate { get; set; }

        [StringLength(500)]
        public string InvoiceComments { get; set; }

        public string FileName { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }


        public int? InvoiceNumber { get; set; }
        public decimal? InvoiceProductWeight { get; set; }
        public decimal? DeliveryMoney { get; set; }
        public string InvoiceTime { get; set; }
        [Required]
        public int InvoiceStatus { get; set; }
        [Required]
        public int InvoiceCountryIndex { get; set; }

        public DbPassportUserModel DbPassportUserModel { get; set; }
        public string DbPassportUserModelId { get; set; }

        //public List<CourierDbViewModel> CourierDbViewModels { get; set; }

        public ICollection<CourierDbViewModelInvoice> CourierDbViewModelInvoices { get; set; } = new List<CourierDbViewModelInvoice>();
    }
}
