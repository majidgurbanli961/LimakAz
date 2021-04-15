using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class RulesAccardion
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Basliq Elave Edin")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Metn Elave Edin")]
        public string Body { get; set; }
    }
}
