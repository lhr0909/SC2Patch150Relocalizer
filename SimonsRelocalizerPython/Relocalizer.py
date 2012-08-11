#! /usr/bin/env python
# -*- python -*-

import sys

py2 = py30 = py31 = False
version = sys.hexversion
if version >= 0x020600F0 and version < 0x03000000 :
    py2 = True    # Python 2.6 or 2.7
    from Tkinter import *
    import ttk
elif version >= 0x03000000 and version < 0x03010000 :
    py30 = True
    from tkinter import *
    import ttk
elif version >= 0x03010000:
    py31 = True
    from tkinter import *
    import tkinter.ttk as ttk
else:
    print ("""
    You do not have a version of python supporting ttk widgets..
    You need a version >= 2.6 to execute PAGE modules.
    """)
    sys.exit()



def vp_start_gui():
    '''Starting point when module is the main routine.'''
    global val, w, root
    root = Tk()
    root.title('SimonsRelocalizer')
    root.geometry('583x227+764+512')
    set_Tk_var()
    w = SimonsRelocalizer (root)
    init()
    root.mainloop()

w = None
def create_SimonsRelocalizer (root):
    '''Starting point when module is imported by another program.'''
    global w, w_win
    if w: # So we have only one instance of window.
        return
    w = Toplevel (root)
    w.title('SimonsRelocalizer')
    w.geometry('583x227+764+512')
    set_Tk_var()
    w_win = SimonsRelocalizer (w)
    init()
    return w_win

def destroy_SimonsRelocalizer ():
    global w
    w.destroy()
    w = None


def set_Tk_var():
    # These are Tk variables used passed to Tkinter and must be
    # defined before the widgets using them are created.
    global SC2LocationText
    SC2LocationText = StringVar()

    global aboutText
    aboutText = StringVar()

    global assetText
    assetText = StringVar()

    global btnChangeSC2DirectoryText
    btnChangeSC2DirectoryText = StringVar()

    global btnChangeVarText
    btnChangeVarText = StringVar()

    global checkLaunchSC2Text
    checkLaunchSC2Text = StringVar()

    global combobox
    combobox = StringVar()

    global langChinese
    langChinese = StringVar()

    global localeText
    localeText = StringVar()

    global pingMessageText
    pingMessageText = StringVar()

    global tch79
    tch79 = StringVar()

    global updateMessage
    updateMessage = StringVar()

    global varTxtLocationText
    varTxtLocationText = StringVar()


def init():
    pass




