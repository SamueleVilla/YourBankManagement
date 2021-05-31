using BankLibrary.Models;
using BankLibrary.Accounts;
using System;
using System.IO;
using System.Collections.Generic;
using BankLibrary;
using System.Threading.Tasks;


namespace ConsoleUI
{
    class Program
    {
       
        static void Main(string[] args)
        {
            try
            {
               UserModel user = new UserModel { FirstName = "Sam", LastName = "Villa", BithDate = DateTime.Parse("30/12/2003"), TaxCode = "VLLSML03T3089N" };
               UserModel userB = new UserModel { FirstName = "Matt", LastName = "GRC", BithDate = DateTime.Parse("30/12/2003"), TaxCode = "VLLSML03T3089N" };
               IBankAccount bankAccount = new CreditCardAccount(user, 500);
               IBankAccount account = new EarningInsterestAccount(user, 500);

                Console.WriteLine(bankAccount.ToString());
                Console.WriteLine(bankAccount.GetAccountHistory());

                Console.WriteLine();
                Console.WriteLine(account.ToString());
                Console.WriteLine(account.GetAccountHistory());
                

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