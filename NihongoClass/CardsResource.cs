using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NihongoClass.Resources
{
    public abstract class CardsResource
    {

        private Random _rand;
        private List<Tuple<String, String>> _cards;

        public abstract String Header { get; }

        public CardsResource()
        {
            _rand = new Random();
            _cards = new List<Tuple<String, String>>();

            SetUp();
        }

        public void Add(String front, String back)
        {
            _cards.Add(new Tuple<String, String>(front, back));
        }

        public abstract void SetUp();

        public List<String> Shuffle()
        {
            var shuffled = new List<String>();
            while (_cards.Count > 0)
            {
                var index = _rand.Next(_cards.Count);
                var card = _cards[index];

                shuffled.Add(card.Item1);
                shuffled.Add(card.Item2);
                
                _cards.RemoveAt(index);
            }
            return shuffled;
        }
    }
}
