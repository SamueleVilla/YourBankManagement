using BankLibrary.Accounts;
using BankLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

// Account con Linea di credito
// Una linea di credito può avere un saldo negativo, ma quando è presente un saldo,
// viene addebitato un addebito degli interessi ogni mese.

//Può avere un saldo negativo, ma non essere maggiore in valore assoluto del limite di credito.
//Verrà addebitato un addebito degli interessi ogni mese in cui il saldo di fine mese non è 0.
//Verrà incorsa una tariffa per ogni prelievo che va oltre il limite di credito.

namespace BankLibrary.Accounts
{
    public class CreditCardAccount : BankAccount
    {

        public CreditCardAccount(UserModel owner, decimal initialBalance) : base(owner, initialBalance)
        { }

        public CreditCardAccount() { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // negazione del saldo corrente per aver un prelievo positivo
                var interest = -Balance * 0.07m;
                MakeWithDrawal(interest, DateTime.Now, "Prelievo Interesse mesile");
            }
        }
    }
}
