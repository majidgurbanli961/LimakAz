
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.MakeOrder
{
    public class EditLinkOrder
    {
        public int OrderId { get; set; }

        [StringLength(500)]
        public string OrderComment { get; set; }

        [Required]
        public int DeliveryAddress { get; set; }
    }
}