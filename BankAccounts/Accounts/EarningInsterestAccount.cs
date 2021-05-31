using BankLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

// Un conto di interesse che accumula gli interessi alla fine di ogni mese.
// Otterrà un credito del 2% del saldo finale del mese.


namespace BankLibrary.Accounts
{
    public class EarningInsterestAccount : BankAccount
    {
        public EarningInsterestAccount(UserModel owner, decimal initialBalance) : base(owner, initialBalance)
        { }

        public override void PerformMonthEndTransactions()
        {
            // se il bilancio è maggiore di 500 applico l interesse
            if (Balance >= 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "Depositato interesse mensile");
            }
        }
    }
}

