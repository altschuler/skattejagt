using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skattejagt
{
    public class State
    {
        public int X { get; set; }
        public int Y { get; set; }
	public Tile Type { get; set; }

        public State(int x, int y, Tile type)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
        }

	public override string ToString()
	{
	    return String.Format("{0} ({1},{2})", this.Type, this.X, this.Y);
	}
    }
}
