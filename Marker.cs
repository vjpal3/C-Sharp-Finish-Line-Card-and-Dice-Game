using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinishLine
{
    class Marker
    {
        public string name { get; set; }
        private int position;

        public Marker(string name)
        {
            this.name = name;
            this.position = -1;
        }

        public void SetPosition(int newPosition)
        {
            this.position = newPosition;
        }

        public int GetPosition()
        {
            return this.position;
        }

    }

}
