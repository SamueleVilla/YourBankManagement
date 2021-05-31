using BankLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public interface IBankAccount
    {
        UserModel Owner { get; set; }

        string AccountNumeber { get; set; }

        decimal Balance { get; }

        List<TransactionModel> AllTransaction { get; set; }

        void MakeWithDrawal(decimal amount, DateTime date, string note);

        void MakeDeposit(decimal amount, DateTime date, string note);

        virtual void PerformMonthEndTransactions() { }

        string GetAccountHistory();
    }
}