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

            Simulation s = new Simulation();
            s.Start();

            //Table table = new Table(5);
            //table.Seats[0].Player = new Player();
            //table.Seats[2].Player = new Player();
            //table.Seats[3].Player = new Player();

            //// Give them chips
            //table.Seats[0].Player.Chips = table.Bet * 100;
            //table.Seats[2].Player.Chips = table.Bet * 100;
            //table.Seats[3].Player.Chips = table.Bet * 100;

            //for (int i = 0; i < 500; i++)
            //{
            //    Console.WriteLine("{0}\n", table.PlayHand());
            //}
        }
    }
}
