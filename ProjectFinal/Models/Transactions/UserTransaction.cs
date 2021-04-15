using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.Transactions
{
    public class UserTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyType { get; set; }


        public DbPassportUserModel DbPassportUserModel { get; set; }
        public string DbPassportUserModelId { get; set; }

    }
}
