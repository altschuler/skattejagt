using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Skattejagt
{

    struct Pos
    {
	public int Y;
	public int X;

	public Pos(int x, int y)
	{
	    this.X = x;
	    this.Y = y;
	}
    }

    public class TreasureB
    {
	public static void Main()
	{
	    new TreasureB();
	}
	
	public TreasureB()
	{
	    //Console.ReadLine();
	    //var mapString = "";
	    //var next = Console.ReadLine();
	    //while (next != null)
	    //{
	    //	mapString += next + "\n";
	    //	next = Console.ReadLine();
	    //}

	    var mapString = File.ReadAllText("map2.txt");
	 
	    var rows = mapString.Split('\n');    
	    var n = rows.Length-1;
	    var map = new List<char[]>();
	    for (var i = 0; i < n; i++)
	    {
		map.Add(rows[i].ToCharArray());
	    }
	    var entry = new Pos();

	    for (var y = 0; y < n; ++y)
		for (int x = 0; x < n; ++x)
		    if (map[y][x] == 'I') entry = new Pos() { X = x, Y = y };

	    var frontier = new Queue<Pos>();
	    frontier.Enqueue(entry);
	    var found = 0;
	    while (frontier.Count > 0)
	    {
		var curr = frontier.Dequeue();
		
		if (map[curr.Y][curr.X] == '$') found++;
		map[curr.Y][curr.X] = '#';

		var px = curr.X;
		var py = curr.Y+1;
		if (IsValidPos(n, py, px) && map[py][px] != '#')
		{
		    var p = new Pos(px, py);
		    if (!frontier.Contains(p))
		    {
			frontier.Enqueue(p);
	//		map[py][px] = '#';
		    }
			
		}

		px = curr.X;
		py = curr.Y-1;
		if (IsValidPos(n, py, px) && map[py][px] != '#')
		{
		    var p = new Pos(px, py);
		    if (!frontier.Contains(p))
		    {
			frontier.Enqueue(p);
	//		map[py][px] = '#';
		    }
		}

		px = curr.X+1;
		py = curr.Y;
		if (IsValidPos(n, py, px) && map[py][px] != '#')
		{
		    var p = new Pos(px, py);
		    if (!frontier.Contains(p))
		    {
			frontier.Enqueue(p);
	//		map[py][px] = '#';
		    }
		}

		px = curr.X-1;
		py = curr.Y;
		if (IsValidPos(n, py, px) && map[py][px] != '#')
		{
		    var p = new Pos(px, py);
		    if (!frontier.Contains(p))
		    {
			frontier.Enqueue(p);
	//		map[py][px] = '#';
		    }
		}

	    }
	    
	    Console.WriteLine(found);
	}

	private bool IsValidPos(int n, int y, int x)
	{
	    n--;
	    return !(x < 0 || y < 0 || x > n || y > n);
	}
    }
}