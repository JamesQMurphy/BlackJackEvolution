using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesQMurphy.PlayingCards
{
    public class Card
    {
        public readonly Rank Rank;
        public readonly Suit Suit;
        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", this.Rank, this.Suit);
        }
    }
}
