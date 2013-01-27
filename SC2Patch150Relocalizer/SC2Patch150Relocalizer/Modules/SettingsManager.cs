using System;
using System.IO;
using Microsoft.Win32;
using SimonsRelocalizer.Modules;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer
{
    class SettingsManager
    {
        public static void CheckVarTxtLocation()
        {
            //check Variables.txt location
            if (File.Exists(Settings.Default.SC2VariablesLocation)) return;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\StarCraft II\\Variables.txt"))
            {
                Settings.Default.SC2VariablesLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                                               "\\StarCraft II\\Variables.txt";
                Settings.Default.Save();
                return;
            }
            var location = Program.mainForm.BrowseSc2VarTxtLocation();
            if (location != null)
            {
                LocaleChanger.SetFolderPermission(location);
                Settings.Default.SC2VariablesLocation = location + "\\Variables.txt";
                Settings.Default.Save();
                CheckVarTxtLocation();
            }
        }

        public static void CheckSc2Location()
        {
            //check sc2 folder
            if (File.Exists(Settings.Default.SC2Location + "Launcher.db")) return;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\StarCraft II\\Launcher.db"))
            {
                Settings.Default.SC2Location = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) +
                                               "\\StarCraft II\\";
                Settings.Default.Save();
                return;
            }
            var location = Program.mainForm.BrowseSc2Location();
            if (location != null)
            {
                LocaleChanger.SetFolderPermission(location);
                Settings.Default.SC2Location = location + "\\";
                Settings.Default.Save();
                CheckSc2Location();
            }
        }

        public static void checkCurrentLocale()
        {
            //read current locale
            var varTXTLines = File.ReadAllLines(Settings.Default.SC2VariablesLocation);
            foreach (string line in varTXTLines)
            {
                if (line.StartsWith("localeidassets="))
                {
                    Program.currentAsset = line.Substring(line.Length - 4, 4);
                }

                if (line.StartsWith("localeiddata="))
                {
                    Program.currentLocale = line.Substring(line.Length - 4, 4);
                }
            }
        }

        public static void checkCurrentRegion()
        {
            RegistryKey lastPortal = Registry.CurrentUser.OpenSubKey("Software\\Blizzard Entertainment\\Battle.net\\S2", false);
            if (lastPortal == null)
            {
                Program.currentRegion = Program.currentLocale;
            }
            else
            {
                Program.currentRegion = (string)lastPortal.GetValue("LastPortal-" + Program.currentLocale);
            }
        }
    }
}
