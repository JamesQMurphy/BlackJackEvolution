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
        public const byte USABLE_GENES_MASK = 0x1F;
        public readonly byte[] Genes = new byte[NUM_GENES];
        public int Chips { get; set; }

        public Player(bool randomize)
        {
            if (randomize)
            {
                CryptoRandom.Generator.NextBytes(Genes);
            }
        }

        public Player(Player parent1, Player parent2) : this(false)
        {
            for(int i = 0; i < NUM_GENES; i++)
            {
                byte b1 = parent1.Genes[i];
                byte b2 = parent2.Genes[i];
                this.Genes[i] = (byte)(((b1 ^ b2) & this.Genes[i]) | (b1 & b2));
            }
        }

        public string Name { get; set; }

        public Plays GetPlay(IEnumerable<Card> hand, Card dealerShowing, Plays possiblePlays)
        {
            BlackJackScore score = new BlackJackScore(hand);
            BlackJackScore dealerScore = new BlackJackScore(dealerShowing);
            int index = GetGeneNumber(score, dealerScore);

            Plays willingPlays = (Plays)((byte)possiblePlays & Genes[index] & USABLE_GENES_MASK);

            if (willingPlays.HasFlag(Plays.Hit))
                return Plays.Hit;

            return Plays.Stand;
        }

        public void Mutate(int odds)
        {
            for ( int i = 0; i < NUM_GENES; i++)
            {
                if (0 == CryptoRandom.Generator.Next(odds))
                {
                    var bitNumber = CryptoRandom.Generator.Next(8);
                    Genes[i] = (byte)(Genes[i] ^ (1 << bitNumber));
                    Console.WriteLine("Mutation! Player {0} Gene {1} Bit{2}", Name, i, bitNumber);
                }
            }
        }

        private int GetGeneNumber(BlackJackScore score, BlackJackScore dealerShowing)
        {
            // Four is the lowest non-soft hand
            // If hand is soft, add 8 (number of non-soft hands, minus offset)
            int p = score.Score - 4 + (score.IsSoft ? 8 : 0);
            return (p * 10) + dealerShowing.Score - 2;
        }
    }
}
