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
            table.Seats[0].Player = new Player();
            table.Seats[2].Player = new Player();
            table.Seats[3].Player = new Player();


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}\n", table.PlayHand());
            }
        }
    }
}
