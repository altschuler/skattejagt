using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skattejagt
{
    public class Action
    {
	public State StateA { get; set; }
	public State StateB { get; set; }
	public double Cost { get; set; }

	public Action(State stateA, State stateB)
	{
	    this.StateA = stateA;
	    this.StateB = stateB;
	    this.Cost = 1;
	}
    }
}
