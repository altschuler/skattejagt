using System;
using System.Collections.Generic;

namespace Skattejagt
{
    public class Map
    {
	    public List<List<Tile>> Tiles { get;set; }
	    
	    private Map()
	    {
	        this.Tiles = new List<List<Tile>>();
	    }
	    
	    public Tile TileAt(int x, int y)
	    {
	        return this.Tiles[y][x];
	    }
	    
	    public List<Tile> Row(int index)
	    {
	        return this.Tiles[index];
	    }
	    
	    public static Map Parse(string mapString)
	    {
	        var map = new Map();
	        foreach (var rowString in mapString.Split('\n'))
	        {
		    var row = new List<Tile>();
		    foreach (var tileChar in rowString.ToCharArray())
		    {
			switch (tileChar)
			{
			    case '#': row.Add(Tile.Wall); break;
			    case 'I': row.Add(Tile.Entry); break;
			    case ' ': row.Add(Tile.Floor); break;
			    case '$': row.Add(Tile.Treasure); break;
			    default: throw new Exception(String.Format("Invalid tile character {0}", tileChar));
			}
		    }
		    map.Tiles.Add(row);
	        }
	        return map;
	    }
    }
}