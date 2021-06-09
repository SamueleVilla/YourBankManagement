using BankLibrary.Models;
using System;
using System.Collections.Generic;

namespace BankLibrary
{
    /// <summary>
    /// Questa interfaccia firma i metodi e proprietà implementati nella classe BankAccount
    /// </summary>
    public interface IBankAccount
    {
        /// <summary>
        /// Proprietà Modello Utente dell'account
        /// </summary>
        UserModel Owner { get; set; }

        /// <summary>
        /// Proprietà Bilancio dell'account
        /// </summary>
        decimal Balance { get; }

        /// <summary>
        /// Proprietà TotaleDepositi dell'account
        /// </summary>
        decimal TotalDeposits { get; }

        /// <summary>
        /// Proprietà Totale Prelievi dell'account
        /// </summary>
        decimal TotalDrawals { get; }

        /// <summary>
        /// Proprietà che tiene traccia di tutte le transazioni effettuate dall'account
        /// </summary>
        List<TransactionModel> AllTransactions { get; set; }

        /// <summary>
        /// Proprietà Deposito Mesile dell'account
        /// </summary>
        decimal MonthlyDeposit { get; set; }

        /// <summary>
        /// Questo metodo permette di effetuare un prelievo 
        /// </summary>
        /// <param name="amount"> Importo </param>
        /// <param name="date"> Data Importo </param>
        /// <param name="note"> Nota Importo </param>
        void MakeWithDrawal(decimal amount, DateTime date, string note);

        /// <summary>
        /// Questo metodo permette di effettuare un deposito
        /// </summary>
        /// <param name="amount"> Importo</param>
        /// <param name="date"> Data Importo</param>
        /// <param name="note"> Nota Importo</param>
        void MakeDeposit(decimal amount, DateTime date, string note);

        /// <summary>
        /// Questo metodo effettua un oprazione a fine mese che dipende dal tipo di account
        /// </summary>
        virtual void PerformMonthEndTransactions() { }

        /// <summary>
        /// Questo metodo restituisce una cronologia di tutte le transazioni effettutate
        /// </summary>
        /// <returns> Il metodo ritorna un stringa</returns>
        string GetAccountHistory();
    }
}