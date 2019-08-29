using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine
{
    class Card
    {
        private string suit;
        private int value;

        public string Suit { get => suit; set => suit = value; }
        public int Value { get => value; set => this.value = value; }

        public Card(string suit, int value) 
        {
            this.Suit = suit;
            this.Value = value;
        }

        
    }
}
