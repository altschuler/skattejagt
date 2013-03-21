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
	    
        public Map2 kb;

	    public ProgramA()
	    {
	        var map = Map.Parse(@"########
#  $   #    
#      #    
I  #####    
#  # $ #    
#  ### #    
#      #    
########    ");
	        var amount = 0;
	        foreach (var row in map.Tiles)
	        {
		    foreach (var tile in row)
		    {
			if (tile.Equals(Tile.Treasure)) 
			    amount++;
		    }
	        }
	        
	        this.kb = Map2.Parse(map);
	    
	        Console.WriteLine(String.Format("Amount of treasures: {0}", amount));
	    
	        // Troll
	        Console.WriteLine(String.Format("Amount of treasures (LINQ): {0}", map.Tiles.SelectMany(x => x).Where(t => t.Equals(Tile.Treasure)).Count()));
	    
	     	this.Paint += new PaintEventHandler(this.OnPaint);	        
	    }
	    
	    private void OnPaint(object sender, PaintEventArgs args)
	    {	    
	        Painter.DrawKnowledgeBase(args.Graphics, this.kb, 20f);
	    }
    }
}