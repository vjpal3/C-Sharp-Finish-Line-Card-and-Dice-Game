﻿using System;
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
        //private static int[] values = new int[13] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        
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

        public void ShowDeck()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                Console.WriteLine(Cards[i].Suit + " " + Cards[i].Value);
            }
        }

        public void ValidateDeck(Random rand, List<int> restrictedCards)
        {

            while (restrictedCards.Contains(Cards[0].Value) || restrictedCards.Contains(Cards[1].Value) || restrictedCards.Contains(Cards[Cards.Count - 1].Value) || restrictedCards.Contains(Cards[Cards.Count - 2].Value))
            {
                RandomExtensions.Shuffle(rand, Cards);
            }
        }

        public void Shuffle(Random rand)
        {
            RandomExtensions.Shuffle(rand, this.Cards);
        }
        
    }
}
