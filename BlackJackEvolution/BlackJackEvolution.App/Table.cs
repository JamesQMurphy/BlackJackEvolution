using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesQMurphy.PlayingCards;

namespace BlackJackEvolution.App
{
    public class Table
    {
        public const int DEALER_STANDS_ON = 17;

        private readonly Deck _deck = new Deck(CardSets.BlackJack);
        private readonly List<Card> _dealerHand = new List<Card>();
        public readonly Seat[] Seats;

        public int Size
        {
            get { return Seats.Length; }
        }

        public Table(int size)
        {
            _deck.Shuffle();
            Seats = new Seat[size];
            for (int i = 0; i < size; i++)
                Seats[i] = new Seat();
        }

        public string PlayHand()
        {
            // TODO: create enumerator/delegate to enumerate over non-null players

            StringBuilder sb = new StringBuilder();

            // Clear the table
            _dealerHand.Clear();
            foreach (var seat in Seats)
            {
                seat.Hand.Clear();
                seat.SplitHand.Clear();
            }

            // Reshuffle if necessary
            if (_deck.UndealtCount * 4 < _deck.Count)
            {
                _deck.GatherAndShuffle();
            }

            // TODO: Bet

            // Deal two cards
            for(int c = 0; c < 2; c++)
            {
                foreach(var seat in Seats)
                {
                    if (seat.Player != null)
                        seat.Hand.Add(_deck.Deal());
                }

            }

            // TODO: check for dealer blackjack

            // TODO: players play

            // Dealer plays
            BlackJackScore dealerScore = new BlackJackScore(_dealerHand);
            while(dealerScore.Score < DEALER_STANDS_ON)
            {
                _dealerHand.Add(_deck.Deal());
                dealerScore = new BlackJackScore(_dealerHand);
            }

            // Score hands
            // TODO: payoff
            for (int p = 0; p < Size; p++)
            {
                if (Seats[p].Player != null)
                {
                    var hand = Seats[p].Hand;
                    sb.AppendFormat("Player {0}: {1} ({2})\n", p, BlackJackHandToString(hand), new BlackJackScore(hand));
                }
            }
            sb.AppendFormat("Dealer: {0} ({1})", BlackJackHandToString(_dealerHand), dealerScore);


            return sb.ToString();
        }

        private string BlackJackHandToString(IEnumerable<Card> hand)
        {
            var x = hand.Select(c => (new BlackJackScore(new Card[1] { c })).Score);
            return String.Join("-", x);
        }
    }
}
