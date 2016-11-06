using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JamesQMurphy.PlayingCards;
using BlackJackEvolution.App;

namespace BlackJackEvolution.Test
{
    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        public void BlackjackScore_4_5()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.Four, Suit.Spades), new Card(Rank.Five, Suit.Hearts) });
            Assert.AreEqual(9, score.Score);
            Assert.IsFalse(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_10_4()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.Ten, Suit.Clubs), new Card(Rank.Four, Suit.Hearts) });
            Assert.AreEqual(14, score.Score);
            Assert.IsFalse(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_Q_4()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.Queen, Suit.Clubs), new Card(Rank.Four, Suit.Diamonds) });
            Assert.AreEqual(14, score.Score);
            Assert.IsFalse(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_K_K()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.King, Suit.Clubs), new Card(Rank.King, Suit.Diamonds) });
            Assert.AreEqual(20, score.Score);
            Assert.IsFalse(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_3_A()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.Three, Suit.Clubs), new Card(Rank.Ace, Suit.Diamonds) });
            Assert.AreEqual(14, score.Score);
            Assert.IsTrue(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_A_A()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.Ace, Suit.Hearts), new Card(Rank.Ace, Suit.Spades) });
            Assert.AreEqual(12, score.Score);
            Assert.IsTrue(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_A_J_A()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.Ace, Suit.Hearts), new Card(Rank.Jack, Suit.Spades), new Card(Rank.Ace, Suit.Diamonds) });
            Assert.AreEqual(12, score.Score);
            Assert.IsFalse(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_A_J_A_Q()
        {
            BlackJackScore score = new BlackJackScore(new Card[] { new Card(Rank.Ace, Suit.Hearts), new Card(Rank.Jack, Suit.Spades), new Card(Rank.Ace, Suit.Diamonds), new Card(Rank.Queen, Suit.Diamonds) });
            Assert.AreEqual(22, score.Score);
            Assert.IsFalse(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_3()
        {
            BlackJackScore score = new BlackJackScore(new Card(Rank.Three, Suit.Clubs));
            Assert.AreEqual(3, score.Score);
            Assert.IsFalse(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_A()
        {
            BlackJackScore score = new BlackJackScore(new Card(Rank.Ace, Suit.Diamonds));
            Assert.AreEqual(11, score.Score);
            Assert.IsTrue(score.IsSoft);
        }

        [TestMethod]
        public void BlackjackScore_J()
        {
            BlackJackScore score = new BlackJackScore(new Card(Rank.Jack, Suit.Hearts));
            Assert.AreEqual(10, score.Score);
            Assert.IsFalse(score.IsSoft);
        }



    }
}
