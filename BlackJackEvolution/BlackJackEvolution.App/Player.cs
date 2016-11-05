using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesQMurphy.PlayingCards;

namespace BlackJackEvolution.App
{
    public class Player
    {
        public const int NUM_GENES = 350;

        public char[] Genes = new char[NUM_GENES];

        public Player()
        {
            Random r = new Random();
            for (int i = 0; i<NUM_GENES; i++)
            {
                switch(r.Next(3))
                {
                    case 0:
                        Genes[i] = 'S';
                        break;

                    case 1:
                        Genes[i] = 'H';
                        break;

                    case 2:
                        Genes[i] = 'D';
                        break;
                }
            }
        }

        public char GetPlay(IList<Card> playerHand, Card dealerShowing)
        {
            return 'S';
        }
    }
}
