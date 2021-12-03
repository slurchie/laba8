using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace methodichka
{
    class BankAccount
    {
        public enum account { incorrect, saving, current };
        private Queue<bankTransaction> bankTransactions = new Queue<bankTransaction>();
        private int number;
        private account type;
        private decimal balance;
        private static int num = 1;
        public BankAccount()
        {

        }
        public BankAccount(decimal balance, account type)
        {
            this.balance = balance;
            this.type = type;
            IncreaseNum();
        }
        public BankAccount(decimal balance)
        {
            this.balance = balance;
            IncreaseNum();
        }
        public BankAccount(account type)
        {
            this.type = type;
            IncreaseNum();
        }
        public void Dispose(string file)
        {
            StreamWriter stream = new StreamWriter(file);
            foreach (bankTransaction item in bankTransactions)
            {
                stream.WriteLine(item.ToString());
            }
            stream.Close();
            GC.SuppressFinalize(stream);

        }
        public void PutItOnTheAccount(decimal temp)
        {
            bankTransaction bankT = new bankTransaction(temp);
            balance += temp;
            bankTransactions.Enqueue(bankT);
        }
        public void WithdrawFromTheAccount(decimal temp)
        {

            if (temp <= balance)
            {
                balance -= temp;
                bankTransaction bankT = new bankTransaction(temp);
                bankTransactions.Enqueue(bankT);
            }
            else if (temp > balance)
            {
                Console.WriteLine("Недостаточно средств");
            }
            else
            {
                Console.WriteLine("Ошибка при вводе баланса");
            }
        }
        public void IncreaseNum()
        {
            number = num++;
        }
        public void Print()
        {
            Console.WriteLine($"Account number: {number}" + $"\n balance: {balance}" + $" \ntype: {type}");
        }
        public void GetBank_Account()
        {
            Console.WriteLine("Введите баланс:");
            bool result = decimal.TryParse(Console.ReadLine(), out decimal temp1);
            if (result)
            {
                balance = temp1;
            }
            else
            {
                Console.WriteLine("Ошибка при вводе баланса");
            }
            Console.WriteLine("Выберите тип счета: saving или current\nВведите 1 или 2");
            result = Int32.TryParse(Console.ReadLine(), out int temp);
            switch (temp)
            {
                case 1:
                    type = account.saving;
                    break;
                case 2:
                    type = account.current;
                    break;
                default:
                    Console.WriteLine("Нужно вводить только 1 или 2");
                    break;
            }
        }
        public void Transfer(BankAccount from, decimal sum)
        {
            if (sum <= from.balance)
            {
                from.WithdrawFromTheAccount(sum);
                PutItOnTheAccount(sum);
            }
            else
            {
                Console.WriteLine("не получается");
            }

        }
    }
}
   