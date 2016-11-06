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
        public static int GetPointValue(Rank rank)
        {
            switch (rank)
            {
                case Rank.Ace:
                    return 11;
                case Rank.Ten:
                case Rank.Jack:
                case Rank.Queen:
                case Rank.King:
                    return 10;
                default:
                    return (int)rank;
            }
        }

        public int Score;
        public bool IsSoft;

        public BlackJackScore(IEnumerable<Card> cards)
        {
            Score = 0;
            IsSoft = false;

            bool noAces = true;
            foreach (var rank in cards.Select(c => c.Rank))
            {
                Score += GetPointValue(rank);
                if (rank == Rank.Ace)
                {
                    if (noAces)
                    {
                        IsSoft = true;
                        noAces = false;
                    }
                    else
                    {
                        // 2nd ace; only counts 1
                        Score -= 10;
                    }
                }
            }
            if ((Score > 21) && IsSoft)
            {
                Score -= 10;
                IsSoft = false;
            }
        }

        public BlackJackScore(Card card)
        {
            Score = GetPointValue(card.Rank);
            IsSoft = (card.Rank == Rank.Ace);
        }

        public bool IsBlackjack
        {
            get { return (Score == 21 && IsSoft == true); }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", Score, IsSoft ? " soft":string.Empty);
        }
    }
}
