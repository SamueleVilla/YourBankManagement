using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    [FirestoreData]
    public enum AccountType
    {
        BankAccount,
        CreditCardAccount,
        GiftCardAccount,
        EarningInterestAccount
    }
}