#-------------------------------------------------------------------------------
# Name:        LocaleChanger_spec.py
# Purpose:     Spec Tests for LocaleChanger
#
# Author:      Simon Liang
#
# Created:     08/08/2012
# Copyright:   (c) Haoran Liang 2012
# Licence:     MIT License
#-------------------------------------------------------------------------------

import unittest
from LocaleChanger import *
import Variables
import Settings

class LocaleChangerSpec(unittest.TestCase):
    def setUp(self):
        Variables.currentLocale = "enUS"
        Variables.currentAsset = "enUS"
        Variables.newLocale = "zhTW"
        Variables.newAsset = "zhTW"
        Settings.SC2_LOCATION = "fixtures/"
        Settings.SC2_VARTXT_LOCATION = "fixtures/Variables.txt"

    def test_changeAgentDB(self):
        agentDB = open("fixtures/.agent.db")
        content = agentDB.read()
        self.assertEqual(content.count("enUS"), 3)
        self.assertEqual(content.count("enus"), 2)
        agentDB.close()
        changeAgentDB("zhTW")
        agentDB = open("fixtures/.agent.db")
        content = agentDB.read()
        self.assertEqual(content.count("zhTW"), 3)
        self.assertEqual(content.count("zhtw"), 2)
        agentDB.close()


if __name__ == "__main__":
    unittest.main()