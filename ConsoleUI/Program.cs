using BankAccounts.Models;
using BankAccounts;
using System;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //User currentUser = new User(
            //    new Name() { FirstName = "Samuele", LastName = "Villa" },
            //    DateTime.Now,
            //    "XEF1244DADFF"
            //    );

            //var account = new BankAccount(currentUser, 1000);
            //Console.WriteLine($"Account {account.AccountNumber} was created for {account.Owner.FullName} with {account.Balance} initial balance.");

            string path = System.IO.Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments), "BankManagement","Accounts");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
                Console.WriteLine("{0}",path);

            Console.ReadKey();
        }
    }
}