class SimonsRelocalizer:
    def __init__(self, master=None):
        # Set background of toplevel window to match
        # current style
        style = ttk.Style()
        theme = style.theme_use()
        default = style.lookup(theme, 'background')
        master.configure(background=default)

        self.TNotebook1 = ttk.Notebook(master)
        self.TNotebook1.place(relx=0.0,rely=0.0,relheight=0.99,relwidth=1.0)
        self.TNotebook1.configure(takefocus="")
        self.TNotebook1_pg0 = Frame(self.TNotebook1)
        self.TNotebook1.add(self.TNotebook1_pg0, padding=3)
        self.TNotebook1.tab(0, text="Relocalize",underline="-1",)
        self.TNotebook1_pg1 = Frame(self.TNotebook1)
        self.TNotebook1.add(self.TNotebook1_pg1, padding=3)
        self.TNotebook1.tab(1, text="Settings",underline="-1",)
        self.TNotebook1_pg2 = Frame(self.TNotebook1)
        self.TNotebook1.add(self.TNotebook1_pg2, padding=3)
        self.TNotebook1.tab(2, text="About",underline="-1",)
        self.TNotebook1_pg3 = Frame(self.TNotebook1)
        self.TNotebook1.add(self.TNotebook1_pg3, padding=3)
        self.TNotebook1.tab(3, text="Beer",underline="-1",)

        self.TButton1 = ttk.Button (self.TNotebook1_pg0)
        self.TButton1.place(relx=0.64,rely=0.05,height=180,width=206)
        self.TButton1.configure(takefocus="")
        self.TButton1.configure(text='''Tbutton''')
        self._img1 = PhotoImage(file="resources/relocalize_button.GIF")
        self.TButton1.configure(image=self._img1)

        self.TCombobox1 = ttk.Combobox (self.TNotebook1_pg0)
        self.TCombobox1.place(relx=0.1,rely=0.15,relheight=0.12,relwidth=0.51)
        self.TCombobox1.configure(textvariable=combobox)
        self.TCombobox1.configure(takefocus="")

        self.TCombobox2 = ttk.Combobox (self.TNotebook1_pg0)
        self.TCombobox2.place(relx=0.1,rely=0.4,relheight=0.12,relwidth=0.51)
        self.TCombobox2.configure(textvariable=combobox)
        self.TCombobox2.configure(takefocus="")

        self.TLabel1 = ttk.Label (self.TNotebook1_pg0)
        self.TLabel1.place(relx=0.1,rely=0.05,height=17,width=4)
        self.TLabel1.configure(relief="flat")
        self.TLabel1.configure(textvariable=localeText)

        self.TLabel2 = ttk.Label (self.TNotebook1_pg0)
        self.TLabel2.place(relx=0.1,rely=0.3,height=17,width=4)
        self.TLabel2.configure(relief="flat")
        self.TLabel2.configure(textvariable=assetText)

        self.TLabel3 = ttk.Label (self.TNotebook1_pg0)
        self.TLabel3.place(relx=0.05,rely=0.1,height=29,width=29)
        self.TLabel3.configure(relief="flat")
        self.TLabel3.configure(text='''Tlabel''')
        self._img2 = PhotoImage(file="resources/relocalization.GIF")
        self.TLabel3.configure(image=self._img2)

        self.TLabel4 = ttk.Label (self.TNotebook1_pg0)
        self.TLabel4.place(relx=0.05,rely=0.35,height=29,width=29)
        self.TLabel4.configure(relief="flat")
        self.TLabel4.configure(text='''Tlabel''')
        self._img3 = PhotoImage(file="resources/voice_asset.GIF")
        self.TLabel4.configure(image=self._img3)

        self.TCheckbutton1 = ttk.Checkbutton (self.TNotebook1_pg0)
        self.TCheckbutton1.place(relx=0.1,rely=0.55,relheight=0.12
            ,relwidth=0.04)
        self.TCheckbutton1.configure(variable=tch79)
        self.TCheckbutton1.configure(takefocus="")
        self.TCheckbutton1.configure(textvariable=checkLaunchSC2Text)

        self.TLabel5 = ttk.Label (self.TNotebook1_pg0)
        self.TLabel5.place(relx=0.1,rely=0.7,height=17,width=4)
        self.TLabel5.configure(relief="flat")
        self.TLabel5.configure(textvariable=pingMessageText)

        self.TLabel6 = ttk.Label (self.TNotebook1_pg0)
        self.TLabel6.place(relx=0.1,rely=0.8,height=17,width=4)
        self.TLabel6.configure(relief="flat")
        self.TLabel6.configure(textvariable=updateMessage)

        self.TButton2 = ttk.Button (self.TNotebook1_pg1)
        self.TButton2.place(relx=0.05,rely=0.04,height=24,width=77)
        self.TButton2.configure(takefocus="")
        self.TButton2.configure(textvariable=btnChangeSC2DirectoryText)

        self.TButton3 = ttk.Button (self.TNotebook1_pg1)
        self.TButton3.place(relx=0.05,rely=0.22,height=24,width=77)
        self.TButton3.configure(takefocus="")
        self.TButton3.configure(textvariable=btnChangeVarText)

        self.TLabel7 = ttk.Label (self.TNotebook1_pg1)
        self.TLabel7.place(relx=0.19,rely=0.04,height=17,width=4)
        self.TLabel7.configure(relief="flat")
        self.TLabel7.configure(textvariable=SC2LocationText)

        self.TLabel8 = ttk.Label (self.TNotebook1_pg1)
        self.TLabel8.place(relx=0.19,rely=0.22,height=17,width=4)
        self.TLabel8.configure(relief="flat")
        self.TLabel8.configure(textvariable=varTxtLocationText)

        self.TCheckbutton2 = ttk.Checkbutton (self.TNotebook1_pg1)
        self.TCheckbutton2.place(relx=0.05,rely=0.49,relheight=0.1
            ,relwidth=0.23)
        self.TCheckbutton2.configure(variable=langChinese)
        self.TCheckbutton2.configure(takefocus="")
        self.TCheckbutton2.configure(text='''Check here for Chinese''')
        self.TCheckbutton2.configure(state="active")

        self.TLabel9 = ttk.Label (self.TNotebook1_pg2)
        self.TLabel9.place(relx=0.03,rely=0.04,height=17,width=4)
        self.TLabel9.configure(relief="flat")
        self.TLabel9.configure(textvariable=aboutText)

        self.Scrolledtext5 = ScrolledText (self.TNotebook1_pg2)
        self.Scrolledtext5.place(relx=0.0,rely=0.0,relheight=0.82,relwidth=0.46)

        self.Scrolledtext5.configure(background="white")
        self.Scrolledtext5.configure(wrap="word")

        self.Scrolledtext6 = ScrolledText (self.TNotebook1_pg2)
        self.Scrolledtext6.place(relx=0.51,rely=0.0,relheight=0.82
            ,relwidth=0.48)
        self.Scrolledtext6.configure(background="white")
        self.Scrolledtext6.configure(wrap="word")

        self.TLabel10 = ttk.Label (self.TNotebook1_pg3)
        self.TLabel10.place(relx=0.07,rely=0.04,height=47,width=501)
        self.TLabel10.configure(relief="flat")
        self.TLabel10.configure(wraplength="500")
        self.TLabel10.configure(text='''Thanks for all the support! If you really like it and like to buy me a beer, you can always drop me some change and I will definitely appreciate it!''')

        self.TButton4 = ttk.Button (self.TNotebook1_pg3)
        self.TButton4.place(relx=0.38,rely=0.4,height=24,width=146)
        self.TButton4.configure(takefocus="")
        self.TButton4.configure(text='''Click here to buy me a beer!''')

        self.TLabel11 = ttk.Label (self.TNotebook1_pg3)
        self.TLabel11.place(relx=0.29,rely=0.31,height=49,width=46)
        self.TLabel11.configure(relief="flat")
        self.TLabel11.configure(text='''Tlabel''')
        self._img4 = PhotoImage(file="resources/buy_me_a_beer.gif")
        self.TLabel11.configure(image=self._img4)






