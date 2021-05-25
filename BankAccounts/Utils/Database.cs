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
        // account aperto condiviso da tutte le classi
        public static BankAccount CurrentAccount { get; set; } = null;

        // path C:\Users\Documents\Bankmanagemet\Accounts
        public static string AccountsPath { get; } = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BankManagement", "Accounts");

        // filePath C:\Users\Documents\Bankmanagemet\Temp\lasOpenedAccount.txt
        public static string LastOpenedFilePath { get; set; } = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BankManagement", "Temp","lastOpenedAccount.txt");

        // path C:\Users\Documents\Bankmanagemet\Temp
        public static string LastOpenedPath { get; set; } = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BankManagement", "Temp");


        // carica account dal file
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
