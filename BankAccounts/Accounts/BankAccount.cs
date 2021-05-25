using BankLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankLibrary.Accounts
{
    public class BankAccount
    {
        private static readonly long accountNumberSeed = 1234567890;
        private static readonly Random random = new Random((int)accountNumberSeed);

        // class fields
        private User _owner;
        private string _accountNumber;
        private readonly decimal _balance;

        // constructor 
        public BankAccount(User owner, decimal initialBalance)
        {
            _owner = owner;
            _balance = initialBalance;
            _accountNumber = (accountNumberSeed + random.Next()).ToString(); // generazione numero account univoco

            MakeDeposit(initialBalance, DateTime.Now, "Importo iniziale");
        }

        // empty-constructor 
        public BankAccount() { }

      
        // properties
        public User Owner { get => _owner;  set => _owner = value; }

        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transaction in AllTransaction)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }

        // lista tracciante ogni transazione nell'account
        public List<Transaction> AllTransaction { get; set; } = new List<Transaction>();


        // metodi deposito - prelievo //
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            // l'importo non può essere minore o uguale a 0
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "L'importo del deposito deve essere positivo!");
            }
            var deposit = new Transaction(amount, DateTime.Now, note);
            AllTransaction.Add(deposit);
        }

        public void MakeWithDrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "L'importo del prelievo deve essere positivo!");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("Non ci sono fondi sufficienti per questo prelievo!");
            }
            var withDrawal = new Transaction(-amount, date, note);
            AllTransaction.Add(withDrawal);
        }

        public string GetAccountHistory()
        {
            var builder = new StringBuilder();
            decimal balance = 0;

            foreach (var transaction in AllTransaction)
            {
                balance += transaction.Amount;
                builder.AppendLine($"{transaction.Amount}\t{transaction.Date}\t{transaction.Note}");
            }
            return builder.ToString();
        }

        // metodi virtuali //
        public virtual void PerformMonthEndTransactions() { }

        public override string ToString()
        {
            return string.Format(
                $"{AccountNumber}: {Owner} {Balance} EUR");
        }

    }
}