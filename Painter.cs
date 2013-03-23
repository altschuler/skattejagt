using System;
using System.Drawing;

namespace Skattejagt
{
    public static class Painter
    {
	public static void DrawMap(Graphics gfx, MapGraph kb, float scale)
	{	
	    var offsetX = scale;
	    var offsetY = scale;

	    var brush = new SolidBrush(Color.FromArgb(150, 0, 255, 0));
	    var brushTreasure = new SolidBrush(Color.FromArgb(255, 255, 255, 0));
	    var brushEntry = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
	    var brushWall = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
	
	    foreach (var state in kb.States)
	    {
		var b = brush;
		switch (state.Type)
		{
		    case Tile.Treasure: b = brushTreasure; break;
		    case Tile.Entry: b = brushEntry; break;
		    case Tile.Wall: b = brushWall; break;
		}

		gfx.FillRectangle(b, offsetX + (state.X * scale) - 10, offsetY + (state.Y * scale) - 10, 20, 20);
	    }

	    // Draw routes
	    var pen = new Pen(Color.Black) { Width = 3 };
	    foreach (var action in kb.Actions)
		gfx.DrawLine(pen, offsetX + action.StateA.X * scale, offsetY + action.StateA.Y * scale, offsetX + action.StateB.X * scale, offsetY + action.StateB.Y * scale);
	}

	public static void DrawRoute(Graphics gfx, INode traceNode, double scale)
	{	
	    var offsetX = scale;
	    var offsetY = scale;
  
	    // Draw route
	    var pen = new Pen(Color.White) { Width = 1 };
	    var last = traceNode.State;
	    while (traceNode != null)
	    {
		gfx.DrawLine(pen, 
			     (int)(offsetX + last.X * scale), 
			     (int)(offsetY + last.Y * scale), 
			     (int)(offsetX + traceNode.State.X * scale), 
			     (int)(offsetY + traceNode.State.Y * scale));
		last = traceNode.State;
		traceNode = traceNode.Parent;
	    }
	}
    }
}