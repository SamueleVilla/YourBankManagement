using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    [FirestoreData]
    public class TransactionModel
    {
       

        public TransactionModel(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            this.Date = date.ToUniversalTime();
            Note = note;
        }

        public TransactionModel() { }

        [FirestoreProperty]
        public decimal Amount { get; set; }
        [FirestoreProperty]
        public DateTime Date { get; set; }
        [FirestoreProperty]
        public string Note { get; set; }


    }
}
