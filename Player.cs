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

        public Marker marker1, marker2, marker3;
        public string Name { get; set; }

        public Player() { }

        public Player(string name, string[] markerNames)
        {
            this.Name = name;
            marker1 = new Marker(markerNames[0]);
            marker2 = new Marker(markerNames[1]);
            marker3 = new Marker(markerNames[2]);           
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
