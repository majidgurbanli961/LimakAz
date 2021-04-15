using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<addressesabroad> Addressesabroads { get; set; }
        
    }
}
