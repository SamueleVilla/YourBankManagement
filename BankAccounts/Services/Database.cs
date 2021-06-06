using BankLibrary.Accounts;
using BankLibrary.Models;
using System;

namespace BankLibrary.Services
{
    public static class Database
    {
        /// <summary>
        /// Proprietà Account Corrente
        /// </summary>
        public static IBankAccount CurrentAccount { get; set; } = null;

        /// <summary>
        /// Proprità per il servize di lettura e scrittura su file
        /// </summary>
        public static FileManager DataBaseService { get; } = new FileManager();

        /// <summary>
        ///  Questo metodo restituisce il nome del tipo di account instanziato
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string DisplayAccountType(Type type)
        {
            AccountType result = (AccountType)Enum.Parse(typeof(AccountType), type.Name);
            switch (result)
            {
                case AccountType.BankAccount:
                    return "Conto Corrente";

                case AccountType.CreditCardAccount:
                    return "Carta di Credito";

                case AccountType.EarningInterestAccount:
                    return "Conto con Interesse";

                case AccountType.GiftCardAccount:
                    return "Carta Regalo";

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Tipo account non definito");
            }
        }

        /// <summary>
        /// Questo metodo istanzia l'account
        /// </summary>
        /// <param name="type"> Tipo di account selezionato </param>
        /// <param name="owner"> Proprietario dell'account</param>
        /// <param name="initialBalance"> Bilancio Iniziale</param>
        /// <param name="monthlyDeposit"> Deposito mensile </param>
        /// <returns> IL metodo ritorna l'istanza dell'account </returns>
        public static IBankAccount AccountInstantiation(AccountType type, UserModel owner, decimal initialBalance, decimal monthlyDeposit)
        {
            switch (type)
            {
                case AccountType.BankAccount:
                    return new BankAccount(owner, initialBalance);
                   
                case AccountType.CreditCardAccount:
                    return new CreditCardAccount(owner, initialBalance);
                    
                case AccountType.GiftCardAccount:
                    return new GiftCardAccount(owner, initialBalance, monthlyDeposit);

                case AccountType.EarningInterestAccount:
                    return new EarningInsterestAccount(owner, initialBalance);

                default:
                    throw new Exception("Impossibile creazione account");
            }
        }
    }
}
