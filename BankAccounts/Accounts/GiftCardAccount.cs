using BankLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

//Un account della carta da regalo:
//Può essere riempito con un importo specificato una volta al mese, l'ultimo giorno del mese.

namespace BankLibrary.Accounts
{
    public class GiftCardAccount : BankAccount
    {
        public GiftCardAccount(User owner, decimal initialBalance) : base(owner, initialBalance)
        {
            
        }
    }
}
