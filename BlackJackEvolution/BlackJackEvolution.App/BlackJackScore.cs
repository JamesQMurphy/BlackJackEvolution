using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesQMurphy.PlayingCards;

namespace BlackJackEvolution.App
{
    public struct BlackJackScore
    {
        public int Score;
        public bool IsSoft;

        public BlackJackScore(IEnumerable<Card> cards)
        {
            Score = 0;
            IsSoft = false;

            bool noAces = true;
            foreach (var rank in cards.Select(c => c.Rank))
            {
                switch (rank)
                {
                    case Rank.Ace:
                        if (noAces)
                        {
                            IsSoft = true;
                            noAces = false;
                            Score += 11;
                        }
                        else
                        {
                            Score += 1;
                        }
                        break;

                    case Rank.Ten:
                    case Rank.Jack:
                    case Rank.Queen:
                    case Rank.King:
                        Score += 10;
                        break;

                    default:
                        Score += (int)rank;
                        break;
                }
            }
            if ( (Score > 21) && IsSoft )
            {
                Score -= 10;
                IsSoft = false;
            }

        }

        public override string ToString()
        {
            return string.Format("{0}{1}", Score, IsSoft ? " soft":string.Empty);
        }
    }
}
