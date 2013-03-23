using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skattejagt
{
    static class FullSearch
    {
	public static int Search(List<State> states, List<Action> actions, State start, Tile target)
	{	
	    var found = 0;

	    PriorityQueue<BFNode> frontier = new PriorityQueue<BFNode>(); 
	    List<State> explored = new List<State>();

	    frontier.Add(new BFNode(start));

	    while (frontier.Count > 0)
	    {
		// Chooses the lowest-cost node in the frontier
		BFNode currentBFNode = frontier.Pop(); 
		
		// Win condition
		if (currentBFNode.State.Type.Equals(target))
		    found++;

		explored.Add(currentBFNode.State);

		// Filter actions to the ones connected to the current node
		foreach (Action action in actions.Where(a => a.StateA.Equals(currentBFNode.State)))
		{
		    // One of A or B will be the currentBFNode's action
		    // but it won't be added to the frontier since it
		    // is already in explored
		    var childA = new BFNode(currentBFNode, action, action.StateA);
		    var childB = new BFNode(currentBFNode, action, action.StateB);

		    if (!explored.Contains(childA.State) && !frontier.Any(n => n.State == childA.State))
			frontier.Add(childA);

		    if (!explored.Contains(childB.State) && !frontier.Any(n => n.State == childB.State))
			frontier.Add(childB);
		}
	    }
	    return found;
	}
    }
}
