using BankLibrary.Models;
using BankLibrary.Accounts;
using System;
using System.IO;
using System.Collections.Generic;
using BankLibrary;
using System.Threading.Tasks;
using BankLibrary.Services;

namespace ConsoleUI
{
    class Program
    {
       

        static void Main(string[] args)
        {
            try
            {
                UserModel user = new UserModel { FirstName = "Matteo", LastName = "Greco", BithDate = DateTime.Parse("27/01/2003"), TaxCode = "GRCMTT03DT896N" };
                IBankAccount bankAccount = new GiftCardAccount(user, 200.50m, 60);

                //bankAccount.MakeDeposit(10.5m, DateTime.Now, "vinto un bambino");
                //bankAccount.MakeDeposit(10.5m, DateTime.Now, "vinto un bambino");
                //bankAccount.MakeDeposit(12.52m, DateTime.Now, "perso un bambino");
                //bankAccount.MakeDeposit(12.78m, DateTime.Now, "perso un bambino");

                //Console.WriteLine(bankAccount.GetAccountHistory());
                //Database.DataBaseService.SaveAccountData(bankAccount);
                //Console.WriteLine("\nDati Salvati correctly");

                var current = Database.DataBaseService.LoadAccountData("GRCMTT03DT896N");
                current.MakeDeposit(11.56m, DateTime.Now, "deposito dopo caricamento");
                current.MakeWithDrawal(22.56m, DateTime.Now, "prelievo dopo caricamento");

                Database.DataBaseService.SaveAccountData(current);
                Console.WriteLine(current.GetAccountHistory());

            }
            catch (ArgumentOutOfRangeException e)
            {               
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {              
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }
    }
}