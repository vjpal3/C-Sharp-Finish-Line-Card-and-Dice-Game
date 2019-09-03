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
            player1 = new Player(new string[] { "1A", "1B", "1C" });
            player2 = new Player(new string[] { "2A", "2B", "2C" });
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

        public void ShowBoard()
        {                                            
            var count = 0;
            var rowStr = "";
            var row = 0;
            while (count <= deck.Cards.Count - 9)
            {
                int i;
                for (i = count; i < count + 9; i++)
                {
                    var cardStr = deck.Cards[i].Suit + " " + deck.Cards[i].Value;
                    var addSpaces = 12 - cardStr.Length;
                    for (var j = 0; j < addSpaces; j++)
                        cardStr += " ";
                    rowStr += cardStr;
                }
                rowStr += PrintPlayer(player1, row);
                rowStr += PrintPlayer(player2, row);                
                count += 9;
                row++;
                Console.WriteLine(rowStr);
                Console.WriteLine("\n");
                rowStr = "";
            }
            
        }

        private string PrintPlayer(Player player, int row)
        {
            var positionPlayer = player.marker1.GetPosition();
            var rowStr = "";
            if (row == positionPlayer / 9)
            {
                rowStr += "\n";
                for (var k = 0; k < positionPlayer * 15; k++)
                {
                    rowStr += " ";
                }
                rowStr += player.marker1.name;
            }
            return rowStr;
        }

        public void MoveMarker(Player player)
        {
            Console.Clear();
            var redValue = redDie.DieSides[0];
            var blackValue = blackDie.DieSides[0];
            var stopValue = redValue + blackValue;
            Console.WriteLine("Red Die: {0}, Black Die: {1}, Stop Value: {2}", redValue, blackValue, stopValue);
            Console.WriteLine();

            for (int i = player.GetPosition() + 1; i < deck.Cards.Count; i++)
            {
                if (deck.Cards[i].Value >= stopValue)
                {
                    player.marker1.SetPosition(i);
                    ShowBoard();
                    break;
                }
            }
        }

        public string StartGame(Random rand)
        {
            deck.Shuffle(rand);
            ValidateDeck(rand);
            deck.ShowDeck();            
            bool firstTurn = true;

            while (player1.marker1.GetPosition() != deck.Cards.Count - 1 || player2.marker1.GetPosition() != deck.Cards.Count - 1)
            {
                redDie.RollDie(rand);
                blackDie.RollDie(rand);            
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
                Console.ReadLine();
                if (player1.marker1.GetPosition() >= deck.Cards.Count - 1 || player2.marker1.GetPosition() >= deck.Cards.Count - 1)
                    break;
            }        
            return "";
        }
    }
}
