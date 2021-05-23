using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccounts.Models
{
    public class User
    {
        private Name _fullName;
        private DateTime? _birthDate;
        private string _taxCode;

        // constructor
        public User(Name fullName, DateTime? birthDate, string taxCode)
        {


            if (!(string.IsNullOrEmpty(fullName.FirstName) || string.IsNullOrEmpty(fullName.LastName)))
            {
                _fullName = fullName;
            }
            else
                throw new Exception("Il nome o il cognome inserito non è valido!");

            if (!(taxCode.Length < 16))
                _taxCode = taxCode;
            else
                throw new Exception("Il codice fiscale non è valido");

            // un utente minorenne non può apripre un conto bancario
            if (DateTime.Now.Year - birthDate.Value.Year >= 18)
            {
                _birthDate = birthDate;
            }
            else
                throw new Exception("L'utente deve avere almeno 18 anni per aprire un conto bancario!");
        }

        // empty-constructor
        public User() { }

        // properties
        public string FullName { get => string.Format($"{_fullName.FirstName} {_fullName.LastName}"); }
        public DateTime? BirthDate { get => _birthDate; set => _birthDate = value; }
        public string TaxCode { get => _taxCode; }

        public BankAccount BankAccount
        {
            get => default;
            set
            {
            }
        }

        public override string ToString()
        {
            return string.Format($"{FullName} : {BirthDate.Value.Date} {TaxCode}");
        }

        public string ToFileFormat()
        {
            return string.Format($"{_fullName.FirstName},{_fullName.LastName},{_birthDate.Value.ToString("dd/MM/yyyy")},{TaxCode}");
        }

    }
}