using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace SC2Patch150Relocalizer
{
    public partial class FormSC2RelocalizerMain : Form
    {
        private String originalLanguage = "enUS";
        private String relocalizeLanguage = "enUS";
        private String SC2Location = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\StarCraft II\\";
        private String SC2VariablesLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\StarCraft II\\Variables.txt";
        private String AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        private String LocaleLocation = "\\Locales\\";

        public FormSC2RelocalizerMain()
        {
            //fix app path
            AppPath = AppPath.Substring(6, AppPath.Length - 6);
            //init
            InitializeComponent();
            //read current locale
            var varTXTLines = File.ReadAllLines(SC2VariablesLocation);
            foreach (string line in varTXTLines)
            {
                if (line.StartsWith("localeidassets="))
                {
                    originalLanguage = line.Substring(line.Length - 4, 4);
                    ((RadioButton)(Controls.Find(originalLanguage + "Radio", true)[0])).Checked = true;
                }
            }
        }

        private void buttonRelocalize_Click(object sender, EventArgs e)
        {
            //backup
            if (File.Exists(SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive." + originalLanguage))
            {
                File.Delete(SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive");
                File.Delete(SC2Location + ".agent.db");
                File.Delete(SC2Location + "Launcher.db");
            }
            else
            {
                File.Move(SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive", SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive." + originalLanguage);
                File.Move(SC2Location + ".agent.db", SC2Location + ".agent.db." + originalLanguage);
                File.Move(SC2Location + "Launcher.db", SC2Location + "Launcher.db." + originalLanguage);
            }
            //copy in
            File.Copy(AppPath + LocaleLocation + relocalizeLanguage + "\\Product.SC2Archive", SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive");
            File.Copy(AppPath + LocaleLocation + relocalizeLanguage + "\\.agent.db", SC2Location + ".agent.db");
            File.Copy(AppPath + LocaleLocation + relocalizeLanguage + "\\Launcher.db", SC2Location + "Launcher.db");
            //delete some files
            if (File.Exists(SC2Location + "Mods\\Core.SC2Mod\\Product.SC2Archive." + originalLanguage))
            {
                File.Delete(SC2Location + "Starcraft II Cache.mfil");
                File.Delete(SC2Location + "Starcraft II.mfil");
                File.Delete(SC2Location + "Starcraft II.tfil");
            }
            else
            {
                File.Move(SC2Location + "Starcraft II Cache.mfil", SC2Location + "Starcraft II Cache.mfil." + originalLanguage);
                File.Move(SC2Location + "Starcraft II.mfil", SC2Location + "Starcraft II.mfil." + originalLanguage);
                File.Move(SC2Location + "Starcraft II.tfil", SC2Location + "Starcraft II.tfil." + originalLanguage);
            }
            //change variable.txt
            if (!File.Exists(SC2VariablesLocation + "." + originalLanguage))
            {
                File.Copy(SC2VariablesLocation, SC2VariablesLocation + "." + originalLanguage);
            }
            var varTXTLines = File.ReadAllLines(SC2VariablesLocation);
            File.Delete(SC2VariablesLocation);
            var newVarTXT = "";
            foreach (string line in varTXTLines)
            {
                if (line.Equals("localeidassets=" + originalLanguage))
                {
                    newVarTXT += ("localeidassets=" + relocalizeLanguage + "\r\n");
                }
                else if (line.Equals("localeiddata=" + originalLanguage))
                {
                    newVarTXT += ("localeiddata=" + relocalizeLanguage + "\r\n");
                }
                else
                {
                    newVarTXT += line + "\r\n";
                }
            }
            File.WriteAllText(SC2VariablesLocation, newVarTXT);
            MessageBox.Show("Relocalization from " + originalLanguage + " to " + relocalizeLanguage + "is finished! Enjoy!");
        }

        private void deDERadio_CheckedChanged(object sender, EventArgs e)
        {
            if (deDERadio.Checked)
            {
                relocalizeLanguage = "deDE";
            }
        }

        private void enGBRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (enGBRadio.Checked)
            {
                relocalizeLanguage = "enGB";
            }
        }

        private void enSGRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (enSGRadio.Checked)
            {
                relocalizeLanguage = "enSG";
            }
        }

        private void enUSRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (enUSRadio.Checked)
            {
                relocalizeLanguage = "enUS";
            }
        }

        private void esESRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (esESRadio.Checked)
            {
                relocalizeLanguage = "esES";
            }
        }

        private void esMXRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (esMXRadio.Checked)
            {
                relocalizeLanguage = "esMX";
            }
        }

        private void frFRRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (frFRRadio.Checked)
            {
                relocalizeLanguage = "frFR";
            }
        }

        private void itITRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (itITRadio.Checked)
            {
                relocalizeLanguage = "itIT";
            }
        }

        private void koKRRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (koKRRadio.Checked)
            {
                relocalizeLanguage = "koKR";
            }
        }

        private void plPLRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void plBRRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (plBRRadio.Checked)
            {
                relocalizeLanguage = "plBR";
            }
        }

        private void ruRURadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ruRURadio.Checked)
            {
                relocalizeLanguage = "ruRU";
            }
        }

        private void zhCNRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (zhCNRadio.Checked)
            {
                relocalizeLanguage = "zhCN";
            }
        }

        private void zhTWRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (zhTWRadio.Checked)
            {
                relocalizeLanguage = "zhTW";
            }
        }

        private void FormSC2RelocalizerMain_Load(object sender, EventArgs e)
        {
            //check sc2 folder
            if (Directory.Exists(SC2Location)) return;
            var result = browserSC2Folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                SC2Location = browserSC2Folder.SelectedPath + "\\";
            }
            else
            {
                MessageBox.Show("We need to know the SC2 Installation Location!");
                Application.Exit();
            }
        }
    }
}
