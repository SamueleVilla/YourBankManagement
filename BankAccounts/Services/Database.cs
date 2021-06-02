using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Services
{
    public static class Database
    {
        public static IBankAccount CurrentAccount { get; set; } = null;


        public static string GetAccountType(Type type)
        {
            if (type.ToString().Equals(AccountType.BankAccount.ToString()))
            {
                return "Conto Corrente";
            }
            if (type.Name.Equals(AccountType.EarningInterestAccount.ToString()))
            {
                return "Conto di Interesse";
            }
            if (type.Name.Equals(AccountType.CreditCardAccount.ToString()))
            {
                return "Carta di Credito";
            }
            if (type.Name.Equals(AccountType.GiftCardAccount.ToString()))
            {
                return "Carta Regalo";
            }
            else
                throw new Exception("Tipo non definito");
        }
    }
}
