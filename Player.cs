using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine
{
    class Player
    {
        private int position = -1;
        private string marker1, marker2, marker3;

        public Player() { }
        public Player(string[] markers)
        {
            marker1 = markers[0];
            marker2 = markers[1];
            marker3 = markers[2];
        }
        public void Move(int newPosition)
        {
            this.position = newPosition;
        }

        public int GetPosition()
        {
            return this.position;
        }

    }
}
