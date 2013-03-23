using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Skattejagt
{
    public class ProgramA : Form
    {
	public static void Main()
	{
	    Application.Run(new ProgramA());
	}

	public ProgramA()
	{
	    var map = Map.Parse(@"########
#    $ #    
#   $  #    
I  #####    
#  # $ #    
#$ ### #    
#      #    
########");

	    // O(n^2)
	    var amount = 0;
	    foreach (var row in map.Tiles)
		foreach (var tile in row)
		    if (tile.Equals(Tile.Treasure)) 
			amount++;
	    
	    Console.WriteLine(String.Format("Amount of treasures: {0}", amount));
	}
    }
}