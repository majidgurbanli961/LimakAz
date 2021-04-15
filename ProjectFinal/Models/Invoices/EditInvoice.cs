using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.Invoices
{
    public class EditInvoice
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Mağaza adı mütləq qeyd olunmalıdır.")]
        [Display(Name = "Mağaza adı")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Məhsul novü mütləq qeyd olunmalıdır.")]
        [Display(Name = "Bağlamadakı məhsulun növü")]
        public string InvoiceProductType { get; set; }

        [Required(ErrorMessage = "Məhsulun miqdari mütləq qeyd olunmalıdır.")]
        [Display(Name = "Bağlamadakı məhsulun sayı")]
        public int? InvoiceProductAmount { get; set; }

        [Required(ErrorMessage = "Məhsulun qiyməti mütləq qeyd olunmalıdır.")]
        [Display(Name = "Qiyməti")]
        public decimal? InvoiceProductPrice { get; set; }

        [Required(ErrorMessage = "Məhsulun izlənmə kodu mütləq qeyd olunmalıdır.")]
        [Display(Name = "Sifarişin izlənmə kodu")]
        public string InvoiceFollowCode { get; set; }

        public int DeliveryOffice { get; set; }


        [StringLength(500, ErrorMessage = "Qeyd üçün maximal hərf limiti 500-dür.")]
        [Display(Name = "Bağlamanıza aid qeydlərinizi yazın")]
        public string InvoiceComments { get; set; }

        public string FileName { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
