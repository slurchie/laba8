using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methodichka
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                BankAccount bank = new BankAccount();
                bank.PutItOnTheAccount(787878m);
                bank.Dispose("bankTransactions.txt");
            }
        }
    }
}
