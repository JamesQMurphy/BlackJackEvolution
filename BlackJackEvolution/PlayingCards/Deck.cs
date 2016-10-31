using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesQMurphy.PlayingCards
{
    public class Deck : ICollection<Card>
    {
        private List<Card> _allCards = new List<Card>();

        public int Count
        {
            get
            {
                return ((ICollection<Card>)_allCards).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public void Add(Card card)
        {
            ((ICollection<Card>)_allCards).Add(card);
        }

        public void Add(Deck deck)
        {
            _allCards.AddRange(deck);
        }

        public void Clear()
        {
            ((ICollection<Card>)_allCards).Clear();
        }

        public bool Contains(Card card)
        {
            return ((ICollection<Card>)_allCards).Contains(card);
        }

        public void CopyTo(Card[] array, int arrayIndex)
        {
            ((ICollection<Card>)_allCards).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((ICollection<Card>)_allCards).GetEnumerator();
        }

        public bool Remove(Card item)
        {
            return ((ICollection<Card>)_allCards).Remove(item);
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
