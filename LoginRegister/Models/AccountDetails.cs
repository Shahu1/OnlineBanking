using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;


namespace LoginRegister.Models
{
    public class AccountDetails
    {

        [Key]
        public int UserId { get; set; }
        

        //This is for foreign key refrence
        [Display(Name = "AccountNumber")]
        public virtual int AccountNumber { get; set; }

        [ForeignKey("AccountNumber")]
        public virtual User User { get; set; }
        public Decimal Balance { get; set; }
         
        public int PayeeAccount { get; set; }

        


        



        

    }
}