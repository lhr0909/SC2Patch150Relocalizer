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
import shutil

class LocaleChangerSpec(unittest.TestCase):
    def setUp(self):
        Variables.currentLocale = "enUS"
        Variables.currentAsset = "enUS"
        Variables.newLocale = "zhTW"
        Variables.newAsset = "zhTW"
        Settings.SC2_LOCATION = "tmp/fixtures/"
        Settings.SC2_VARTXT_LOCATION = "tmp/fixtures/Variables.txt"
        shutil.copytree("fixtures", "tmp/fixtures")


    def test_changeAgentDB(self):
        """
        Test changeAgentDB function
        """
        agentDB = open(Settings.SC2_LOCATION + ".agent.db")
        content = agentDB.read()
        self.assertEqual(content.count("enUS"), 3)
        self.assertEqual(content.count("enus"), 2)
        agentDB.close()

        changeAgentDB("zhTW")

        agentDB = open(Settings.SC2_LOCATION + ".agent.db")
        content = agentDB.read()
        self.assertEqual(content.count("zhTW"), 3)
        self.assertEqual(content.count("zhtw"), 2)
        agentDB.close()

    def test_changeLauncherDB(self):
        """
        Test change LauncherDB function
        """
        LauncherDB = open(Settings.SC2_LOCATION + "Launcher.db")
        content = LauncherDB.read()
        self.assertEqual(content.count("enUS"), 1)
        LauncherDB.close()

        changeLauncherDB("zhTW")

        LauncherDB = open(Settings.SC2_LOCATION + "Launcher.db")
        content = LauncherDB.read()
        self.assertEqual(content.count("zhTW"), 1)
        LauncherDB.close()

    def tearDown(self):
        shutil.rmtree("tmp")



if __name__ == "__main__":
    #unittest.main()
    suite = unittest.TestLoader().loadTestsFromTestCase(TestSequenceFunctions)
    unittest.TextTestRunner(verbosity=2).run(suite)