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
                Seats[i] = new Seat(i);
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
                sb.AppendFormat("Deck down to {0} cards, reshuffling\n", _deck.UndealtCount);
                _deck.GatherAndShuffle();
            }

            var ActiveSeats = Seats.Where(s => !s.IsEmpty);

            // TODO: Bet

            // Deal two cards
            for(int c = 0; c < 2; c++)
            {
                foreach(var seat in ActiveSeats)
                {
                    seat.Hand.Add(_deck.Deal());
                }
                _dealerHand.Add(_deck.Deal());
            }

            // TODO: check for blackjacks

            // Players play
            foreach (var seat in ActiveSeats)
            {
                // TODO: split
                Plays possiblePlays = Plays.Stand | Plays.Hit | Plays.Double | Plays.Surrender;
                BlackJackScore score = new BlackJackScore(seat.Hand);
                Plays play = Plays.Stand;
                do
                {
                    play = seat.Player.GetPlay(seat.Hand, _dealerHand[1], possiblePlays);

                    switch (play)
                    {
                        case Plays.Stand:
                            break;
                        case Plays.Double:
                            break;
                        case Plays.Hit:
                            seat.Hand.Add(_deck.Deal());
                            break;
                        case Plays.Split:
                            break;
                        case Plays.Surrender:
                            throw new NotImplementedException();
                        default:
                            break;
                    }

                    possiblePlays &= ~Plays.Double;
                    score = new BlackJackScore(seat.Hand);
                } while (score.Score < 21 && play.HasFlag(Plays.Hit));

            }

            // Dealer plays
            BlackJackScore dealerScore = new BlackJackScore(_dealerHand);
            while(dealerScore.Score < DEALER_STANDS_ON)
            {
                _dealerHand.Add(_deck.Deal());
                dealerScore = new BlackJackScore(_dealerHand);
            }

            // Score hands
            // TODO: payoff
            foreach (var seat in ActiveSeats)
            {
                var hand = seat.Hand;
                sb.AppendFormat("Player {0}: {1} ({2})\n", seat.Number, BlackJackHandToString(hand), new BlackJackScore(hand));
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
