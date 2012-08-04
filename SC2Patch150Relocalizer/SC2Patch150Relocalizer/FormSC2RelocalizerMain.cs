using System;
using System.Diagnostics;
using System.Windows.Forms;
using SC2Patch150Relocalizer.Properties;


namespace SC2Patch150Relocalizer
{
    public partial class FormSC2RelocalizerMain : Form
    {
        public FormSC2RelocalizerMain()
        {
            //init
            InitializeComponent();
        }

        private void buttonRelocalize_Click(object sender, EventArgs e)
        {
            LocaleChanger.ChangeAgentDB(Program.currentLocale, Program.newLocale);
            LocaleChanger.ChangeLauncherDB(Program.currentLocale, Program.newLocale);
            LocaleChanger.ChangeProductSC2Archive(Program.newLocale);
            LocaleChanger.ChangeVarTXT(Program.currentLocale, Program.currentAsset, Program.newLocale, Program.newAsset);
            MessageBox.Show("Relocalization from "+ Program.currentLocale + " to " + Program.newLocale + " with asset from " + Program.currentAsset + " to " + Program.currentAsset + " is finished! Enjoy!");
            if (chkLaunchSC2.Checked)
            {
                Process.Start(Settings.Default.SC2Location + "StarCraft II.exe");
            }
            Application.Exit();
        }

        private void FormSC2RelocalizerMain_Load(object sender, EventArgs e)
        {
            SettingsManager.checkSC2Location();
            SettingsManager.checkVarTXTLocation();
            SettingsManager.checkCurrentLocale();
            ChangeComboListValues();
            ChangeCheckBoxValue();
        }

        private void chkLaunchSC2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.RunSC2AfterRelocalize = chkLaunchSC2.Checked;
            Settings.Default.Save();
        }

        private void comboLocale_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.newLocale = Program.languageList[comboLocale.SelectedIndex].Substring(0, 4);
        }

        private void comboAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.newAsset = Program.languageList[comboAsset.SelectedIndex].Substring(0, 4);
        }

        public string BrowseSc2Location()
        {
            var result = browserSC2Folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                return browserSC2Folder.SelectedPath + "\\";
            }
            MessageBox.Show("We need to know the SC2 Installation Location!");
            Application.Exit();
            return null;
        }

        public string BrowseSc2VarTxtLocation()
        {
            var result = browserSC2VarFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                return browserSC2VarFolder.SelectedPath + "\\";
            }
            MessageBox.Show("We need to know the SC2 Variable.txt Location!");
            Application.Exit();
            return null;
        }

        public void ChangeComboListValues()
        {
            for (int i = 0; i < Program.languageList.Length; i++)
            {
                string locale = Program.languageList[i];
                if (locale.StartsWith(Program.currentLocale))
                {
                    comboLocale.SelectedIndex = i;
                }
                if (locale.StartsWith(Program.currentAsset))
                {
                    comboAsset.SelectedIndex = i;
                }
            }
        }

        private void ChangeCheckBoxValue()
        {
            chkLaunchSC2.Checked = Settings.Default.RunSC2AfterRelocalize;
        }
    }
}
