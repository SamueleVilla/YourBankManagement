using BankLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankLibrary.Accounts
{    
    public class BankAccount :  IBankAccount
    {
       
        public List<TransactionModel> AllTransactions { get; set; } = new List<TransactionModel>(); 

        public decimal Balance
        {
            get
            {
                return AllTransactions.Sum(t => t.Amount);
            }
        }

        public UserModel Owner { get; set; }

        public decimal MonthlyDeposit { set; get; } = 0;

        public decimal TotalDeposits
        {
            get
            {
                var deposits = AllTransactions.Where(t => t.Amount > 0).ToList();
                return deposits.Sum(t => t.Amount);
            }
        }

        public decimal TotalDrawals
        {
            get
            {
                var drawals = AllTransactions.Where(t => t.Amount < 0).ToList();
                return drawals.Sum(t => t.Amount);
            }
        }

        /// <summary>
        /// Costruttore della classe BankAccount
        /// </summary>
        /// <param name="owner"> Utente Proprietario </param>
        /// <param name="initialBalance"> Bilancio iniziale </param>
        public BankAccount(UserModel owner, decimal initialBalance)
        {
            Owner = owner;
            MakeDeposit(initialBalance, DateTime.Now, "bilancio iniziale");
        }

        public BankAccount () { }
     
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            // l'importo non può essere minore o uguale a 0
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "L'importo del deposito deve essere positivo!");
            }
            var deposit = new Models.TransactionModel(amount, DateTime.Now, note);
            AllTransactions.Add(deposit);
        }

        public void MakeWithDrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "L'importo del prelievo deve essere positivo!");
            }
            var overDrawfTransaction = CheckWithDrawalLimit(Balance - amount < 0);
            var withDrawal = new Models.TransactionModel(-amount, date, note);
            AllTransactions.Add(withDrawal);

            if(overDrawfTransaction != null)
            {
                AllTransactions.Add(overDrawfTransaction);
            }
        }

        /// <summary>
        /// Questo metodo verifica se l'importo della transazione è negativo
        /// </summary>
        /// <param name="isOverdrawn"> condizione di bilancio scoperto </param>
        /// <returns> Il metodo restiuisce una TransactionModel #Nullable </returns>
        protected virtual TransactionModel? CheckWithDrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Non ci sono fondi sufficienti per questo prelievo!");               
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Questo metodo restituisce una rappresentazione in stringa di utte le trasazioni effettuate dall'account
        /// </summary>
        /// <returns></returns>
        public string GetAccountHistory()
        {
            var builder = new StringBuilder();
            decimal balance = 0;

            foreach (var transaction in AllTransactions)
            {
                balance += transaction.Amount;
                builder.AppendLine($"{transaction.Amount}\t{transaction.Date}\t{transaction.Note}");
            }
            return builder.ToString();
        }
        
        /// <summary>
        /// Questo metodo esegue un operazione di fine mese suul'account
        /// </summary>
        public virtual void PerformMonthEndTransactions() { }

        /// <summary>
        /// Questo metodo restituisce una rappresentazione in stringa dell'oggetto BankAccount
        /// </summary>
        /// <returns> Il metodo ritorna una stringa </returns>
        public override string ToString()
        {
            return string.Format(
                $"{Owner.TaxCode}: {Owner} {Balance} EUR");
        }

    }
}