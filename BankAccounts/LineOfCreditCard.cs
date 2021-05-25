using BankAccounts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccounts
{
    public class LineOfCreditCard : BankAccount
    {
        public LineOfCreditCard(User owner, decimal initialBalance) : base(owner,initialBalance) { }
    }
}
