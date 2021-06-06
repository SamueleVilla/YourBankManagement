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

        /// <summary>
        /// Questo metodo effettua il prelievo mensile per la classe CreditCardAccount
        /// </summary>
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // negazione del saldo corrente per aver un prelievo positivo
                var interest = -Balance * 0.07m;
                MakeWithDrawal(Math.Round(interest,2), DateTime.Now, "Prelievo Interesse mesile");
            }
        }

        /// <summary>
        /// Questo metodo restituisce una tassa di transazione qual'ora il prelievo fosse maggiore del bilancio corrente
        /// </summary>
        /// <param name="isOverdrawn"> Condizione bilancio scoperto </param>
        /// <returns> IL metodo restiuisce una TransactionModel #Nullable </returns>
        protected override TransactionModel? CheckWithDrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                //applicare tassa previlevo per bilancio scoperto
                return new TransactionModel(-20, DateTime.Now, "Applicata tassa per fondi insufficienti");
            }
            else
            {
                return default;
            }
        }
    }
}
