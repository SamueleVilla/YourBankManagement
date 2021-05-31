using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
   
    public class TransactionModel
    {
       

        public TransactionModel(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            this.Date = date.ToUniversalTime();
            Note = note;
        }

        public TransactionModel() { }

        
        public decimal Amount { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Note { get; set; }


    }
}
