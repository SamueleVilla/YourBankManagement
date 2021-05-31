using BankLibrary.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Models
{
    
    public class UserModel
    {   
        
        public string FirstName { get; set; }

        
        public string FullName { get => $"{FirstName} {LastName}"; }

        
        public string LastName { get; set; }

        
        public DateTime BithDate { get; set; }

        
        public string TaxCode { get; set; }
      

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