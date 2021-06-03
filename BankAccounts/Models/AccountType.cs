using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{  
    /// <summary>
    /// Questo tipo di enumrazione descrive tutti i tipi di account bancario disponibili
    /// </summary>
    public enum AccountType
    {
        BankAccount,
        CreditCardAccount,
        GiftCardAccount,
        EarningInterestAccount
    }
}