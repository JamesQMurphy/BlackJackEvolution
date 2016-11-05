using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesQMurphy.PlayingCards;
using BlackJackEvolution.App;

namespace BlackJackEvolution.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            Table table = new Table(5);
            table.Players[0] = new Player();
            table.Players[2] = new Player();
            table.Players[3] = new Player();


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}\n", table.PlayHand());
            }
        }
    }
}
