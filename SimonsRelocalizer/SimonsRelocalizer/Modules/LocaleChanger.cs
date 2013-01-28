using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer.Modules
{
    class LocaleChanger
    {
        public static string newRegion;
        public static string newLocale;
        public static string newAsset;

        public static int Relocalize()
        {
            if (CheckIfAssetExists(newAsset))
            {
                ChangeAgentDB();
                ChangeLauncherDB();
                ChangeVarsTxt();
                ChangeProductArchive();
                AddRegionsXML();
                ChangeRegion();
                return 0;
            }
            return 1;
        }

        private static bool CheckIfAssetExists(string asset)
        {
            if (newAsset == newLocale) return true;
            var filePath = "Mods\\Core.SC2Mod\\" + asset + ".SC2Data";
            return File.Exists(filePath);
        }

        private static void ChangeRegion()
        {
            RegistryKey lastPortal = Registry.CurrentUser.OpenSubKey("Software\\Blizzard Entertainment\\Battle.net\\S2", true);
            lastPortal.SetValue("LastPortal-" + newLocale, newRegion, RegistryValueKind.String);
        }

        private static void ChangeProductArchive()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var filePath = "Mods\\Core.SC2Mod\\Product.SC2Archive";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                var dest = File.Open(filePath, FileMode.OpenOrCreate);
                var names = assembly.GetManifestResourceNames();
                foreach (string name in names)
                {
                    if (name.EndsWith(newLocale))
                    {
                        var relocalizeFile = assembly.GetManifestResourceStream(name);
                        if (relocalizeFile != null) relocalizeFile.CopyTo(dest);
                        dest.Close();
                        relocalizeFile.Close();
                    }
                }
            }
        }

        private static void AddRegionsXML()
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (!File.Exists("regions.xml"))
            {
                try
                {
                    var dest = File.Open("regions.xml", FileMode.OpenOrCreate);
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
                catch (Exception)
                {
                    var result = MessageBox.Show(
                        Resources.LocaleChanger_AddRegionsXML_Warning, 
                        "No Permission", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Error);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start("http://dl.dropbox.com/u/23413195/regions.xml");
                        MessageBox.Show(Resources.LocaleChanger_AddRegionsXML_Message, "Instructions");
                    }
                    Application.Exit();
                }
            }
        }

        private static void ChangeVarsTxt()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path += "\\" + SettingsManager.SC2Name + "\\Variables.txt";
            if (File.Exists(path))
            {
                var text = File.ReadAllText(path);
                var evaluator2 = new MatchEvaluator(replaceAgent2);
                var evaluator3 = new MatchEvaluator(replaceAgent3);
                text = Regex.Replace(
                    text,
                    "(localeiddata=)([A-Za-z]{4})",
                    evaluator2
                    );
                text = Regex.Replace(
                    text,
                    "(localeidassets=)([A-Za-z]{4})",
                    evaluator3
                    );
                File.Delete(path);
                File.WriteAllText(path, text);
            }
        }

        private static void ChangeLauncherDB()
        {
            if (File.Exists("Launcher.db"))
            {
                File.Delete("Launcher.db");
                File.WriteAllText("Launcher.db", newLocale);
            }
        }

        private static void ChangeAgentDB()
        {
            if (File.Exists(".agent.db"))
            {
                var text = File.ReadAllText(".agent.db");
                var evaluator1 = new MatchEvaluator(replaceAgent1);
                text = Regex.Replace(
                    text,
                    "(\"s2_)([A-Za-z]{4})(\")",
                    evaluator1
                    );
                text = Regex.Replace(
                    text,
                    "(http://)([A-Za-z]{4})(.patch.battle.net:1119/patch)",
                    evaluator1
                    );
                text = Regex.Replace(
                    text,
                    "(\"installed_locales\" : " + @"\[\s+" + "\")([A-Za-z]{4})(\")",
                    evaluator1
                    );
                text = Regex.Replace(
                    text,
                    "(\"display_locales\" : " + @"\[\s+" + "\")([A-Za-z]{4})(\")",
                    evaluator1
                    );
                File.Delete(".agent.db");
                File.WriteAllText(".agent.db", text);
            }
        }

        private static string replaceAgent3(Match m)
        {
            return m.Groups[1].Value + newAsset;
        }

        private static string replaceAgent2(Match m)
        {
            return m.Groups[1].Value + newLocale;
        }

        private static string replaceAgent1(Match m)
        {
            return m.Groups[1].Value + newLocale + m.Groups[3].Value;
        }
    }
}
