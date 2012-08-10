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

def changeAgentDB(newLocale):
    agentDB = open(Settings.SC2_LOCATION + ".agent.db", "r")
    content = agentDB.read()
    for locale in Constants.LOCALES:
        if locale in content:
            content = content.replace(locale, newLocale)
        if locale.lower() in content:
            content = content.replace(locale.lower(), newLocale.lower())
    agentDB.close()
    agentDB = open(Settings.SC2_LOCATION + ".agent.db", "w")
    agentDB.write(content)
    agentDB.close()

def changeLauncherDB(newLocale):
    launcherDB = open(Settings.SC2_LOCATION + "Launcher.db", "r")
    content = launcherDB.read()
    for locale in Constants.LOCALES:
        if locale in content:
            content = content.replace(locale, newLocale)
        if locale.lower() in content:
            content = content.replace(locale.lower(), newLocale.lower())
    launcherDB.close()
    launcherDB = open(Settings.SC2_LOCATION + "Launcher.db", "w")
    launcherDB.write(content)
    launcherDB.close()