using System;
using System.Diagnostics;
using System.Windows.Forms;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer
{
    public partial class FormSC2RelocalizerMain : Form
    {
        private string relocalizationFinishedMessage = Resources.relocalizationFinishedMessage;
        private string aboutMessage = Resources.aboutMessage;
        private string assetNotFoundMessage = Resources.assetNotFoundMessage;
        private string checkingPingMessage = Resources.checkingPingMessage;
        private string waitForDownloadMessage = Resources.waitForDownloadMessage;
        private string assetNotFoundHint = Resources.buttonAssetNotFoundHint;
        private string SC2LocationNotFoundMessage = Resources.SC2LocationNotFoundMessage;
        private string SC2VarTXTLocationNotFoundMessage = Resources.SC2VarTXTLocationNotFoundMessage;
        private string updateAvailableText = Resources.updateAvailableText;
        private string relocalizerUpToDateText = Resources.relocalizerUpToDateText;
        private string clickMe = Resources.clickMe;
        private string hideSettings = Resources.hideSettings;
        private string showSettings = Resources.showSettings;

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
                MessageBox.Show(waitForDownloadMessage);
            }
            if (chkLaunchSC2.Checked)
            {
                Process.Start(Settings.Default.SC2Location + "StarCraft II.exe");
            }
            Application.Exit();
        }

        private void FormSC2RelocalizerMain_Load(object sender, EventArgs e)
        {
            if (Settings.Default.language.Equals("Chinese"))
            {
                ChangeToChinese();
            }
            else
            {
                ChangeToEnglish();
            }
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
            labelPing.Text = checkingPingMessage;
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
                var message = assetNotFoundMessage.Replace("xxxx", Program.newAsset);
                var result = MessageBox.Show(message, "Asset Not Found", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    comboLocale.SelectedIndex = comboAsset.SelectedIndex;
                    labelInfo.Text = assetNotFoundHint.Replace("xxxx", Program.newAsset);
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
            MessageBox.Show(aboutMessage);
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
                buttonSettings.Text = hideSettings;
            }
            else
            {
                buttonSettings.Text = showSettings;
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
            MessageBox.Show(SC2LocationNotFoundMessage);
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
            MessageBox.Show(SC2VarTXTLocationNotFoundMessage);
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
                versionsToolStripMenuItem.Text = updateAvailableText + UpdateManager.GetNewVersionNumber() + clickMe;
                versionsToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                versionsToolStripMenuItem.Text = relocalizerUpToDateText;
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

        private string CreateRelocalizeMessage()
        {
            var message = relocalizationFinishedMessage;
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

        private void ChangeToChinese()
        {
            Text = "1.5.0版星际2跨服务器软件";
            versionsToolStripMenuItem.Text = "版本";
            languageChangeToolStrip.Text = "Click here to s&witch to English";
            aboutToolStripMenuItem.Text = "关于(&A)";
            aboutToolStripMenuItem2.Text = "关于(&A)";
            teamliquidPageToolStripMenuItem.Text = "Teamliquid主页(&T)";
            theProjectPageToolStripMenuItem.Text = "程序主页(&P)";
            mITLicenseToolStripMenuItem.Text = "MIT开源证书";
            exitToolStripMenuItem.Text = "退出";
            label2.Text = "选择服务器区：";
            label1.Text = "选择语音包：";
            chkLaunchSC2.Text = "跨区后自动运行星际2";
            buttonSettings.Text = "显示设置";
            buttonChangeSC2Location.Text = "更改星际2路径";
            buttonChangeSC2VariablesLocation.Text = "更改variable.txt路径";
            chkPing.Text = "检查服务器Ping";
            browserSC2Folder.Description = "请选择星际2安装路径：";
            browserSC2VarFolder.Description = "请选择星际2 Variable.txt路径(一般在我的文档\\StarCraft II目录下):";

            relocalizationFinishedMessage = Resources.relocalizationFinishedMessageChinese;
            aboutMessage = Resources.aboutMessageChinese;
            assetNotFoundMessage = Resources.assetNotFoundMessageChinese;
            checkingPingMessage = Resources.checkingPingMessageChinese;
            waitForDownloadMessage = Resources.waitForDownloadMessageChinese;
            assetNotFoundHint = Resources.buttonAssetNotFoundHintChinese;
            SC2LocationNotFoundMessage = Resources.SC2LocationNotFoundMessageChinese;
            SC2VarTXTLocationNotFoundMessage = Resources.SC2VarTXTLocationNotFoundMessageChinese;
            updateAvailableText = Resources.updateAvailableTextChinese;
            relocalizerUpToDateText = Resources.relocalizerUpToDateTextChinese;
            clickMe = Resources.clickMeChinese;
            showSettings = Resources.showSettingsChinese;
            hideSettings = Resources.hideSettingsChinese;
        }

        private void ChangeToEnglish()
        {
            Text = "Simon\'s SC2 Patch 1.5.0 Relocalizer ";
            chkPing.Text = "Check ping to region server";
            buttonChangeSC2VariablesLocation.Text = "Change Variable.txt Location";
            buttonChangeSC2Location.Text = "Change Sc2 Location";
            buttonSettings.Text = "Show Settings";
            languageChangeToolStrip.Text = "点这里汉化(&W)";
            exitToolStripMenuItem.Text = "E&xit";
            aboutToolStripMenuItem2.Text = "&About";
            mITLicenseToolStripMenuItem.Text = "MIT License";
            theProjectPageToolStripMenuItem.Text = "The Project &Page";
            teamliquidPageToolStripMenuItem.Text = "&Teamliquid page";
            aboutToolStripMenuItem.Text = "&About";
            versionsToolStripMenuItem.Text = "Versions";
            browserSC2VarFolder.Description = "Please select SC2 Variable.txt Location:";
            label2.Text = "Choose Display Language + Region:";
            chkLaunchSC2.Text = "Launch SC2 after Relocalization";
            label1.Text = "Choose Voice Asset:";
            browserSC2Folder.Description = "Please select SC2 Installation Location";

            relocalizationFinishedMessage = Resources.relocalizationFinishedMessage;
            aboutMessage = Resources.aboutMessage;
            assetNotFoundMessage = Resources.assetNotFoundMessage;
            checkingPingMessage = Resources.checkingPingMessage;
            waitForDownloadMessage = Resources.waitForDownloadMessage;
            assetNotFoundHint = Resources.buttonAssetNotFoundHint;
            SC2LocationNotFoundMessage = Resources.SC2LocationNotFoundMessage;
            SC2VarTXTLocationNotFoundMessage = Resources.SC2VarTXTLocationNotFoundMessage;
            updateAvailableText = Resources.updateAvailableText;
            relocalizerUpToDateText = Resources.relocalizerUpToDateText;
            clickMe = Resources.clickMe;
            showSettings = Resources.showSettings;
            hideSettings = Resources.hideSettings;
        }

        private void languageChangeToolStrip_Click(object sender, EventArgs e)
        {
            if (Settings.Default.language.Equals("Chinese"))
            {
                ChangeToEnglish();
                Settings.Default.language = "English";
            }
            else
            {
                ChangeToChinese();
                Settings.Default.language = "Chinese";
            }
            Settings.Default.Save();
        }
    }
}
