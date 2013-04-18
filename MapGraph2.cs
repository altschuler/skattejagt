using System;
using System.Collections.Generic;
using System.Linq;

namespace Skattejagt
{
    public class MapGraph2
    {
	public List<Action> Actions { get; set; }
	public List<State> States { get; set; }

	public static MapGraph2 Parse(Map map)
	{
	    var kb = new MapGraph2();
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
		    
		    var state = kb.GetOrCreateState(j, i, tile, map);

		    // adjacent tiles
		    var n = kb.GetOrCreateState(j, i-1, map.TileAt(j, i-1), map);
		    var e = kb.GetOrCreateState(j+1, i, map.TileAt(j+1, i), map);
		    var s = kb.GetOrCreateState(j, i+1, map.TileAt(j, i+1), map);
		    var w = kb.GetOrCreateState(j-1, i, map.TileAt(j-1, i), map);

		    // actions between tile and adjacent
		    // TODO why opposite N/S?
		    kb.GetOrCreateAction(state, n, "N");
		    kb.GetOrCreateAction(state, e, "E");
		    kb.GetOrCreateAction(state, s, "S");
		    kb.GetOrCreateAction(state, w, "W");
		}	
	    }

	    return kb;
	}
	
	public List<State> Treasures
	{
	    get
	    {
		return this.States.Where(s => s.Type.Equals(Tile.Treasure)).ToList();
	    }
	}
	
	public List<State> Entries
	{
	    get
	    {
		return this.States.Where(s => s.Type.Equals(Tile.Entry)).ToList();
	    }
	}

	protected Action GetOrCreateAction(State a, State b, string name)
	{
	    // no action to no state
	    if (a == null || b == null || a.Type == Tile.Wall || b.Type == Tile.Wall) return null;

	    // check if action already exists
	    var action = this.Actions.SingleOrDefault(act => (act.StateA.Equals(a) && act.StateB.Equals(b)) || (act.StateA.Equals(b) && act.StateB.Equals(a)));
	    if (action == null)
	    {
		action = new Action(a, b, name);
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