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
