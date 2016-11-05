using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JamesQMurphy.PlayingCards;

namespace BlackJackEvolution.Test
{
    [TestClass]
    public class DeckTest
    {
        private IEnumerable<Card> _cardset;
        private int _cardsetCount;

        [TestInitialize]
        public void Initialize()
        {
            _cardset = CardSets.Bridge;
            _cardsetCount = _cardset.Count();
        }

        [TestMethod]
        public void InitialState()
        {
            Deck deck = new Deck(_cardset);
            Assert.AreEqual(_cardsetCount, deck.Count);
            Assert.AreEqual(_cardsetCount, deck.UndealtCount);
        }

        [TestMethod]
        public void Deal()
        {
            Deck deck = new Deck(_cardset);
            int undealt = _cardsetCount;

            for(int i = 0; i < _cardsetCount; i++)
            {
                deck.Deal();
                undealt--;
                Assert.AreEqual(_cardsetCount, deck.Count);
                Assert.AreEqual(undealt, deck.UndealtCount);
            }
        }

        [TestMethod]
        public void Shuffle()
        {
            // This needs a deck where all cards are unique
            // Pinochle, Poker, and Blackjack decks won't work
            _cardset = CardSets.Bridge;
            _cardsetCount = CardSets.Bridge.Length;

            Deck deck = new Deck(_cardset);
            HashSet<Card> dealtSoFar = new HashSet<Card>();

            for(int i = 0; i < _cardsetCount; i++)
            {
                deck.Shuffle();
                Card cardDealt = deck.Deal();
                Assert.IsFalse(dealtSoFar.Contains(cardDealt));
                dealtSoFar.Add(cardDealt);
            }
        }

        [TestMethod]
        public void GatherAndShuffle()
        {
            Deck deck = new Deck(_cardset);
            int toDeal = new Random().Next(_cardsetCount - 1) + 1;
            for ( int i = 0; i < toDeal; i++)
            {
                deck.Deal();
            }
            Assert.AreEqual(_cardsetCount, toDeal + deck.UndealtCount);

            deck.GatherAndShuffle();
            Assert.AreEqual(_cardsetCount, deck.UndealtCount);
        }
    }
}
