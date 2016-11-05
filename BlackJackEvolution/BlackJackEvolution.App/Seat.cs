using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesQMurphy.PlayingCards;

namespace BlackJackEvolution.App
{
    public class Seat
    {
        public readonly IList<Card> Hand = new List<Card>();
        public readonly IList<Card> SplitHand = new List<Card>();
        public Player Player { get; set; }
        public bool IsEmpty
        {
            get { return Player == null; }
        }
    }
}
