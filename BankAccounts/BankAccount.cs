using BankAccounts.Models;
using System;
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

        // constructor 
        public BankAccount(User owner, decimal initialBalance)
        {
            _owner = owner;
            _balance = initialBalance;
            accountNumberSeed += new Random((int)accountNumberSeed).Next((int)accountNumberSeed);
            _accountNumber = accountNumberSeed.ToString();
        }

        // empty-constructor 
        public BankAccount() { }

        // properties
        public User Owner { get => _owner; private set => _owner = value; }
        public string AccountNumber { get => _accountNumber; }
        public decimal Balance { get => _balance; }


        // methods 
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

        }

        public void MakeWithDrawal(decimal amount, DateTime date, string note)
        {

        }

        public virtual string ToFileFormat()
        {
            return string.Format($"{Owner.ToFileFormat()},{AccountNumber},{Balance}");
        }

        public override string ToString()
        {
            return string.Format(
                $"{Owner.ToString()} {AccountNumber} {Balance}");
        }

    }
}