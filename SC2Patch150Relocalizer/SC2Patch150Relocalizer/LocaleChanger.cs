using System.IO;
using System.Reflection;
using SC2Patch150Relocalizer.Properties;

namespace SC2Patch150Relocalizer
{
    class LocaleChanger
    {

        public static void ChangeAgentDB(string originalLanguage, string relocalizeLanguage)
        {
            //Change .agent.db
            var filePath = Settings.Default.SC2Location + ".agent.db";
            BackupFile(filePath);
            var text = File.ReadAllText(filePath);
            text = text.Replace(originalLanguage, relocalizeLanguage);
            text = text.Replace(originalLanguage.ToLower(), relocalizeLanguage.ToLower());
            File.WriteAllText(filePath, text);
        }

        public static void ChangeLauncherDB(string originalLanguage, string relocalizeLanguage)
        {
            //Change Launcher.db
            var filePath = Settings.Default.SC2Location + "Launcher.db";
            BackupFile(filePath);
            var text = File.ReadAllText(filePath);
            text = text.Replace(originalLanguage, relocalizeLanguage);
            File.WriteAllText(filePath, text);
        }

        public static void ChangeProductSC2Archive(string relocalizeLanguage)
        {
            //Change Product.SC2Archive
            //those files are MPQ's, it contains a single text file in the package with the locale written in the text file.
            //Use http://www.zezula.net/en/mpq/download.html to unpack and edit.

            var assembly = Assembly.GetExecutingAssembly();
            var filePath = Settings.Default.SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive";
            BackupFile(filePath);
            File.Delete(filePath);
            var dest = File.Open(filePath, FileMode.OpenOrCreate);
            var names = assembly.GetManifestResourceNames();
            var productSC2ArchiveName = "SC2Patch150Relocalizer.EmbeddedResource.Product.SC2Archive." + relocalizeLanguage;
            var relocalizeFile = assembly.GetManifestResourceStream(productSC2ArchiveName);
            if (relocalizeFile != null) relocalizeFile.CopyTo(dest);
            dest.Close();
            relocalizeFile.Close();
        } 

        public static void ChangeVarTXT(string originalLanguage, string originalAsset, string relocalizeLanguage, string relocalizeAsset)
        {
            //change variable.txt
            var sc2VarLocation = Settings.Default.SC2VariablesLocation;
            BackupFile(sc2VarLocation);
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

        private static void BackupFile(string filePath)
        {
            //make backups up to 5 previous changes
            int version = 1;
            while ((File.Exists(filePath + ".version" + version.ToString())) && (version < 6))
            {
                version = version + 1;
            }
            if (version > 5)
            {
                File.Copy(filePath, filePath + ".version" + version.ToString());
                for (int i = 1; i <= 6; i++)
                {
                    var fileNameFrom = filePath + ".version" + i.ToString();
                    var fileNameTo = filePath + ".version" + (i - 1).ToString();
                    File.Move(fileNameFrom, fileNameTo);
                }
                File.Delete(filePath + ".version0");
            }
            else
            {
                File.Copy(filePath, filePath + ".version" + version.ToString());
            }
        }
    }
}
