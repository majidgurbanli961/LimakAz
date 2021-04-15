using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class Questions
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Baslıq Yazmalısız")]
        public string Header{ get; set; }
        [Required(ErrorMessage = "Metn Yazmalısız")]


        public string Body { get; set; }
    }
}
