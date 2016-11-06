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
        public const int NUM_GENES = 260;
        public readonly byte[] Genes = new byte[NUM_GENES];
        public int Chips { get; set; }

        public Player()
        {
            Random r = new Random();
            r.NextBytes(Genes);
        }

        public Player(Player parent1, Player parent2) : this()
        {
            for(int i = 0; i < NUM_GENES; i++)
            {
                byte b1 = parent1.Genes[i];
                byte b2 = parent2.Genes[i];
                this.Genes[i] = (byte)(((b1 ^ b2) & this.Genes[i]) | (b1 & b2));
            }
        }

        public Plays GetPlay(IEnumerable<Card> hand, Card dealerShowing, Plays possiblePlays)
        {
            BlackJackScore score = new BlackJackScore(hand);
            if (score.Score < 12) return Plays.Hit;
            return Plays.Stand;
        }

    }
}
