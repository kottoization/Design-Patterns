using System;

namespace BankAccount_StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Account johnAccount = new Account("John");
            Account katieAccount = new Account("Katie");

            johnAccount.Deposit(38000);
            katieAccount.Deposit(4500);
            Console.WriteLine("-----TEST-----");
            Console.WriteLine("John's account type is " + johnAccount.AccountType.ToString());
            Console.WriteLine("Katie's account type is " + katieAccount.AccountType.ToString());
           
            Console.WriteLine("----WITHDRAW-----");
            Console.ReadKey();
            johnAccount.Withdraw(3000);

            Console.WriteLine("----WITHDRAW------");
            Console.ReadKey();
            johnAccount.Withdraw(20000);
            katieAccount.Withdraw(20000);

            Console.WriteLine("-----CHANGE-----");
            Console.ReadKey();
            johnAccount.ChangeAccountType();
            katieAccount.ChangeAccountType();

            Console.WriteLine("----WITHDRAW------");
            Console.ReadKey();
            johnAccount.Withdraw(10000);

            Console.WriteLine("----CHANGE------");
            Console.ReadKey();
            johnAccount.ChangeAccountType();

            Console.WriteLine("----WITHDRAW------");
            Console.ReadKey();
            johnAccount.Withdraw(10000);

            Console.WriteLine("----------");
            Console.ReadKey();
        }
    }
}
