import sys
from tkinter import *
from tkinter import Tk, Label, Button, Entry, IntVar, END, W, E
from tkinter import ttk
import question_answering

def calculate(*args):
    try:
        value = string.get()
        answer = question_answering.qa(value)
        meters.set(answer)
    except ValueError:
        pass
# check their answer function
def calculate2(*args):
    try:
        value2 = ans.get()
        #correct.set('Yo Momma2')
    except ValueError:
        pass
    
root = Tk()
root.title("NLP- tinyWatson by Ishta & Kevin")

mainframe = ttk.Frame(root, padding="3 3 12 12")
mainframe.grid(column=0, row=0, sticky=(N, W, E, S))
mainframe.columnconfigure(0, weight=1)
mainframe.rowconfigure(0, weight=1)

string = StringVar()
meters = StringVar()

ttk.Label(mainframe, text="Enter Your Question:").grid(column=1, row=1, sticky=W)
string_entry = ttk.Entry(mainframe, width=61, textvariable=string)
string_entry.grid(column=2, row=1, sticky=(W, E))

ttk.Label(mainframe, textvariable=meters).grid(column=2, row=2, sticky=(W, E))
ttk.Button(mainframe, text="Ask!", command=calculate).grid(column=3, row=1, sticky=W)
ttk.Label(mainframe, text="Answer:").grid(column=1, row=2, sticky=E)
ttk.Label(mainframe, text="Try Again?").grid(column=1, row=3, sticky=W)

#Second Part where the user answer question we asked- we can do 1 question for why not?
ans = StringVar()
correct = StringVar()

#ttk.Label(mainframe, text="Answer this Question:").grid(column=4, row=1, sticky=W)
#ans_entry = ttk.Entry(mainframe, width=21, textvariable=ans)
#ans_entry.grid(column=4, row=2, sticky=(W, E))

#ttk.Label(mainframe, textvariable=correct).grid(column=4, row=3, sticky=(W, E))
#ttk.Button(mainframe, text="Submit", command=calculate2).grid(column=5, row=2, sticky=W)
#ttk.Label(mainframe, text="Correct?:").grid(column=4, row=3, sticky=E)
#ttk.Label(mainframe, text="Who won Oscar for Best Film in 2008?").grid(column=4, row=1, sticky=W)

for child in mainframe.winfo_children(): child.grid_configure(padx=5, pady=5)

string_entry.focus()
#ans_entry.focus()
root.bind('<Return>', calculate)

root.mainloop()

