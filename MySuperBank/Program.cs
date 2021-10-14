using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an Account
            var account = new BankAccount("Francesca",1000);
            // MakeWithdrawal
            account.MakeWithdrawal(120, new DateTime(2021, 10, 10), "Hammock");
            account.MakeWithdrawal(120, new DateTime(2021, 10, 12), "PS5");
            //MakeDeposit
            account.MakeDeposit(30, new DateTime(2021, 10, 12), "Work");
            //Impresiones
            Console.WriteLine($"Account {account.Number} was created for {account.Owner}, actual balance: {account.Balance} ");
            Console.WriteLine(account.GetAccountHistory());
            Console.WriteLine("-------------------");

            //Create an CheckingAccount
            var checkingAccount = new BankCheckingAccount("Valen", 50);
            // MakeWithdrawal
            checkingAccount.MakeWithdrawal(3000, new DateTime(2021, 10, 12), "Flores");
            checkingAccount.MakeWithdrawal(50, new DateTime(2021, 10, 13), "Water");
            //MakeDeposit
            checkingAccount.MakeDeposit(50, new DateTime(2021, 10, 12), "Work");
            //Impresiones
            Console.WriteLine($"CheckingAccount {checkingAccount.Number} was created for {checkingAccount.Owner}, actual balance: {checkingAccount.Balance}");
            Console.WriteLine(checkingAccount.GetAccountHistory());
            Console.WriteLine("-------------------");

            //Create an SavingsAccount
            var savingAccount = new BankSavingsAccount("Omar", 30000, 2100); //Nombre, saldo, limite diario.
            // MakeWithdrawal
            savingAccount.MakeWithdrawal(1000,new DateTime(2021, 10,10), "Bed");
            savingAccount.MakeWithdrawal(100, new DateTime(2021, 10, 11), "Flower");
            savingAccount.MakeWithdrawal(2000, new DateTime(2021, 10, 11), "Laptop");
            //MakeDeposit
            // savingAccount.MakeDeposit(2000,new DateTime(2021, 10, 11), "Work");
            //Impresiones
            Console.WriteLine($"SavingAccount {savingAccount.Number} was created for {savingAccount.Owner}, actual balance: {savingAccount.Balance}");
            Console.WriteLine(savingAccount.GetAccountHistory());
            Console.WriteLine("-------------------");


        }
    }
}
