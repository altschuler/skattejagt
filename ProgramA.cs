using System;
using System.Linq;

namespace Skattejagt
{
    public class Program
    {
	public static void Main()
	{
	    new Program();
	}

	public Program()
	{
	    var map = Map.Parse(@"########
I #    #
# # ## #
# #  #$#
#    ###
#### # #
#$   #$#
########");
	    var amount = 0;
	    foreach (var row in map.Tiles)
	    {
		foreach (var tile in row)
		{
		    if (tile.Equals(Tile.Treasure)) 
			amount++;
		}
	    }

	    Console.WriteLine(String.Format("Amount of treasures: {0}", amount));

	    // Troll
	    Console.WriteLine(String.Format("Amount of treasures (LINQ): {0}", map.Tiles.SelectMany(x => x).Where(t => t.Equals(Tile.Treasure)).Count()));

	    
	    
	}
    }
}