using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Skattejagt
{

    class Pos
    {
	public int Y;
	public int X;
	public Pos Parent;
	public string Dir;

	public Pos(int x, int y): this(x, y, null, String.Empty) {}

	public Pos(int x, int y, Pos parent, string dir)
	{
	    this.X = x;
	    this.Y = y;
	    this.Parent = parent;
	    this.Dir = dir;
	}
    }

    public class TreasureC
    {
	public static void Main()
	{
	    new TreasureC();
	}
	
	public TreasureC()
	{
	    Console.ReadLine();
	    var mapString = "";
	    var next = Console.ReadLine();
	    while (next != null)
	    {
	    	mapString += next + "\n";
	    	next = Console.ReadLine();
	    }

	    //var mapString = File.ReadAllText("map.txt");
	    var rows = mapString.Split('\n');    
	    var n = rows.Length-1;
	    var map = new List<char[]>();
	    for (var i = 0; i < n; i++)
		map.Add(rows[i].ToCharArray());

	    Pos entry = null;
	    for (var y = 0; y < n; ++y)
		for (int x = 0; x < n; ++x)
		    if (map[y][x] == 'I') entry = new Pos(x, y);
	    
	    if (entry == null) return;

	    var frontier = new Queue<Pos>();
	    frontier.Enqueue(entry);
	    Pos last = null;
	    while (frontier.Count > 0)
	    {
		var curr = frontier.Dequeue();

		map[curr.Y][curr.X] = '#';
		
		if (ProcessTile(n, curr.X-1, curr.Y, frontier, map, curr, "W", ref last)
		    || ProcessTile(n, curr.X+1, curr.Y, frontier, map, curr, "E", ref last)
		    || ProcessTile(n, curr.X, curr.Y+1, frontier, map, curr, "S", ref last)
		    || ProcessTile(n, curr.X, curr.Y-1, frontier, map, curr, "N", ref last))
		    break;
	    }

	    // trace the path, if any
	    var route = new StringBuilder();
	    var t = last;
	    while (t != null)
	    {
		route.Append(t.Dir + " ");
		t = t.Parent;
	    }
	    
	    var s = route.ToString();
	    char[] charArray = s.ToCharArray();
	    Array.Reverse( charArray );
	    var rt = new string( charArray );

	    Console.WriteLine(rt);
	}

	private bool ProcessTile(int n, int px, int py, Queue<Pos> frontier, List<char[]> map, Pos current, string direction, ref Pos last)
	{
	    if (IsValidPos(n, py, px) && map[py][px] != '#')
	    {
		var p = new Pos(px, py, current, direction);
		
		// have we found the treasure?
		if (map[py][px] == '$')
		{
		    last = p;
		    return true;
		}

		frontier.Enqueue(p);

		map[py][px] = '#';
	    }
	    return false;
	}

	private bool IsValidPos(int n, int y, int x)
	{
	    n--;
	    return !(x < 0 || y < 0 || x > n || y > n);
	}
    }
}