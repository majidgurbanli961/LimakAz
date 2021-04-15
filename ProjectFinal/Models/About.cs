using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class About
    {

        public int Id { get; set; }
        

        public string Image { get; set; }
        //[Required]
       
        
        public string BodyText { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
