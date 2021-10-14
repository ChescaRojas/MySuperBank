using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        public List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            MakeDeposit(initialBalance,new DateTime(2021, 10, 8), "I.B");
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public virtual void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note, TransactionType.Deposit);
            allTransactions.Add(deposit);
        }

        public virtual void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            ExecuteWithdrawal(-amount, date, note);
        }

        protected void ExecuteWithdrawal(decimal amount, DateTime date, string note)
        {
            var withdrawal = new Transaction(amount, date, note, TransactionType.Withdraw);
            allTransactions.Add(withdrawal);
        }

        public virtual string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\tNote\tType of process");
            
            foreach (var item in allTransactions)
            {
             
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}\t{item.Type.GetMessage()}"); 

            }
            return report.ToString();
        }


       
    }
}