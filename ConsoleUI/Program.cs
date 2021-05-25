using BankLibrary.Models;
using BankLibrary.Accounts;
using System;
using System.IO;
using System.Collections.Generic;
using BankLibrary;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var account1 = new CreditCardAccount(
                new User(new Name { FirstName = "Samuele", LastName = "Villa" }, DateTime.Parse("30/12/2003"), "VLLSML03DT3089NA"),
                1000);

                var account2 = new CreditCardAccount(
                    new User(new Name { FirstName = "Matteo", LastName = "Greco" }, DateTime.Parse("21/02/2003"), "GRCMTT0923556AEA"),
                    500);

                var account3 = new CreditCardAccount(
                    new User(new Name { FirstName = "Andrea", LastName = "Ballarè" }, DateTime.Parse("21/02/2003"), "ADDCMTT0923556AE"),
                    1000);

                Console.WriteLine(account1.ToString());
                account1.MakeWithDrawal(750, DateTime.Now, "Pagamento del noleggio");
                account1.MakeDeposit(50, DateTime.Now, "Ho vinto un gratta e vinci");
                Console.WriteLine(account1.GetAccountHistory());

                Console.WriteLine();
                Console.WriteLine(account2.ToString());
                account2.MakeDeposit(200, DateTime.Now, "Ha vinto alle macchinette");
                account2.MakeWithDrawal(100, DateTime.Now, "Ogni tanto paga le tasse");
                Console.WriteLine(account2.GetAccountHistory());

                Console.WriteLine();
                Console.WriteLine(account3.ToString());
                account3.MakeDeposit(200, DateTime.Now, "Ha vinto alle macchinette");
                account3.MakeWithDrawal(100, DateTime.Now, "Ogni tanto paga le tasse");
                Console.WriteLine(account3.GetAccountHistory());

                Console.Read();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Eccezione generata creando un desposito negativo");
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Eccezione generata creando un desposito negativo");
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }
    }
}