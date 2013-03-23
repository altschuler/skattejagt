using System;
using System.Linq;

namespace Skattejagt
{
    public class ProgramA
    {
	public static void Main()
	{
	    new ProgramA();
	}

	public ProgramA()
	{
	    var mapString = @"########
#    $ #    
#   $  #    
I  #####    
#  # $ #    
#$ ### #    
#      #    
########";

//	    var mapString = Helper.GetInput();
	    // O(n^2)
	    var amount = 0;
	    foreach (var c in mapString)
	    {
		if (c == '$') amount++;
	    }
	    
	    Console.WriteLine(amount);
	}
    }
}