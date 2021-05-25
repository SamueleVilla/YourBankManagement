using BankAccounts.Models;
using BankAccounts.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankAccounts
{
    public class BankAccount
    {
        private static long accountNumberSeed = 1234567890;

        // class fields
        private User _owner;
        private string _accountNumber;
        private decimal _balance;
        private List<Transaction> allTransactions;

        // constructor 
        public BankAccount(User owner, decimal initialBalance)
        {
            _owner = owner;
            _balance = initialBalance;
            _accountNumber = (accountNumberSeed += new Random().Next((int)accountNumberSeed)).ToString();

            allTransactions = new List<Transaction>();
            allTransactions.Add(new Transaction()
            {
                Amount = initialBalance,
                Date = DateTime.Now,
                Note = "Aggiunto importo iniziale"
            });
        }

        // empty-constructor 
        public BankAccount() { }

        // properties
        public User Owner { get => _owner;  set => _owner = value; }
        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public decimal Balance { get => _balance; set => _balance = value; }


        // methods 
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

        }

        public void MakeWithDrawal(decimal amount, DateTime date, string note)
        {

        }

        public virtual string ToFileFormat()
        {
            return string.Format($"{Owner.ToFileFormat()};{AccountNumber};{Balance}");
        }

        public virtual void SaveData()
        {
            using StreamWriter sw = File.CreateText($@"{Database.AccountsPath}\{AccountNumber}.csv");
            sw.WriteLine(ToFileFormat());
        }

        public override string ToString()
        {
            return string.Format(
                $"{Owner.ToString()} {AccountNumber} {Balance}");
        }

    }
}