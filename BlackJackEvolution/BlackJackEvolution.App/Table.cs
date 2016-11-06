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

        public int Bet = 10;
        public double Payoff = 1.0;
        public double BlackjackPays = 1.2;

        public int Size
        {
            get { return Seats.Length; }
        }

        public Table(int size, Random rand = null)
        {
            if (rand != null)
            {
                _deck = new Deck(CardSets.BlackJack, rand);
            }
            _deck.Shuffle();
            Seats = new Seat[size];
            for (int i = 0; i < size; i++)
                Seats[i] = new Seat(i);
        }

        public string Name { get; set; }

        public string PlayHand()
        {
            StringBuilder sb = new StringBuilder();

            // Clear the table
            _dealerHand.Clear();
            foreach (var seat in Seats)
            {
                seat.Clear();
            }

            // Reshuffle if necessary
            if (_deck.UndealtCount * 4 < _deck.Count)
            {
                sb.AppendFormat("Deck down to {0} cards, reshuffling\n", _deck.UndealtCount);
                _deck.GatherAndShuffle();
            }

            // Place bets
            foreach (var seat in Seats.Where(s => !s.IsEmpty))
            {
                if (seat.Player.Chips >= Bet)
                {
                    seat.Bet = Bet;
                    seat.Player.Chips -= Bet;
                }
            }


            var ActiveSeats = Seats.Where(s => s.Bet > 0);

            

            // Deal two cards
            for(int c = 0; c < 2; c++)
            {
                foreach(var seat in ActiveSeats)
                {
                    seat.Hand.Add(_deck.Deal());
                }
                _dealerHand.Add(_deck.Deal());
            }
            BlackJackScore dealerScore = new BlackJackScore(_dealerHand);


            // Players play
            if (!dealerScore.IsBlackjack)
            {
                foreach (var seat in ActiveSeats)
                {
                    BlackJackScore score = new BlackJackScore(seat.Hand);
                    if (score.IsBlackjack)
                        continue;

                    // TODO: split and surrender
                    Plays possiblePlays = Plays.Stand | Plays.Hit | Plays.Double | Plays.Surrender;
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
            }

            // Dealer plays
            while (dealerScore.Score < DEALER_STANDS_ON)
            {
                _dealerHand.Add(_deck.Deal());
                dealerScore = new BlackJackScore(_dealerHand);
            }

            // Score hands
            foreach (var seat in ActiveSeats)
            {
                var hand = seat.Hand;
                var playerScore = new BlackJackScore(hand);
                int effectiveDealerScore = (dealerScore.Score > 21) ? 0 : dealerScore.Score;
                int winnings = 0;
                if (playerScore.Score < 22)
                {
                    // TODO: may have to modify if dealer has blackjack
                    if (playerScore.IsBlackjack)
                    {
                        // BLACKJACK
                        winnings = seat.Bet + (int)(BlackjackPays * seat.Bet);
                    }
                    else
                    {
                        if (playerScore.Score == effectiveDealerScore)
                        {
                            // PUSH
                            winnings = seat.Bet;
                        }
                        else if (playerScore.Score > effectiveDealerScore)
                        {
                            // WIN
                            winnings = seat.Bet + (int)(Payoff * seat.Bet);
                        }
                    }
                }
                seat.Player.Chips += winnings;
                sb.AppendFormat("Player {0} at table {1}: {2} ({3}) bet:{4} win:{5} chips:{6}\n", seat.Player.Name, this.Name, BlackJackHandToString(hand), new BlackJackScore(hand), seat.Bet, (winnings - seat.Bet), seat.Player.Chips);
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
