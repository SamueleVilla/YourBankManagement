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
        public decimal MontlyDeposit { get; set; }

        public GiftCardAccount(UserModel owner, decimal initialBalance,decimal  monthlyDeposit = 0) : base(owner, initialBalance)
        {
            MontlyDeposit = monthlyDeposit;
        }

        public override void PerformMonthEndTransactions()
        
        {
            if(MontlyDeposit != 0)
            {
                MakeDeposit(MontlyDeposit, DateTime.Now, "Aggiunto deposito mensile");
            }
        }
    }
}
