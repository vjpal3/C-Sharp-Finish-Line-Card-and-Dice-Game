using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine
{
    class Deck
    {
        public List<Card> Cards = new List<Card>();
        private static string[] suits = new string[4] { "heart", "spade", "club", "diamond" };
        private static int[] values = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };    

        // For single marker and single die game
        public Deck(int[] valuesOfCards)
        {
            //populate the deck
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < valuesOfCards.Length; j++)
                {
                    this.Cards.Add(new Card(suits[i], valuesOfCards[j]));
                }
            }                   
        }

        //For a game having 3 markers and 2 dice
        public Deck()
        {
            //The deck contains 54 cards, including 2 jokers. The value of joker is 0 and Ace is 1
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                    Cards.Add(new Card(suits[i], values[j]));
            }
            for (int i = 0; i < 2; i++)
                this.Cards.Add(new Card("joker", 0));
        }

        public void ShowDeck()
        {
            
            for (int i = 0; i < Cards.Count; i++)
            {
                if(i % 9 == 0)
                    Console.WriteLine("\n\n");
                Console.Write(Cards[i].Suit + " " + Cards[i].Value + "      ");
               
            }
            Console.WriteLine();
        }
       

        public void Shuffle(Random rand)
        {
            RandomExtensions.Shuffle(rand, this.Cards);
        }
        
    }
}
