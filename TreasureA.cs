using System;
using System.Text;

namespace Skattejagt
{
    public class TreasureA
    {
	public static void Main()
	{
	    new TreasureA();
	}

	public TreasureA()
	{
	    var mapBuilder = new StringBuilder();
	    var next = Console.ReadLine();
	    while (next != null)
	    	mapBuilder.Append(next = Console.ReadLine());
	    var mapString = mapBuilder.ToString();

	    var amount = 0;
	    foreach (var ch in mapString)
		if (ch == '$') 
		    amount++;
	    
	    Console.WriteLine(amount);
	}
    }
}