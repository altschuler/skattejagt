using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Skattejagt
{
    public class ProgramB : Form
    {
	    public static void Main()
	    {
		Application.Run(new ProgramB());
	    }
	    
        public MapGraph kb;

	    public ProgramB()
	    {
		var mapString = 
@"###I####
#$#    #
# ####$#
#  $   #
#### $ #
#$ #   #
# $# $ #
########";
	        var map = Map.Parse(mapString);
	        this.kb = MapGraph.Parse(map);
	    
	     	this.Paint += new PaintEventHandler(this.OnPaint);
	    }
	    
	    private void OnPaint(object sender, PaintEventArgs args)
	    {	    
		var traceNode = BFSearch.Search(this.kb.States, this.kb.Actions, this.kb.Entries[0], Tile.Treasure);
		
		if (traceNode == null) return;
		
		var next = traceNode;
		var steps = 0;
		var pathString = next.Action.Name;
		// .Parent to get steps and not amount of states
		while ((next = next.Parent) != null)
		{
		    steps++;
		    if (next.Action != null)
			pathString = next.Action.Name + " " + pathString;
		    
		}

		Console.WriteLine("Steps to treasure: " + pathString);
	        Painter.DrawMap(args.Graphics, this.kb, 20f);
		Painter.DrawRoute(args.Graphics, traceNode, 20f);
	    }
    }
}