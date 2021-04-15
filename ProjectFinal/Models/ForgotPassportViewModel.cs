using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class ForgotPassportViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
