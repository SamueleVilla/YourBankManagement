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
        public static FileManager DatabaseServices { get; } = new FileManager();

        
    }
}
