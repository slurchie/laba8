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

                //1.2
                Console.WriteLine("задание с песнями");
                List<Song> songs = new List<Song>(4);
                Song mySong = new Song();
                songs.Add(new Song("электрофорез", "зло")); //отправляем ссылку в конструктор, ссылаемся на пред песню
                songs.Add(new Song("максим", "ветром стать", songs[0]));
                songs.Add(new Song("лсп", "фокус", songs[1]));
                songs.Add(new Song("the nbrh", "daddy issues", songs[2]));
                foreach (Song s in songs)
                {
                    Console.WriteLine(s.Title());
                }
                if (songs[0].Equals(songs[1]))
                {
                    Console.WriteLine("=");
                }
            }
        }
    }
}
