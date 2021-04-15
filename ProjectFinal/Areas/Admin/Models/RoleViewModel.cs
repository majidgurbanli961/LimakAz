using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Areas.Admin.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }
        public void Test()
        {

        }
    }
}
