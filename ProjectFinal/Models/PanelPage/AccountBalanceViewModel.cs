using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.PanelPage
{
    public class AccountBalanceViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public decimal TLBalance { get; set; }

        [Required]
        public decimal AZNBalance { get; set; }

        [Required]
        public DateTime LastIncreasedAZNBalanceDate { get; set; }

        public DbPassportUserModel DbPassportUserModel { get; set; }
        public string DbPassportUserModelId { get; set; }
    }
}
