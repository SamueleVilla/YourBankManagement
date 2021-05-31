using BankLibrary.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Firestore;

namespace BankLibrary.Models
{
    [FirestoreData]
    public class UserModel
    {   
        [FirestoreProperty]
        public string FirstName { get; set; }

        [FirestoreProperty]
        public string FullName { get => $"{FirstName} {LastName}"; }

        [FirestoreProperty]
        public string LastName { get; set; }

        [FirestoreProperty]
        public DateTime BithDate { get; set; }

        [FirestoreProperty]
        public string TaxCode { get; set; }

        public BankAccount BankAccount
        {
            get => default;
            set
            {
            }
        }

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