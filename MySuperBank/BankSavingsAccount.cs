using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySuperBank
{
    public class BankSavingsAccount : BankAccount
    {
        public decimal DayLimit { get; private set; }
        public BankSavingsAccount(string name, int initialBalance, decimal dayLimit) : base(name, initialBalance)
        {
            DayLimit = dayLimit;
        }
        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

         decimal withdred = Math.Abs(allTransactions.FindAll(t => t.Type == TransactionType.Withdraw && t.Date.Date == date.Date).Sum(x => x.Amount));

           // Console.WriteLine($"withdred ={withdred}");

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal.");
            }
            else if (DayLimit < amount + withdred)
            {
                throw new InvalidOperationException("You have reached your daily limit.");
            }

            ExecuteWithdrawal(-amount, date, note);
        }

    }

}
