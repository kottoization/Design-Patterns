using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount_StatePattern
{
    class JuniorAccountType : AccountType
    {
        protected const decimal withdrawLimit = 3000;

        protected const decimal serviceFee = 0;

        // Operacja wypłaty dla konta Junior
        //
        // Obiekt Account wywoła tę wersję metody Withdraw(),
        // jeśli znajdzie się w "stanie" VIPAccountType.
        public override void Withdraw(Account account, decimal amount)
        {
            if ((amount > withdrawLimit) || (account.Balance < amount + serviceFee))
            {
                Console.WriteLine("Withdrawal operation of {0} from Junior Account of {1} failed", amount, account.Owner);
                return;
            }

            account.Balance -= amount + serviceFee;
            Console.WriteLine("{0} was withdrowed from {1} Junior account", amount, account.Owner);
        }

        // Operacja zmiany rodzaju konta
        //
        // Obiekt Account wywoła tę wersję metody ChangeAccountType(),
        // jeśli znajdzie się w "stanie" StandardAccountState.
        public override void ChangeAccountType(Account account)
        {
            // jeśli saldo jest większe od 30000, konto Standard może być zmienione na VIP
            
                account.AccountType = new StandardAccountType();
                Console.WriteLine("{0} Junior account was changed to Standard", account.Owner);            
           
        }

    }
}
