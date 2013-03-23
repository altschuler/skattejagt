REFS = -r:System.Windows.Forms -r:System.Drawing

AFILES = ProgramA.cs Helper.cs
a:
	mcs $(AFILES)
	mono ProgramA.exe

azip:
	ls ProgramA.zip | rm
	zip ProgramA $(AFILES)

bpaint:
	mcs $(REFS) PaintProgramB.cs $(filter-out $(wildcard Program*.cs), $(wildcard *.cs))
	mono PaintProgramB.exe

BFILES = ProgramB.cs Helper.cs INode.cs BFNode.cs BFSearch.cs Map.cs MapGraph.cs Node.cs PriorityQueue.cs Action.cs State.cs Tile.cs
b:
	mcs $(BFILES)
	mono ProgramB.exe

bzip:
	rm ProgramB.zip
	zip ProgramB $(BFILES)