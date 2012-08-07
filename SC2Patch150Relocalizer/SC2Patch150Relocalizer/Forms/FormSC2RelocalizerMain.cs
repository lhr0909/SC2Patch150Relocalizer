using System;
using System.Diagnostics;
using System.Windows.Forms;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer
{
    public partial class FormSC2RelocalizerMain : Form
    {
        public FormSC2RelocalizerMain()
        {
            InitializeComponent();
        }

        private void buttonRelocalize_Click(object sender, EventArgs e)
        {
            LocaleChanger.RunRelocalize();
            if (buttonRelocalize.Text.Equals(""))
            {
                var message = CreateRelocalizeMessage();
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show(Resources.waitForDownloadMessage);
            }
            if (chkLaunchSC2.Checked)
            {
                Process.Start(Settings.Default.SC2Location + "StarCraft II.exe");
            }
            Application.Exit();
        }

        private void FormSC2RelocalizerMain_Load(object sender, EventArgs e)
        {
            Text = Text + Settings.Default.VersionNumber;
            Size = new System.Drawing.Size(Size.Width, 225);
            SettingsManager.CheckSc2Location();
            SettingsManager.CheckVarTxtLocation();
            SettingsManager.checkCurrentLocale();
            ChangeSettingTextBoxesValues();
            ChangeComboListValues();
            ChangeCheckBoxesValues();
            CheckUpdate();
        }

        private void chkLaunchSC2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.RunSC2AfterRelocalize = chkLaunchSC2.Checked;
            Settings.Default.Save();
        }


        private void chkPing_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.CheckPing = chkPing.Checked;
            Settings.Default.Save();
        }

        private void comboLocale_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPing.Text = Resources.checkingPingMessage;
            Program.newLocale = LocaleChanger.GetLocaleFromLanguageListItem(Program.languageList[comboLocale.SelectedIndex]);
            Program.pingRegion = LocaleChanger.GetRegionFromLanguageListItem(Program.languageList[comboLocale.SelectedIndex]);
            comboAsset.SelectedIndex = comboLocale.SelectedIndex;
            timerCheckPing.Enabled = true;
        }

        private void comboAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.newAsset = LocaleChanger.GetLocaleFromLanguageListItem(Program.languageList[comboAsset.SelectedIndex]);
            if (!LocaleChanger.CheckIfAssetExists(Program.newAsset))
            {
                var message = Resources.assetNotFoundMessage.Replace("xxxx", Program.newAsset);
                var result = MessageBox.Show(message, "Asset Not Found", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    comboLocale.SelectedIndex = comboAsset.SelectedIndex;
                    labelInfo.Text = Resources.buttonAssetNotFoundHint.Replace("xxxx", Program.newAsset);
                    chkLaunchSC2.Checked = true;
                    chkLaunchSC2.Enabled = false;
                    comboLocale.Enabled = false;
                    comboAsset.Enabled = false;
                    return;
                }
                for (int i = 0; i < Program.languageList.Length; i++)
                {
                    if (LocaleChanger.GetLocaleFromLanguageListItem(Program.languageList[i]) == Program.currentAsset)
                    {
                        comboAsset.SelectedIndex = i;
                    }
                    if (LocaleChanger.GetLocaleFromLanguageListItem(Program.languageList[i]) == Program.currentLocale)
                    {
                        comboLocale.SelectedIndex = i;
                    }
                }
            }
            comboLocale.Enabled = true;
            comboAsset.Enabled = true;
            chkLaunchSC2.Enabled = true;
        }

        private void versionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (versionsToolStripMenuItem.ForeColor == System.Drawing.Color.Blue)
            {
                Process.Start("https://github.com/downloads/lhr0909/SC2Patch150Relocalizer/SimonsRelocalizer." + UpdateManager.GetNewVersionNumber() + ".zip");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.aboutMessage);
        }

        private void theProjectPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/lhr0909/SC2Patch150Relocalizer");
        }

        private void teamliquidPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.teamliquid.net/forum/viewmessage.php?topic_id=357860");
        }

        private void timerScrollWindow_Tick(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(Size.Width, Size.Height + Program.scrollOffset);
            if ((Size.Height >= 325) || (Size.Height <= 225))
            {
                timerScrollWindow.Enabled = false;
                Program.scrollOffset = -Program.scrollOffset;
                buttonSettings.Enabled = true;
            }
        }

        private void timerCheckPing_Tick(object sender, EventArgs e)
        {
            CheckAndChangePing(PingChecker.GetBattleNetHostname(Program.pingRegion));
            timerCheckPing.Enabled = false;
        }

        private void buttonChangeSC2Location_Click(object sender, EventArgs e)
        {
            Settings.Default.SC2Location = BrowseSc2Location();
            SettingsManager.CheckSc2Location();
            ChangeSettingTextBoxesValues();
        }

        private void buttonChangeSC2VariablesLocation_Click(object sender, EventArgs e)
        {
            Settings.Default.SC2VariablesLocation = BrowseSc2VarTxtLocation() + "\\Variables.txt";
            SettingsManager.CheckVarTxtLocation();
            ChangeSettingTextBoxesValues();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            timerScrollWindow.Enabled = true;
            if (Program.scrollOffset > 0)
            {
                buttonSettings.Text = "Hide Settings";
            }
            else
            {
                buttonSettings.Text = "Show Settings";
            }
            buttonSettings.Enabled = false;
        }

        public string BrowseSc2Location()
        {
            var result = browserSC2Folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                return browserSC2Folder.SelectedPath + "\\";
            }
            MessageBox.Show(Resources.SC2LocationNotFoundMessage);
            if (!Visible) Application.Exit();
            return null;
        }

        public string BrowseSc2VarTxtLocation()
        {
            var result = browserSC2VarFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                return browserSC2VarFolder.SelectedPath + "\\";
            }
            MessageBox.Show(Resources.SC2VarTXTLocationNotFoundMessage);
            if (!Visible) Application.Exit();
            return null;
        }

        private void ChangeSettingTextBoxesValues()
        {
            textSC2Location.Text = Settings.Default.SC2Location;
            textSC2VariablesLocation.Text = Settings.Default.SC2VariablesLocation;
        }

        private void CheckUpdate()
        {
            var updatesAvaiable = UpdateManager.CheckIfUpdatesAvailable();
            if (updatesAvaiable)
            {
                versionsToolStripMenuItem.Text = Resources.updateAvaiableText + UpdateManager.GetNewVersionNumber() + " Click me!";
                versionsToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                versionsToolStripMenuItem.Text = Resources.relocalizerUpToDateText;
                versionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void ChangeComboListValues()
        {
            for (int i = 0; i < Program.languageList.Length; i++)
            {
                string locale = Program.languageList[i];
                if (locale.EndsWith(Program.currentLocale))
                {
                    comboLocale.SelectedIndex = i;
                }
                if (locale.EndsWith(Program.currentAsset))
                {
                    comboAsset.SelectedIndex = i;
                }
            }
        }

        private static string CreateRelocalizeMessage()
        {
            var message = Resources.relocalizationFinishedMessage;
            message = message.Replace("aaaa", Program.currentLocale);
            message = message.Replace("bbbb", Program.newLocale);
            message = message.Replace("cccc", Program.currentAsset);
            message = message.Replace("dddd", Program.newAsset);
            return message;
        }

        private void ChangeCheckBoxesValues()
        {
            chkLaunchSC2.Checked = Settings.Default.RunSC2AfterRelocalize;
            chkPing.Checked = Settings.Default.CheckPing;
        }

        private void CheckAndChangePing(string hostname)
        {
            if (!Settings.Default.CheckPing)
            {
                labelPing.Text = "Ping: N/A";
                return;
            }
            PingChecker.CheckPing(hostname);
            labelPing.Text = "Ping: " + PingChecker.GetPingTimeout();
        }

        private void mITLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.MITLicenseMessage, "MIT License");
        }
    }
}
