import sys
import os
if sys.platform.startswith("darwin"):
    SC2_LOCATION = "/Applications/StarCraft II/"
    SC2_VARTXT_LOCATION = os.path.expanduser("~/Library/Application Support/Blizzard/StarCraft II/Variables.txt")
else:
    SC2_LOCATION = os.environ["ProgramFiles"] + "/StarCraft II/"
    SC2_VARTXT_LOCATION = os.path.expanduser("~/StarCraft II/Variables.txt")