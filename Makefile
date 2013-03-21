REFS = -r:System.Windows.Forms

a:
	mcs $(REFS) ProgramA.cs Map.cs Tile.cs
	mono ProgramA.exe