using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine
{
    class Board
    {
        private Player player1;
        private Player player2;
        private readonly Die die;
        private readonly Deck deck;
        public readonly List<int> restrictedCards = new List<int> { 1, 2, 6, 7 };

        public Board()
        {
            player1 = new Player();
            player2 = new Player();
            die = new Die(6);
            deck = new Deck(new int[] { 1, 2, 3, 4, 5, 6, 7 });
        }

        public void MoveMarker(Player player)
        {
            var dieValue = die.DieSides[0];
            for (int i = player.GetPosition() + 1; i < deck.Cards.Count; i++)
            {
                if (deck.Cards[i].Value >= dieValue)
                {
                    player.Move(i);
                    break;
                }
            }
        }

        public string StartGame(Random rand)
        {
            deck.Shuffle(rand);          
            deck.ValidateDeck(rand, restrictedCards);           
            deck.ShowDeck();

            int p1 = 0, p2 = 0;
            bool firstTurn = true;           
            while (player1.GetPosition() != deck.Cards.Count - 1 || player2.GetPosition() != deck.Cards.Count - 1)
            {
                this.die.RollDie(rand);
                Console.WriteLine("dieValue: " + die.DieSides[0]);
                if (firstTurn)
                {
                    Console.WriteLine("P1 turn");                   
                    MoveMarker(player1);                    
                }
                else
                {
                    Console.WriteLine("P2 turn");                   
                    MoveMarker(player2);                   
                }
                firstTurn = !firstTurn;

                Console.WriteLine("p1: " + player1.GetPosition() + " Card1: " + deck.Cards[p1].Value);
                Console.WriteLine("p2: " + player2.GetPosition() + " Card2: " + deck.Cards[p2].Value);

                if (player1.GetPosition() >= deck.Cards.Count - 1 || player2.GetPosition() >= deck.Cards.Count - 1)
                    break;                          
            }
            return player1.GetPosition() > player2.GetPosition() ? "Player1 Wins" : "Player2 Wins";
        }
    }
}
