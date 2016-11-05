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

        public readonly Player[] Players;
        private readonly List<Card>[] _playerHands;
        private readonly List<Card>[] _playerSplitHands;

        public int Size
        {
            get { return Players.Length; }
        }

        public Table(int size)
        {
            _deck.Shuffle();

            Players = new Player[size];
            _playerHands = new List<Card>[size];
            _playerSplitHands = new List<Card>[size];
            for ( int i = 0; i < size; i++)
            {
                _playerHands[i] = new List<Card>();
                _playerSplitHands[i] = new List<Card>();
            }
        }

        public string PlayHand()
        {
            // TODO: create enumerator/delegate to enumerate over non-null players

            StringBuilder sb = new StringBuilder();

            // Clear the table
            _dealerHand.Clear();
            foreach (var hand in _playerHands)
            {
                hand.Clear();
            }
            foreach (var hand in _playerSplitHands)
            {
                hand.Clear();
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
                for(int p = 0; p < Size; p++)
                {
                    if (Players[p] != null)
                        _playerHands[p].Add(_deck.Deal());
                }
                _dealerHand.Add(_deck.Deal());
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
                if (Players[p] != null)
                {
                    var hand = _playerHands[p];
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
