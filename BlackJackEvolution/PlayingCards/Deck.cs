using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesQMurphy.PlayingCards
{
    public class Deck : IReadOnlyCollection<Card>
    {
        private List<Card> _allCards = null;

        public Deck()
        {
            _allCards = new List<Card>();
        }

        public Deck(IEnumerable<Card> cards)
        {
            _allCards = new List<Card>(cards);
        }

        public int Count
        {
            get
            {
                return _allCards.Count;
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((ICollection<Card>)_allCards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<Card>)_allCards).GetEnumerator();
        }


        public void Shuffle()
        {
            _allCards.Shuffle();
        }
    }
}
