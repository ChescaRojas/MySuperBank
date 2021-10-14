using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public partial class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public TransactionType Type { get; }

        public Transaction(decimal amount, DateTime date, string note, TransactionType move)
        {
            Amount = amount;
            Date = date;
            Notes = note;
            Type = move;

        }
    }
    public enum TransactionType
    {
        Withdraw,
        Deposit
    }
    public static class Extensions
    {
        public static string GetMessage(this TransactionType type)
        {
            if (type == TransactionType.Withdraw)
            {
                return "Extration";
            }
            else { return "Deposit"; }
        }
    }
}
