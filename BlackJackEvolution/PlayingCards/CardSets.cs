using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesQMurphy.PlayingCards
{
    public static class CardSets
    {
        public static readonly Card[] Bridge = new Card[]
        {
            new Card(Rank.Deuce, Suit.Clubs),
            new Card(Rank.Three, Suit.Clubs),
            new Card(Rank.Four, Suit.Clubs),
            new Card(Rank.Five, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Eight, Suit.Clubs),
            new Card(Rank.Nine, Suit.Clubs),
            new Card(Rank.Ten, Suit.Clubs),
            new Card(Rank.Jack, Suit.Clubs),
            new Card(Rank.Queen, Suit.Clubs),
            new Card(Rank.King, Suit.Clubs),
            new Card(Rank.Ace, Suit.Clubs),
            new Card(Rank.Deuce, Suit.Diamonds),
            new Card(Rank.Three, Suit.Diamonds),
            new Card(Rank.Four, Suit.Diamonds),
            new Card(Rank.Five, Suit.Diamonds),
            new Card(Rank.Six, Suit.Diamonds),
            new Card(Rank.Seven, Suit.Diamonds),
            new Card(Rank.Eight, Suit.Diamonds),
            new Card(Rank.Nine, Suit.Diamonds),
            new Card(Rank.Ten, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Diamonds),
            new Card(Rank.Queen, Suit.Diamonds),
            new Card(Rank.King, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Deuce, Suit.Hearts),
            new Card(Rank.Three, Suit.Hearts),
            new Card(Rank.Four, Suit.Hearts),
            new Card(Rank.Five, Suit.Hearts),
            new Card(Rank.Six, Suit.Hearts),
            new Card(Rank.Seven, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Nine, Suit.Hearts),
            new Card(Rank.Ten, Suit.Hearts),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Queen, Suit.Hearts),
            new Card(Rank.King, Suit.Hearts),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Deuce, Suit.Spades),
            new Card(Rank.Three, Suit.Spades),
            new Card(Rank.Four, Suit.Spades),
            new Card(Rank.Five, Suit.Spades),
            new Card(Rank.Six, Suit.Spades),
            new Card(Rank.Seven, Suit.Spades),
            new Card(Rank.Eight, Suit.Spades),
            new Card(Rank.Nine, Suit.Spades),
            new Card(Rank.Ten, Suit.Spades),
            new Card(Rank.Jack, Suit.Spades),
            new Card(Rank.Queen, Suit.Spades),
            new Card(Rank.King, Suit.Spades),
            new Card(Rank.Ace, Suit.Spades)
        };

        private const int NUM_DECKS_IN_BLACKJACK = 6;
        private static readonly object _lockObject = new object();
        private static Card[] _blackJack = null;
        public static Card[] BlackJack
        {
            get
            {
                if ( _blackJack == null )
                {
                    lock (_lockObject)
                    {
                        if (_blackJack == null)
                        {
                            _blackJack = new Card[NUM_DECKS_IN_BLACKJACK * Bridge.Length];
                            for ( int i = 0; i < NUM_DECKS_IN_BLACKJACK; i++)
                            {
                                Bridge.CopyTo(_blackJack, (i * Bridge.Length));
                            }
                        }
                    }
                }
                return _blackJack;
            }
        }
    }

}
