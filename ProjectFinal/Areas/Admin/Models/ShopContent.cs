using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Areas.Admin.Models
{
    public class ShopContent
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string CustomText { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public void Test()
        {

        }


    }
}
