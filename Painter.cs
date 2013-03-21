using System;
using System.Drawing;

namespace Skattejagt
{
  public static class Painter
  {
    public static void DrawKnowledgeBase(Graphics gfx, Map2 kb, float scale)
    {	
	var offsetX = 20f;
	var offsetY = 20f;

	var brush = new SolidBrush(Color.FromArgb(150, 0, 255, 0));
	var brushTreasure = new SolidBrush(Color.FromArgb(255, 255, 255, 0));
	var brushEntry = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
	var brushWall = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
	
	foreach (var state in kb.States)
	{
	    var b = brush;
	    if (state.Type.Equals(Tile.Treasure))
		b = brushTreasure;

	    if (state.Type.Equals(Tile.Entry))
		b = brushEntry;

	    if (state.Type.Equals(Tile.Wall))
		b = brushWall;

	    gfx.FillRectangle(b, offsetX + (state.X * scale) - 10, offsetY + (state.Y * scale) - 10, 20, 20);
	}
	    

	// Draw map of routes
	var pen = new Pen(Color.Black) { Width = 2 };
	foreach (var action in kb.Actions)
	  gfx.DrawLine(pen, offsetX + action.StateA.X * scale, offsetY + action.StateA.Y * scale, offsetX + action.StateB.X * scale, offsetY + action.StateB.Y * scale);

	//	// Draw calculated route
	//	pen = new Pen(Color.FromArgb(255, 0, 255, 0)) { Width = 3 };
	//	var last = kb.End;
	//	while (traceNode.Parent != null)
	//	{
	//	  gfx.DrawLine(pen, last.X * scale, last.Y * scale, 
	//		       traceNode.State.X * scale, traceNode.State.Y * scale);
	//	  last = traceNode.State;
	//	  traceNode = traceNode.Parent;
	//	}
	//
	//	// Draw end marker
	//	pen = new Pen(Color.FromArgb(255, 0, 0, 255)) { Width = 3 };
	//	var esize = 12;
	//	gfx.DrawEllipse(pen, 
	//			(int)(kb.End.X * scale - esize * .5), 
	//			(int)(kb.End.Y * scale - esize * .5), 
//			esize, esize);
    }
  }
}