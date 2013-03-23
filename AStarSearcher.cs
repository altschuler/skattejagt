using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skattejagt
{
    static class AStarSearcher
    {
	public static INode Search(List<State> states, List<Action> actions, State start, State end)
	{	
	    PriorityQueue<Node> frontier = new PriorityQueue<Node>(); 
	    List<State> explored = new List<State>();

	    frontier.Add(new Node(start, end));

	    while (frontier.Count > 0)
	    {
		// Chooses the lowest-cost node in the frontier
		Node currentNode = frontier.Pop(); 
		
		// Win condition
		if (currentNode.State.Equals(end))
		    return currentNode;   
		
		// Add currentNode to list of explored 
		explored.Add(currentNode.State);

		// Filter actions to the ones connected to the current node
		foreach (Action action in actions.Where(a => a.StateA.Equals(currentNode.State) || a.StateB.Equals(currentNode.State)))
		{
		    // One of A or B will be the currentNode's action 
		    // but it won't be added to the frontier since it 
		    // is already in explored
		    var childA = new Node(currentNode, action, action.StateA, end);
		    if (!explored.Contains(childA.State))
			frontier.Add(childA);

		    var childB = new Node(currentNode, action, action.StateB, end);
		    if (!explored.Contains(childB.State))
			frontier.Add(childB);
		}
	    }
	    
	    return null;
	}
    }
}
