using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Skattejagt
{

    struct Tile
    {
	public int Y;
	public int X;

	public Tile(int x, int y)
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
	    Console.ReadLine();
	    var mapString = "";
	    var next = Console.ReadLine();
	    while (next != null)
	    {
	    	mapString += next + "\n";
	    	next = Console.ReadLine();
	    }

	    //var mapString = File.ReadAllText("map2.txt");
	 
	    var rows = mapString.Split('\n');    
	    var n = rows.Length-1;
	    var map = new List<char[]>();
	    for (var i = 0; i < n; i++)
		map.Add(rows[i].ToCharArray());

	    var entry = new Tile();
	    // find indgangen, antag at der er praecis en (tager foerste)
	    for (var y = 0; y < n; ++y)
		for (int x = 0; x < n; ++x)
		    if (map[y][x] == 'I') 
			entry = new Tile() { X = x, Y = y };
	    
	    // initialiser en koe over felter som skal undersoeges
	    var frontier = new Queue<Tile>();
	    // tilfoej indgangen som foerste felt der skal undersoeges
	    frontier.Enqueue(entry);
	    // variabel som bruges til at taelle tilgaengelige skatte
	    var found = 0;
	    while (frontier.Count > 0)
	    {
		// tag foerste element ud af koeen
		var curr = frontier.Dequeue();
		// saet feltet som vaerende vaeg for ikke at undersoege det igen
		map[curr.Y][curr.X] = '#';
		
		// undersoeg om felter oven, under, til hoejre 
		// og til venstre er gyldige at gaa videre paa
		ProcessTile(n,curr.X-1, curr.Y, ref found, frontier, map);
		ProcessTile(n,curr.X+1, curr.Y, ref found, frontier, map);
		ProcessTile(n,curr.X, curr.Y+1, ref found, frontier, map);
		ProcessTile(n,curr.X, curr.Y-1, ref found, frontier, map);	
	    }
	    
	    Console.WriteLine(found);
	}

	private void ProcessTile(int n, int px, int py, ref int found, Queue<Tile> frontier, List<char[]> map)
	{
	    // tjek om koordinatet er inden for kortets rammer
	    // og at den i saa fald er gyldig at gaa videre paa (ikke er vaeg)
	    if (!(px < 0 || py < 0 || px > (n-1) || py > (n-1))
		&& map[py][px] != '#')
	    {
		var p = new Tile(px, py);
		// tael en op hvis feltet er en skat
		if (map[py][px] == '$') 
		    found++;
		// tilfoej feltet til koeen over felter der skal gaas videre paa
		frontier.Enqueue(p);
		// saet feltet som vaerende ugyldig at tilfoeje til listen 
		// over utjekkede felter (der er netop blevet gjort og maa ikke goeres igen)
		map[py][px] = '#';
	    }
	}
    }
}