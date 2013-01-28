using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace SimonsRelocalizer.Modules
{
    class SettingsManager
    {
        public static string SC2Name = "StarCraft II";

        public static string currentLocale = "enUS";
        public static string currentAsset = "enUS";
        public static string currentRegion = "enUS";

        public static bool IsInSC2Folder()
        {
            if (File.Exists("StarCraft II.exe"))
            {
                //WoL
                SC2Name = "StarCraft II";
                return true;
            }
            if (File.Exists("StarCraft II Beta.exe"))
            {
                //HotS
                SC2Name = "StarCraft II Beta";
                return true;
            }
            return false;
        }

        public static void CheckCurrentLocaleAsset()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path += "\\" + SC2Name +"\\Variables.txt";
            if (File.Exists(path))
            {
                var text = File.ReadAllText(path);
                currentLocale = Regex.Match(
                    text,
                    "(localeiddata=)([A-Za-z]{4})").Groups[2].Value;
                currentAsset = Regex.Match(
                    text,
                    "(localeidassets=)([A-Za-z]{4})").Groups[2].Value;
            }
        }

        public static void CheckCurrentRegion()
        {
            RegistryKey lastPortal = Registry.CurrentUser.OpenSubKey("Software\\Blizzard Entertainment\\Battle.net\\S2", false);
            if (lastPortal == null)
            {
                currentRegion = currentLocale;
            }
            else
            {
                currentRegion = (string)lastPortal.GetValue("LastPortal-" + currentLocale);
            }
        }
    }
}
