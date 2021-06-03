using BankLibrary.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    /// <summary>
    /// Questa classe descrive il modello dell utente
    /// </summary>
    public class UserModel
    {   
        /// <summary>
        /// Pprorietà Nome Utente
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Proprietà Nome Completo Utente
        /// </summary>
        public string FullName { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// Prprietà Cognome Utente
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Proprietà Data di Nascita Utente
        /// </summary>
        public DateTime BithDate { get; set; }

        /// <summary>
        /// Proprietà Codice Fiscale Utente
        /// </summary>
        public string TaxCode { get; set; }


        /// <summary>
        /// Questo metodo restituisce una rappresentazione in formato stringa dell oggetto UserModel
        /// </summary>
        /// <returns>
        /// Il metodo ritorna un valore di tipo Stringa
        /// </returns>
        public override string ToString()
        {
            return string.Format(
                $"{FirstName} " +
                $"{LastName} " +
                $"{BithDate.ToShortDateString()} " +
                $"{TaxCode}"
                );
        }
    }
}