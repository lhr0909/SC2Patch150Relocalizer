using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer.Modules
{
    class LocaleChanger
    {

        public static void RunRelocalize()
        {
            AddRegionXML();
            ChangeAgentDB(Program.currentLocale, Program.newLocale);
            ChangeLauncherDB(Program.currentLocale, Program.newLocale);
            ChangeProductSC2Archive(Program.newLocale);
            ChangeVarTXT(Program.currentLocale, Program.currentAsset, Program.newLocale, Program.newAsset);
            ChangeRegion(Program.newLocale, Program.newRegion);
        }

        private static void ChangeRegion(string locale, string region)
        {
            RegistryKey lastPortal = Registry.CurrentUser.OpenSubKey("Software\\Blizzard Entertainment\\Battle.net\\S2", true);
            lastPortal.SetValue("LastPortal-" + locale, region, RegistryValueKind.String);
        }

        public static void AddRegionXML()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var filePath = Settings.Default.SC2Location + "regions.xml";
            if (File.Exists(filePath)) File.Delete(filePath);
            var dest = File.Open(filePath, FileMode.OpenOrCreate);
            var names = assembly.GetManifestResourceNames();
            foreach (string name in names)
            {
                if (name.EndsWith("regions.xml"))
                {
                    var regionsFile = assembly.GetManifestResourceStream(name);
                    if (regionsFile != null) regionsFile.CopyTo(dest);
                    dest.Close();
                    regionsFile.Close();
                }
            }
        }

        public static void ChangeAgentDB(string originalLanguage, string relocalizeLanguage)
        {
            //Change .agent.db
            var filePath = Settings.Default.SC2Location + ".agent.db";
            //BackupFile(filePath);
            var text = File.ReadAllText(filePath);
            text = CheckAndReplaceTextInFile(originalLanguage, relocalizeLanguage, text);
            File.Delete(filePath);
            File.WriteAllText(filePath, text);
        }

        public static void ChangeLauncherDB(string originalLanguage, string relocalizeLanguage)
        {
            //Change Launcher.db
            var filePath = Settings.Default.SC2Location + "Launcher.db";
            //BackupFile(filePath);
            var text = File.ReadAllText(filePath);
            text = CheckAndReplaceTextInFile(originalLanguage, relocalizeLanguage, text);
            File.WriteAllText(filePath, text);
        }

        public static void ChangeProductSC2Archive(string relocalizeLanguage)
        {
            //Change Product.SC2Archive
            //those files are MPQ's, it contains a single text file in the package with the locale written in the text file.
            //Use http://www.zezula.net/en/mpq/download.html to unpack and edit.

            var assembly = Assembly.GetExecutingAssembly();
            var filePath = Settings.Default.SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive";
            //BackupFile(filePath);
            File.Delete(filePath);
            var dest = File.Open(filePath, FileMode.OpenOrCreate);
            var names = assembly.GetManifestResourceNames();
            foreach (string name in names)
            {
                if (name.EndsWith(relocalizeLanguage))
                {
                    var relocalizeFile = assembly.GetManifestResourceStream(name);
                    if (relocalizeFile != null) relocalizeFile.CopyTo(dest);
                    dest.Close();
                    relocalizeFile.Close();
                }
            }
        } 

        public static void ChangeVarTXT(string originalLanguage, string originalAsset, string relocalizeLanguage, string relocalizeAsset)
        {
            //change variable.txt
            var sc2VarLocation = Settings.Default.SC2VariablesLocation;
            //BackupFile(sc2VarLocation);
            var originalLanguageSearch = "localeiddata=" + originalLanguage;
            var relocalizeLang = "localeiddata=" + relocalizeLanguage; 
            var originalAssetSearch = "localeidassets=" + originalAsset;
            var relocalizeAsst = "localeidassets=" + relocalizeAsset;
            var text = File.ReadAllText(sc2VarLocation);
            text = text.Replace(originalLanguageSearch, relocalizeLang);
            text = text.Replace(originalAssetSearch, relocalizeAsst);
            File.WriteAllText(sc2VarLocation, text);
        }

        public static bool CheckIfAssetExists(string asset)
        {
            var filePath = Settings.Default.SC2Location + "Mods\\Core.SC2Mod\\" + asset + ".SC2Data";
            return File.Exists(filePath);
        }

        private static string CheckAndReplaceTextInFile(string originalLanguage, string relocalizeLanguage, string text)
        {
            if (text.Contains(originalLanguage) || text.Contains(originalLanguage.ToLower()))
            {
                text = text.Replace(originalLanguage, relocalizeLanguage);
                text = text.Replace(originalLanguage.ToLower(), relocalizeLanguage.ToLower());
            }
            else
            {
                //make sure that the value is correct in those files
                foreach (string value in Program.languageList)
                {
                    var locale = GetLocaleFromLanguageListItem(value);
                    text = text.Replace(locale, relocalizeLanguage);
                    text = text.Replace(locale.ToLower(), relocalizeLanguage.ToLower());
                }
            }
            return text;
        }

        /*
        private static void BackupFile(string filePath)
        {
            //make backups up to 5 previous changes
            int version = 1;
            while ((File.Exists(filePath + ".version" + version)) && (version < 6))
            {
                version = version + 1;
            }
            if (version > 5)
            {
                File.Copy(filePath, filePath + ".version" + version);
                for (int i = 1; i <= 6; i++)
                {
                    var fileNameFrom = filePath + ".version" + i;
                    var fileNameTo = filePath + ".version" + (i - 1);
                    File.Move(fileNameFrom, fileNameTo);
                }
                File.Delete(filePath + ".version0");
            }
            else
            {
                File.Copy(filePath, filePath + ".version" + version);
            }
        }
        */

        public static string GetLocaleFromLanguageListItem(string item)
        {
            return Regex.Split(item, " - ")[2];
        }

        public static string GetRegionFromRegionListItem(string region)
        {
            if (region.StartsWith("AM"))
            {
                return "us";
            }
            if (region.StartsWith("EU"))
            {
                return "eu";
            }
            if (region.StartsWith("SEA"))
            {
                return "sg";
            }
            if (region.StartsWith("KR"))
            {
                return "kr";
            }
            return Program.newLocale;
        }
    }
}
