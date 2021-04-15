using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.MakeOrder
{
    public class LinkOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(500)]
        public string OrderLink { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int ProductAmount { get; set; }

        [StringLength(500)]
        public string OrderComment { get; set; }

        [Required]
        public int PaymentMethod { get; set; }

        [Required]
        public int DeliveryAddress { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public int OrderStatus { get; set; }

        public string CompanyName { get; set; }
        public int? OrderNumber { get; set; }
        public decimal? OrderProductWeight { get; set; }
        public decimal? DeliveryMoney { get; set; }

        public DbPassportUserModel DbPassportUserModel { get; set; }
        public string DbPassportUserModelId { get; set; }
    }
}
