using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LoginRegister.Models;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;

namespace LoginRegister.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        

        //This is for foreign key refrence
        [Display(Name = "AccountNumber")]
        public virtual int AccountNumber { get; set; }

        
        [ForeignKey("AccountNumber")]
        public virtual User User { get; set; }
        public int PayeeAccountNo { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public Decimal TransationAmount { get; set; }
        public string TransactionType { get; set; }

        [Required]
        public string TransactionDate { get; set; }

        public Decimal AccBalance { get; set; }

        public Decimal PayeeBalance { get; set; }   
    }

}