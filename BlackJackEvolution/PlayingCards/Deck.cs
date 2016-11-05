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
        private int _nextCardIndex = 0;
        private Random random = new Random();

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

        public int UndealtCount
        {
            get
            {
                return Count - _nextCardIndex;
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

        public Card Deal()
        {
            return _allCards[_nextCardIndex++];
        }

        public void Shuffle()
        {
            _allCards.Shuffle(_nextCardIndex, random);
        }

        public void GatherAndShuffle()
        {
            _nextCardIndex = 0;
            Shuffle();
        }
    }
}
