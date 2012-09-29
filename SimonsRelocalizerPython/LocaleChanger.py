#-------------------------------------------------------------------------------
# Name:        LocaleChanger
# Purpose:     Changes the locale of SC2
#
# Author:      Simon Liang
#
# Created:     08/08/2012
# Copyright:   (c) Haoran Liang 2012
# Licence:     MIT License
#-------------------------------------------------------------------------------

import Settings
import Constants
import shutil
import os

def changeAgentDB(newLocale):
    agentDB = open(Settings.SC2_LOCATION + ".agent.db", "r")
    content = agentDB.read()
    content = changeLocale(content, newLocale)
    agentDB.close()
    agentDB = open(Settings.SC2_LOCATION + ".agent.db", "w")
    agentDB.write(content)
    agentDB.close()

def changeLauncherDB(newLocale):
    launcherDB = open(Settings.SC2_LOCATION + "Launcher.db", "r")
    content = launcherDB.read()
    content = changeLocale(content, newLocale)
    launcherDB.close()
    launcherDB = open(Settings.SC2_LOCATION + "Launcher.db", "w")
    launcherDB.write(content)
    launcherDB.close()

def changeProductSC2Archive(newLocale):
    path = Settings.SC2_LOCATION + "Mods/Core.SC2Mod/Product.SC2Archive"
    os.remove(path)
    shutil.copyfile(Constants.PRODUCT_SC2ARCHIVE_LOCATION + newLocale, path)

def changeLocale(content, newLocale):
    for locale in Constants.LOCALES:
        if locale in content:
            content = content.replace(locale, newLocale)
        if locale.lower() in content:
            content = content.replace(locale.lower(), newLocale.lower())
    return content

def changeVarTxt(newLocale, newAsset):
    VarTxt = open(Settings.SC2_VARTXT_LOCATION, "r")
    lines = VarTxt.readlines()
    VarTxt.close()
    for i in range(len(lines)):
        if lines[i].startswith("localeiddata="):
            lines[i] = "localeiddata=" + newLocale + "\n"
        elif lines[i].startswith("localeidassets="):
            lines[i] = "localeidassets=" + newAsset + "\n"
    VarTxt = open(Settings.SC2_VARTXT_LOCATION, "w")
    VarTxt.write("".join(lines))
    VarTxt.close()