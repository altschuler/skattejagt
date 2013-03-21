using System;
using System.Collections.Generic;
using System.Linq;

namespace Skattejagt
{
    public class Map2
    {
	public List<Action> Actions { get; set; }
	public List<State> States { get; set; }

	public static Map2 Parse(Map map)
	{
	    var kb = new Map2();
	    kb.Actions = new List<Action>();
	    kb.States = new List<State>();
	    
	    for (var i = 0; i < map.Tiles.Count; i++)
	    {
		var row = map.Tiles[i];
		for (var j = 0; j < row.Count; j++)
		{
		    var tile = row[j];

		    // skip wall tiles
		    if (tile.Equals(Tile.Wall)) continue;
		    
		    var state = kb.GetOrCreateState(i, j, tile, map);

		    // adjacent tiles
		    var n = kb.GetOrCreateState(i, j-1, map.TileAt(i, j-1), map);
		    var e = kb.GetOrCreateState(i+1, j, map.TileAt(i+1, j), map);
		    var s = kb.GetOrCreateState(i, j+1, map.TileAt(i, j+1), map);
		    var w = kb.GetOrCreateState(i-1, j, map.TileAt(i-1, j), map);

		    // actions between tile and adjacent
		    var na = kb.GetOrCreateAction(state, n);
		    var ea = kb.GetOrCreateAction(state, e);
		    var sa = kb.GetOrCreateAction(state, s);
		    var wa = kb.GetOrCreateAction(state, w);
		}	
	    }

	    return kb;
	}
	
	protected Action GetOrCreateAction(State a, State b)
	{
	    // no action to no state
	    if (a == null || b == null) return null;

	    // check if action already exists
	    var action = this.Actions.SingleOrDefault(act => (act.StateA.Equals(a) && act.StateB.Equals(b)) || (act.StateA.Equals(b) && act.StateB.Equals(a)));
	    if (action == null)
	    {
		action = new Action(a, b);
		this.Actions.Add(action);
	    }

	    return action;
	}

	protected State GetOrCreateState(int px, int py, Tile type, Map map)
	{
	    // check bounds
	    if (type == Tile.Invalid) return null;
	    if (px < 0  || py < 0 || px > map.Tiles[0].Count - 1 || py > map.Tiles.Count - 1) return null;
	    
	    // check if state already exists
	    var state = this.States.SingleOrDefault(s => s.X == px && s.Y == py);
	    if (state == null)
	    {
		state = new State(px, py, type);
		this.States.Add(state);
	    }

	    return state;
	}
    }
}