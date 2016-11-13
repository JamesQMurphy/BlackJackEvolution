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

            // This tests the random number generator

            //int slots = 23;
            //int[] hit = new int[slots];

            //for (int i = 0; i < 1000000; i++)
            //{
            //    int r = CryptoRandom.Generator.Next(slots);
            //    hit[r]++;
            //    //Console.WriteLine("{0}", r);
            //}

            //for (int i = 0; i < slots; i++)
            //    Console.WriteLine("Slot {0} had {1} hits", i, hit[i]);

        }
    }
}
