REFS = -r:System.Windows.Forms -r:System.Drawing

a:
	mcs $(REFS) ProgramA.cs $(filter-out $(wildcard Program*.cs), $(wildcard *.cs))
	mono ProgramA.exe

pb:
	mcs $(REFS) PaintProgramB.cs $(filter-out $(wildcard Program*.cs), $(wildcard *.cs))
	mono PaintProgramB.exe

b:
	mcs ProgramB.cs INode.cs BFNode.cs BFSearch.cs Map.cs MapGraph.cs Node.cs PriorityQueue.cs Action.cs State.cs Tile.cs
	mono ProgramB.exe