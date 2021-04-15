using Microsoft.AspNetCore.Identity;
using ProjectFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Areas.Admin.Models
{
    public class SuperAdminViewModel
    {
        public List<DbPassportUserModel> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
