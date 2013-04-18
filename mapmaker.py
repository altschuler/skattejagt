size = 1000
def row(tpe):
    r = ""
    if (tpe == "r"):
        for i in range(0,size): r += (" " if i == size - 2 else  "#")
    elif (tpe == "l"):
        for i in range(0,size): r += (" " if i == 1 else "#")
    elif (tpe == "m"):
        for i in range(0,size): r += ("#" if (i == 0 or i == size - 1) else " ")
    return r

def makemap():
    mp = ""
    for i in range(0, size):
        if i % 4 is 0:
            mp += row("r") + "\n"
        elif i % 4 is 2:
            mp += row("l") + "\n"
        elif i is size - 1:
            mp += row("m")
        else:
            mp += row("m") + "\n"
        
    return mp

f = open('bigmaze.txt', 'w')
f.write(makemap())
