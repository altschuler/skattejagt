using System;
using System.Linq;
using System.IO;

namespace Skattejagt
{
    public class ProgramC
    {
	public static void Main()
	{
	    new ProgramC();
	}

	public ProgramC()
	{
//	    var mapString = File.ReadAllText("map.txt");
	    var mapString = File.ReadAllText("map.txt");
	    //var mapString = Helper.GetInput();
	    
	    var map = Map.Parse(mapString);
	    Console.WriteLine("map parsed");
	    var graph = MapGraph.Parse(map);
	    Console.WriteLine("graph parsed");
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