using BankAccounts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BankAccounts.Utils
{
    public class Database
    {
        public static string AccountsPath { get; } = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BankManagement", "Accounts");

        public static void SetAccount(BankAccount bankAccount)
        {
            using(StreamWriter sw = File.CreateText($@"{AccountsPath}\{bankAccount.AccountNumber}.csv"))
            {
                sw.WriteLine(bankAccount.ToFileFormat());               
            }          
        }

        public static BankAccount GetAccount(string path)
        {
            string header = new StreamReader(path).ReadLine();

            //header line --> [0]
            var entries = header.Split(';');
            BankAccount account = new BankAccount(
                new User(
                    new Name() { FirstName = entries[0], LastName = entries[1] },
                    DateTime.Parse(entries[2]),
                    entries[3]),
                decimal.Parse(entries[5]));
            account.AccountNumber = entries[4];

            return account;                
        }

    }
}
