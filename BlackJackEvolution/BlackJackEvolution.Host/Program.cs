using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamesQMurphy.PlayingCards;

namespace BlackJackEvolution.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck(CardSets.BlackJack);
            deck.Shuffle();
            foreach (Card card in deck)
            {
                Console.WriteLine("{0}", card);
            }
            Console.WriteLine("{0} card(s) total", deck.Count);
        }
    }
}
