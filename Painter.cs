using System;
using System.Drawing;

namespace Skattejagt
{
  public static class Painter
  {
    public static void DrawKnowledgeBase(Graphics gfx, Map2 kb, float scale)
    {
	// Draw map of routes
	var pen = new Pen(Color.Black) { Width = 5 };
	var offsetX = 20f;
	var offsetY = 20f;
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