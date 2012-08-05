namespace SimonsRelocalizer
{
    partial class FormSC2RelocalizerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSC2RelocalizerMain));
            this.buttonRelocalize = new System.Windows.Forms.Button();
            this.browserSC2Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLaunchSC2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboAsset = new System.Windows.Forms.ComboBox();
            this.comboLocale = new System.Windows.Forms.ComboBox();
            this.browserSC2VarFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.versionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamliquidPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theProjectPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.timerScrollWindow = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonChangeSC2Location = new System.Windows.Forms.Button();
            this.buttonChangeSC2VariablesLocation = new System.Windows.Forms.Button();
            this.textSC2Location = new System.Windows.Forms.TextBox();
            this.textSC2VariablesLocation = new System.Windows.Forms.TextBox();
            this.labelPing = new System.Windows.Forms.Label();
            this.timerCheckPing = new System.Windows.Forms.Timer(this.components);
            this.chkPing = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRelocalize
            // 
            this.buttonRelocalize.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelocalize.Image = global::SimonsRelocalizer.Properties.Resources.relocalize_button;
            this.buttonRelocalize.Location = new System.Drawing.Point(325, 27);
            this.buttonRelocalize.Name = "buttonRelocalize";
            this.buttonRelocalize.Size = new System.Drawing.Size(190, 161);
            this.buttonRelocalize.TabIndex = 15;
            this.buttonRelocalize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRelocalize.UseVisualStyleBackColor = true;
            this.buttonRelocalize.Click += new System.EventHandler(this.buttonRelocalize_Click);
            // 
            // browserSC2Folder
            // 
            this.browserSC2Folder.Description = "Please select SC2 Installation Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Choose Voice Asset:";
            // 
            // chkLaunchSC2
            // 
            this.chkLaunchSC2.AutoSize = true;
            this.chkLaunchSC2.Location = new System.Drawing.Point(53, 125);
            this.chkLaunchSC2.Name = "chkLaunchSC2";
            this.chkLaunchSC2.Size = new System.Drawing.Size(178, 17);
            this.chkLaunchSC2.TabIndex = 18;
            this.chkLaunchSC2.Text = "Launch SC2 after Relocalization";
            this.chkLaunchSC2.UseVisualStyleBackColor = true;
            this.chkLaunchSC2.CheckedChanged += new System.EventHandler(this.chkLaunchSC2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Choose Display Language + Region:";
            // 
            // comboAsset
            // 
            this.comboAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAsset.FormattingEnabled = true;
            this.comboAsset.Items.AddRange(new object[] {
            "AM - English (US) - enUS",
            "AM - Español (Latin America) - esMX",
            "AM - Português (Brazil) - ptBR",
            "CN - 简体中文 (PR China, simplified) - zhCN",
            "EU - English (UK) - enGB",
            "EU - Français - frFR",
            "EU - Deutsch - deDE",
            "EU - Italiano - itIT",
            "EU - Polski - plPL",
            "EU - Русский - ruRU",
            "EU - Español (Spain) - esES",
            "KR/TW - Korean - koKR",
            "KR/TW - 繁體中文 (Taiwan, tranditional) - zhTW",
            "SEA - English (Singapore) - enSG"});
            this.comboAsset.Location = new System.Drawing.Point(53, 98);
            this.comboAsset.Name = "comboAsset";
            this.comboAsset.Size = new System.Drawing.Size(263, 21);
            this.comboAsset.TabIndex = 21;
            this.comboAsset.SelectedIndexChanged += new System.EventHandler(this.comboAsset_SelectedIndexChanged);
            // 
            // comboLocale
            // 
            this.comboLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocale.FormattingEnabled = true;
            this.comboLocale.Items.AddRange(new object[] {
            "AM - English (US) - enUS",
            "AM - Español (Latin America) - esMX",
            "AM - Português (Brazil) - ptBR",
            "CN - 简体中文 (PR China, simplified) - zhCN",
            "EU - English (UK) - enGB",
            "EU - Français - frFR",
            "EU - Deutsch - deDE",
            "EU - Italiano - itIT",
            "EU - Polski - plPL",
            "EU - Русский - ruRU",
            "EU - Español (Spain) - esES",
            "KR/TW - Korean - koKR",
            "KR/TW - 繁體中文 (Taiwan, tranditional) - zhTW",
            "SEA - English (Singapore) - enSG"});
            this.comboLocale.Location = new System.Drawing.Point(53, 53);
            this.comboLocale.Name = "comboLocale";
            this.comboLocale.Size = new System.Drawing.Size(263, 21);
            this.comboLocale.TabIndex = 22;
            this.comboLocale.SelectedIndexChanged += new System.EventHandler(this.comboLocale_SelectedIndexChanged);
            // 
            // browserSC2VarFolder
            // 
            this.browserSC2VarFolder.Description = "Please select SC2 Variable.txt Location:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(524, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // versionsToolStripMenuItem
            // 
            this.versionsToolStripMenuItem.Name = "versionsToolStripMenuItem";
            this.versionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.versionsToolStripMenuItem.Text = "Versions";
            this.versionsToolStripMenuItem.Click += new System.EventHandler(this.versionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamliquidPageToolStripMenuItem,
            this.theProjectPageToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.aboutToolStripMenuItem2});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // teamliquidPageToolStripMenuItem
            // 
            this.teamliquidPageToolStripMenuItem.Name = "teamliquidPageToolStripMenuItem";
            this.teamliquidPageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.teamliquidPageToolStripMenuItem.Text = "&Teamliquid page";
            this.teamliquidPageToolStripMenuItem.Click += new System.EventHandler(this.teamliquidPageToolStripMenuItem_Click);
            // 
            // theProjectPageToolStripMenuItem
            // 
            this.theProjectPageToolStripMenuItem.Name = "theProjectPageToolStripMenuItem";
            this.theProjectPageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.theProjectPageToolStripMenuItem.Text = "The Project &Page";
            this.theProjectPageToolStripMenuItem.Click += new System.EventHandler(this.theProjectPageToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.aboutToolStripMenuItem2.Text = "&About";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.Image = global::SimonsRelocalizer.Properties.Resources.relocalization;
            this.label3.Location = new System.Drawing.Point(14, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 28);
            this.label3.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Image = global::SimonsRelocalizer.Properties.Resources.voice_asset;
            this.label4.Location = new System.Drawing.Point(14, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 28);
            this.label4.TabIndex = 26;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(57, 148);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 13);
            this.labelInfo.TabIndex = 27;
            // 
            // timerScrollWindow
            // 
            this.timerScrollWindow.Interval = 10;
            this.timerScrollWindow.Tick += new System.EventHandler(this.timerScrollWindow_Tick);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(53, 165);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(263, 23);
            this.buttonSettings.TabIndex = 28;
            this.buttonSettings.Text = "Show Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonChangeSC2Location
            // 
            this.buttonChangeSC2Location.Location = new System.Drawing.Point(17, 215);
            this.buttonChangeSC2Location.Name = "buttonChangeSC2Location";
            this.buttonChangeSC2Location.Size = new System.Drawing.Size(171, 23);
            this.buttonChangeSC2Location.TabIndex = 31;
            this.buttonChangeSC2Location.Text = "Change Sc2 Location";
            this.buttonChangeSC2Location.UseVisualStyleBackColor = true;
            this.buttonChangeSC2Location.Click += new System.EventHandler(this.buttonChangeSC2Location_Click);
            // 
            // buttonChangeSC2VariablesLocation
            // 
            this.buttonChangeSC2VariablesLocation.Location = new System.Drawing.Point(17, 248);
            this.buttonChangeSC2VariablesLocation.Name = "buttonChangeSC2VariablesLocation";
            this.buttonChangeSC2VariablesLocation.Size = new System.Drawing.Size(171, 23);
            this.buttonChangeSC2VariablesLocation.TabIndex = 32;
            this.buttonChangeSC2VariablesLocation.Text = "Change Variable.txt Location";
            this.buttonChangeSC2VariablesLocation.UseVisualStyleBackColor = true;
            this.buttonChangeSC2VariablesLocation.Click += new System.EventHandler(this.buttonChangeSC2VariablesLocation_Click);
            // 
            // textSC2Location
            // 
            this.textSC2Location.Enabled = false;
            this.textSC2Location.Location = new System.Drawing.Point(194, 215);
            this.textSC2Location.Name = "textSC2Location";
            this.textSC2Location.Size = new System.Drawing.Size(321, 20);
            this.textSC2Location.TabIndex = 33;
            // 
            // textSC2VariablesLocation
            // 
            this.textSC2VariablesLocation.Enabled = false;
            this.textSC2VariablesLocation.Location = new System.Drawing.Point(194, 251);
            this.textSC2VariablesLocation.Name = "textSC2VariablesLocation";
            this.textSC2VariablesLocation.Size = new System.Drawing.Size(321, 20);
            this.textSC2VariablesLocation.TabIndex = 34;
            // 
            // labelPing
            // 
            this.labelPing.AutoSize = true;
            this.labelPing.Location = new System.Drawing.Point(231, 127);
            this.labelPing.Name = "labelPing";
            this.labelPing.Size = new System.Drawing.Size(54, 13);
            this.labelPing.TabIndex = 35;
            this.labelPing.Text = "Ping: N/A";
            // 
            // timerCheckPing
            // 
            this.timerCheckPing.Tick += new System.EventHandler(this.timerCheckPing_Tick);
            // 
            // chkPing
            // 
            this.chkPing.AutoSize = true;
            this.chkPing.Location = new System.Drawing.Point(53, 277);
            this.chkPing.Name = "chkPing";
            this.chkPing.Size = new System.Drawing.Size(156, 17);
            this.chkPing.TabIndex = 36;
            this.chkPing.Text = "Check ping to region server";
            this.chkPing.UseVisualStyleBackColor = true;
            this.chkPing.CheckedChanged += new System.EventHandler(this.chkPing_CheckedChanged);
            // 
            // FormSC2RelocalizerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 300);
            this.Controls.Add(this.chkPing);
            this.Controls.Add(this.labelPing);
            this.Controls.Add(this.textSC2VariablesLocation);
            this.Controls.Add(this.textSC2Location);
            this.Controls.Add(this.buttonChangeSC2VariablesLocation);
            this.Controls.Add(this.buttonChangeSC2Location);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboLocale);
            this.Controls.Add(this.comboAsset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkLaunchSC2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRelocalize);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormSC2RelocalizerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simon\'s SC2 Patch 1.5.0 Relocalizer ";
            this.Load += new System.EventHandler(this.FormSC2RelocalizerMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRelocalize;
        private System.Windows.Forms.FolderBrowserDialog browserSC2Folder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLaunchSC2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAsset;
        private System.Windows.Forms.ComboBox comboLocale;
        private System.Windows.Forms.FolderBrowserDialog browserSC2VarFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theProjectPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamliquidPageToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Timer timerScrollWindow;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonChangeSC2Location;
        private System.Windows.Forms.Button buttonChangeSC2VariablesLocation;
        private System.Windows.Forms.TextBox textSC2Location;
        private System.Windows.Forms.TextBox textSC2VariablesLocation;
        private System.Windows.Forms.Label labelPing;
        private System.Windows.Forms.Timer timerCheckPing;
        private System.Windows.Forms.CheckBox chkPing;
    }
}

