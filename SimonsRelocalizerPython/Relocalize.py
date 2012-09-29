#-------------------------------------------------------------------------------
# Name:        Relocalize.py
# Purpose:     Runs the relocalizing procedure
#
# Author:      Simon Liang
#
# Created:     08/08/2012
# Copyright:   (c) Haoran Liang 2012
# Licence:     MIT License
#-------------------------------------------------------------------------------

import LocaleChanger

newLocale = locals()["newLocale"]
newAsset = locals()["newAsset"]

LocaleChanger.changeAgentDB(newLocale)
LocaleChanger.changeLauncherDB(newLocale)
LocaleChanger.changeProductSC2Archive(newLocale)
LocaleChanger.changeVarTxt(newLocale, newAsset)