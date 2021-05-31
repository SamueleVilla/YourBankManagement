using BankLibrary.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankLibrary.Accounts
{
    [FirestoreData]
    public class BankAccount :  IBankAccount
    {
        private static int accountNumberSeed = 1234567890;
        private static readonly Random random = new Random(accountNumberSeed);
        // lista tracciante ogni transazione nell'account
        public List<TransactionModel> AllTransaction { get; set; } = new List<TransactionModel>();

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

        public UserModel Owner { get; set; }

        public string AccountNumeber { get; set; }

        // costruttore
        public BankAccount(UserModel owner, decimal initialBalance)
        {
            Owner = owner;
            AccountNumeber = (accountNumberSeed++).ToString();
            MakeDeposit(initialBalance, DateTime.Now, "bilancio iniziale");
        }


        // metodi deposito - prelievo //
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            // l'importo non può essere minore o uguale a 0
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "L'importo del deposito deve essere positivo!");
            }
            var deposit = new Models.TransactionModel(amount, DateTime.Now, note);
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
            var withDrawal = new Models.TransactionModel(-amount, date, note);
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
        
        public virtual void PerformMonthEndTransactions() { }

        public override string ToString()
        {
            return string.Format(
                $"{AccountNumeber}: {Owner} {Balance} EUR");
        }

    }
}