using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skattejagt
{
    public class BFNode : IComparable, INode
    {
	public double EstimatedTotalPathCost { get; set; }
	public double PathCost { get; set; }
	public State State { get; set; }
	public INode Parent { get; set; }
	public Action Action { get; set; }

	public BFNode(BFNode parent, Action action, State state)
	{
	    this.State = state;
	    this.Parent = parent;
	    this.Action = action;
	    if (this.Parent != null && this.Action != null)
		this.PathCost = this.Parent.PathCost + action.Cost;

	    this.EstimatedTotalPathCost = this.PathCost;
	}

	public BFNode(BFNode parent, Action action) : this(parent, action, action.StateA) {}

	public BFNode(State state) : this(null, null, state) {}

	public int CompareTo(object obj)
	{
	    var other = obj as BFNode;
	    if (this.EstimatedTotalPathCost > other.EstimatedTotalPathCost)
		return 1;
	    if (this.EstimatedTotalPathCost < other.EstimatedTotalPathCost)
		return -1;
	    return 0;
	}
    }
}
