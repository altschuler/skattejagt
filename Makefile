REFS = -r:System.Windows.Forms -r:System.Drawing

a:
	mcs $(REFS) ProgramA.cs $(filter-out ProgramA.cs, $(wildcard *.cs))
	mono ProgramA.exe