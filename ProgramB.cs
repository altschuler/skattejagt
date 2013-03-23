using System;
using System.Linq;

namespace Skattejagt
{
    public class ProgramB
    {
	public static void Main()
	{
	    new ProgramB();
	}

	public ProgramB()
	{
	    var mapString = 
@"";

//	    var mapString = Helper.GetInput();
	    
	    var map = Map.Parse(mapString);
	    var graph = MapGraph.Parse(map);
	    if (graph.Entries.Count == 0) return;
	    var traceNode = BFSearch.Search(graph.States, graph.Actions, graph.Entries[0], Tile.Treasure);
	    
	    if (traceNode == null) return;

	    var next = traceNode;
	    var pathString = next.Action.Name;
	    while ((next = next.Parent) != null)
		if (next.Action != null)
		    pathString = next.Action.Name + " " + pathString;

	    Console.WriteLine(pathString);
	}
    }
}