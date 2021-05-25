using BankLibrary.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    public class User
    {
        private Name _fullName;
        private DateTime _birthDate;
        private string _taxCode;

        // constructor
        public User(Name fullName, DateTime birthDate, string taxCode)
        { 
            if (!(string.IsNullOrEmpty(fullName.FirstName) || string.IsNullOrEmpty(fullName.LastName)))
            {
                _fullName = fullName;
            }
            else
            {
                throw new Exception("Il nome o il cognome inserito non è valido!");
            }
                
            if (taxCode.Length == 16)
            {
                _taxCode = taxCode;
            }
            else
            {
                throw new Exception("Il codice fiscale non è valido [16 cifre]");
            }

            // un utente minorenne non può apripre un conto bancario
            if (DateTime.Now.Year - birthDate.Year >= 18)
            {
                _birthDate = birthDate;
            }
            else
            {
                throw new Exception("L'utente deve avere almeno 18 anni per aprire un conto bancario!");
            }
        }

        // empty-constructor
        public User() { }

        // properties
        public Name UserName { get => _fullName; set => _fullName = value; }
        //public string FullName { get => string.Format($"{_fullName.FirstName} {_fullName.LastName}"); }
        public DateTime? BirthDate { get => _birthDate; }
        public string TaxCode { get => _taxCode; }

        public override string ToString()
        {
            return string.Format($"{UserName.FullName} : {BirthDate.Value.Date.ToShortDateString()} {TaxCode}");
        }

    }
}