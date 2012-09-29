#!/usr/bin/env python

#-------------------------------------------------------------------------------
# Name:        Relocalizer_mac.py
# Purpose:     Relocalizer Mac OS X Colsole Interface
#
# Author:      Simon Liang
#
# Created:     08/08/2012
# Copyright:   (c) Haoran Liang 2012
# Licence:     MIT License
#-------------------------------------------------------------------------------

import os
import sys
import time
from zipfile import ZipFile

def clearConsole():
    os.system('clear')

def downloadFile():
    return

def unzipFile():
    return

def printListOfLanguages():
    clearConsole()
    print "List of supported locales:"
    print
    print "enUS --- AM - English (US)"
    print "esMX --- AM - Spanish (Mexico)"
    print "ptBR --- AM - Portuguese"
    print "zhCN --- CN - Simplified Chinese"
    print "enGB --- EU - English (UK)"
    print "frFR --- EU - French"
    print "deDE --- EU - German"
    print "itIT --- EU - Italian"
    print "plPL --- EU - Polish"
    print "ruRU --- EU - Russian"
    print "esES --- EU - Spanish (Spain)"
    print "koKR --- KR/TW - Korean"
    print "zhTW --- KR/TW - Traditional Chinese"
    print "enSG --- SEA - English (Singapore)"
    print

ZIP_LOCATION = os.path.expanduser("~/SimonsRelocalizerMac.zip")
RELOCALIZER_LOCATION = os.path.expanduser("~/SimonsRelocalizerMac")
LOCALES = ["deDE", "enGB", "enSG", "enUS", "esES", "esMX", "frFR", "itIT", "koKR", "plPL", "ptBR", "ruRU", "zhCN", "zhTW"]

if __name__ == "__main__":
    clearConsole()
    print "Welcome to use Simon's Relocalizer!"
    print
    print "Checking files..."
    print
    if os.path.isfile(ZIP_LOCATION):
        if os.path.exists(RELOCALIZER_LOCATION):
            newLocale = ""
            printListOfLanguages()
            while newLocale not in LOCALES:
                newLocale = raw_input("Please put in the new region you want to change to (xxXX): ")
                if newLocale not in LOCALES:
                    print "Invalid input!"

            newAsset = ""
            printListOfLanguages()
            while newAsset not in LOCALES:
                newAsset = raw_input("Please put in the new voice asset you want to change to (xxXX): ")
                if newAsset not in LOCALES:
                    print "Invalid input!"

            execfile(RELOCALIZER_LOCATION + "/Relocalize.py", locals={"newLocale":newLocale, "newAsset":newAsset})
        else:
            unzipFile()
    else:
        response = raw_input("You don't have the core files downloaded. Do you want to proceed and download the necessary files to be able to use the relocalizer? (y/n) ")
        if response.startswith("y") or response.startswith("Y"):
            downloadFile()
            unzipFile()
        else:
            print "Sorry but you do need to download all the files necessary to be able to use the relocalizer!"
            sys.exit(1)