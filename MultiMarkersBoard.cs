using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine
{
    class MultiMarkersBoard
    {
        private Player player1;
        private Player player2;
        private readonly Die blackDie;
        private readonly Die redDie;
        private readonly Deck deck;
        public readonly List<int> restrictedCards = new List<int> { 0, 1, 2, 11, 12, 13 };

        public MultiMarkersBoard()
        {
            player1 = new Player(new string[] { "M11", "M12", "M13" });
            player2 = new Player(new string[] { "M21", "M22", "M23" });
            blackDie = new Die(6);
            redDie = new Die(6);
            deck = new Deck();
        }

        public void ValidateDeck(Random rand)
        {
            // A valid deck should not have J, Q, K, A , 2 & Joker as its first 3 and last 3 cards.
            while (restrictedCards.Contains(deck.Cards[0].Value) || restrictedCards.Contains(deck.Cards[1].Value) || restrictedCards.Contains(deck.Cards[2].Value) || restrictedCards.Contains(deck.Cards[deck.Cards.Count - 1].Value) || restrictedCards.Contains(deck.Cards[deck.Cards.Count - 2].Value) || restrictedCards.Contains(deck.Cards[deck.Cards.Count - 3].Value))
            {
                RandomExtensions.Shuffle(rand, deck.Cards);
            }
        }

        public string StartGame(Random rand)
        {
            deck.Shuffle(rand);
            this.ValidateDeck(rand);
            deck.ShowDeck();

            return "";

        }
    }
}
