using System;

namespace BankLibrary.Models
{
   /// <summary>
   /// Questa classe descrrive il modello della transazione
   /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// Costruttore della classe 
        /// </summary>
        /// <param name="amount"> importo </param>
        /// <param name="date"> data importo </param>
        /// <param name="note"> nota dell'importo </param>
        public TransactionModel(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }

        /// <summary>
        /// Proprietà Importo della Trasazione
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Proprietà Data della Transazione
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Proprietà Nota della Tranasazione
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Proprietà Data in formato Stringa della Transazione
        /// </summary>
        public string DateString { get => Date.ToString(); }

        public Accounts.BankAccount BankAccount
        {
            get => default;
            set
            {
            }
        }
    }
}
