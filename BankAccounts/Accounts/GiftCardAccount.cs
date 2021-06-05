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

        public GiftCardAccount(UserModel owner, decimal initialBalance, decimal monthlyDeposit = 0) : base(owner, initialBalance)
        {
            MonthlyDeposit = monthlyDeposit;
        }

        public GiftCardAccount() { }

        public override void PerformMonthEndTransactions()

        {
            if (MonthlyDeposit != 0)
            {
                MakeDeposit(MonthlyDeposit, DateTime.Now, "Aggiunto deposito mensile");
            }
        }
    }
}
