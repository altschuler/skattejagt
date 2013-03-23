using System;

namespace Skattejagt
{
    public class Helper
    {
	public static string GetInput()
	{
	    // Ignore size
	    Console.ReadLine();

	    var input = "";
	    var next = Console.ReadLine();
	    while (next != null)
	    {
		input += next + "\n";
		next = Console.ReadLine();
	    }
	    return input;
	}
    }
}