using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySuperBank
{
    class BankCheckingAccount : BankAccount
    {
        public decimal CreditLimit { get;private set; }
        public BankCheckingAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
            CreditLimit = 3000;
        }
        public override void MakeWithdrawal(decimal amount, DateTime date, string note)

        {
            if (Balance + CreditLimit - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            ExecuteWithdrawal(-amount, date, note);
        }
    }
}
