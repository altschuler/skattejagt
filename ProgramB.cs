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
//	    var mapString =  
//@"###I####
//#$     #
//######$#
//#  $   #
//##### ##
//#$ # # #
//# $# $ #
//########";
	    var mapString = Helper.GetInput();
	    var map = Map.Parse(mapString);
	    var graph = MapGraph.Parse(map);
	    if (graph.Entries.Count == 0) return;
	    var amount = FullSearch.Search(graph.States, graph.Actions, graph.Entries[0], Tile.Treasure);
	    

	    Console.WriteLine(amount);
	}
    }
}