# The following code is added to facilitate the Scrolled widgets you specified.
class AutoScroll(object):
    '''Configure the scrollbars for a widget.'''

    def __init__(self, master):
        vsb = ttk.Scrollbar(master, orient='vertical', command=self.yview)
        hsb = ttk.Scrollbar(master, orient='horizontal', command=self.xview)

        self.configure(yscrollcommand=self._autoscroll(vsb),
            xscrollcommand=self._autoscroll(hsb))
        self.grid(column=0, row=0, sticky='nsew')
        vsb.grid(column=1, row=0, sticky='ns')
        hsb.grid(column=0, row=1, sticky='ew')

        master.grid_columnconfigure(0, weight=1)
        master.grid_rowconfigure(0, weight=1)

        # Copy geometry methods of master  (took from ScrolledText.py)
        if py31:
            methods = Pack.__dict__.keys() | Grid.__dict__.keys()\
            | Place.__dict__.keys()
        else:
            methods = Pack.__dict__.keys() + Grid.__dict__.keys()\
            + Place.__dict__.keys()

        for meth in methods:
            if meth[0] != '_' and meth not in ('config', 'configure'):
                setattr(self, meth, getattr(master, meth))

    @staticmethod
    def _autoscroll(sbar):
        '''Hide and show scrollbar as needed.'''
        def wrapped(first, last):
            first, last = float(first), float(last)
            if first <= 0 and last >= 1:
                sbar.grid_remove()
            else:
                sbar.grid()
            sbar.set(first, last)
        return wrapped

    def __str__(self):
        return str(self.master)

def _create_container(func):
    '''Creates a ttk Frame with a given master, and use this new frame to
    place the scrollbars and the widget.'''
    def wrapped(cls, master, **kw):
        container = ttk.Frame(master)
        return func(cls, container, **kw)
    return wrapped

class ScrolledText(AutoScroll, Text):
    '''A standard Tkinter Text widget with scrollbars that will
    automatically show/hide as needed.'''
    @_create_container
    def __init__(self, master, **kw):
        Text.__init__(self, master, **kw)
        AutoScroll.__init__(self, master)

if __name__ == '__main__':
    vp_start_gui()