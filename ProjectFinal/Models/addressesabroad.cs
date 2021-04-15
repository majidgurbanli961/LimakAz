using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class addressesabroad
    {
        //Yeni
        public int Id { get; set; }
        public string AddressTitle { get; set; }
        public string AddressTitleTwo { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string TaxAdministration { get; set; }
        public string DistrictTwo { get; set; }
        public string ZIP { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string identityNumber { get; set; }


    }
}
