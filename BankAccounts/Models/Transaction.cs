using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccounts.Models
{
    public class Transaction
    {
        private decimal _amount;
        private DateTime date;
        private string _note;

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            this.Date = date;
            Note = note;
        }

        public Transaction() { }

        public decimal Amount { get => _amount; set => _amount = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Note { get => _note; set => _note = value; }
    }
}
