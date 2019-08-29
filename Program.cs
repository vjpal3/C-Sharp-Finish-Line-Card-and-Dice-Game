using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var board = new MultiMarkersBoard();
            Console.WriteLine(board.StartGame(rand));
            

            //var board = new Board();
            //Console.WriteLine(board.StartGame(rand));

        }
    }
}
