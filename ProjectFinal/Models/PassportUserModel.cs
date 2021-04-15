using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models
{
    public class PassportUserModel
    {

        [Required(ErrorMessage ="Seria nömrəsini daxil etmək vacibdir")]
        public int SeriaNumber { get; set; }
        [Required(ErrorMessage = "Vətəndaşlıq daxil etmək vacibdir")]


        public string Citizenship { get; set; }
        [Required(ErrorMessage = "Doğum günü daxil etmək daxil etmək vacibdir")]



        public DateTime BirthdayDate { get; set; }
        [Required(ErrorMessage = "Cinsi daxil etmək vacibdir")]


        public string Sex { get; set; }
        [Required(ErrorMessage = "Fin code daxil etmək vacibdir")]


        public string FinCode { get; set; }
        [Required(ErrorMessage = "Address daxil etmək vacibdir")]


        public string Address { get; set; }
        [Required(ErrorMessage = "Ad daxil etmək vacibdir")]


        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad daxil etmək vacibdir")]


        public string Surname { get; set; }
        [Required(ErrorMessage = "Email daxil etmək vacibdir")]


        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobil telefonu daxil etmək vacibdir")]


        [Phone]
        [RegularExpression(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|
2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|
4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$", ErrorMessage = "Nomre Standartlara cavab vermelidir")]
        public string MobilePhone { get; set; }
        [Required(ErrorMessage = "Parol daxil etmək vacibdir")]


        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Parol təstiqi daxil etmək vacibdir")]


        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Gün daxil etmək vacibdir")]

        public int Day { get; set; }
        [Required(ErrorMessage = "Ay daxil etmək vacibdir")]

        public int Month { get; set; }
        [Required(ErrorMessage = "İl daxil etmək vacibdir")]

        public int Year { get; set; }
        public bool agreeBox { get; set; }
    }
}
