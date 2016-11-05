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
        public readonly Player[] Players;
        public readonly Deck Deck;

        public Table(int size, Deck deck)
        {
            Players = new Player[size];
            Deck = deck;
        }
    }
}
