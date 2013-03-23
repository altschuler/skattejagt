REFS = -r:System.Windows.Forms -r:System.Drawing

# A
AFILES = ProgramA.cs Helper.cs
a:
	mcs $(AFILES)
	mono ProgramA.exe

azip:
	rm -f ProgramA.zip
	zip ProgramA $(AFILES)


# B
BFILES = ProgramB.cs Helper.cs INode.cs BFNode.cs FullSearch.cs Map.cs MapGraph.cs PriorityQueue.cs Action.cs State.cs Tile.cs
b:
	mcs $(BFILES)
	mono ProgramB.exe

bzip:
	rm -f ProgramB.zip
	zip ProgramB $(BFILES)

bpaint:
	mcs $(REFS) PaintProgramB.cs $(filter-out $(wildcard Program*.cs), $(wildcard *.cs))
	mono PaintProgramB.exe

# C
CFILES = ProgramC.cs Helper.cs INode.cs BFNode.cs BFSearch.cs Map.cs MapGraph.cs PriorityQueue.cs Action.cs State.cs Tile.cs
c:
	mcs $(CFILES)
	mono ProgramC.exe

czip:
	rm -f ProgramC.zip
	zip ProgramC $(CFILES)

cpaint:
	mcs $(REFS) PaintProgramC.cs $(filter-out $(wildcard Program*.cs), $(wildcard *.cs))
	mono PaintProgramC.exe