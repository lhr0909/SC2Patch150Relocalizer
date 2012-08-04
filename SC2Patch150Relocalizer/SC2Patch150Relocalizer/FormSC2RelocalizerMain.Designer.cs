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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamliquidPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theProjectPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.versionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRelocalize
            // 
            this.buttonRelocalize.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelocalize.Image = global::SimonsRelocalizer.Properties.Resources.icon_by_existor;
            this.buttonRelocalize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRelocalize.Location = new System.Drawing.Point(6, 109);
            this.buttonRelocalize.Name = "buttonRelocalize";
            this.buttonRelocalize.Size = new System.Drawing.Size(556, 134);
            this.buttonRelocalize.TabIndex = 15;
            this.buttonRelocalize.Text = "Relocalize!";
            this.buttonRelocalize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRelocalize.UseVisualStyleBackColor = true;
            this.buttonRelocalize.Click += new System.EventHandler(this.buttonRelocalize_Click);
            // 
            // browserSC2Folder
            // 
            this.browserSC2Folder.Description = "Please select SC2 Installation Location";
            this.browserSC2Folder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Choose Voice Asset:";
            // 
            // chkLaunchSC2
            // 
            this.chkLaunchSC2.AutoSize = true;
            this.chkLaunchSC2.Location = new System.Drawing.Point(9, 80);
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
            this.label2.Location = new System.Drawing.Point(6, 35);
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
            "enUS - AM - English (US)",
            "esMX - AM - Español (Latin America)",
            "ptBR - AM - Português (Brazil)",
            "zhCN - CN - 简体中文 (PR China, simplified)",
            "enGB - EU - English (UK)",
            "frFR - EU - Français",
            "deDE - EU - Deutsch",
            "itIT - EU - Italiano ",
            "plPL - EU - Polski",
            "ruRU - EU - Русский",
            "esES - EU - Español (Spain)",
            "koKR - KR/TW - Korean",
            "zhTW - KR/TW - 繁體中文 (Taiwan, tranditional)",
            "enSG - SEA - English (Singapore)"});
            this.comboAsset.Location = new System.Drawing.Point(302, 52);
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
            "enUS - AM - English (US)",
            "esMX - AM - Español (Latin America)",
            "ptBR - AM - Português (Brazil)",
            "zhCN - CN - 简体中文 (PR China, simplified)",
            "enGB - EU - English (UK)",
            "frFR - EU - Français",
            "deDE - EU - Deutsch",
            "itIT - EU - Italiano ",
            "plPL - EU - Polski",
            "ruRU - EU - Русский",
            "esES - EU - Español (Spain)",
            "koKR - KR/TW - Korean",
            "zhTW - KR/TW - 繁體中文 (Taiwan, tranditional)",
            "enSG - SEA - English (Singapore)"});
            this.comboLocale.Location = new System.Drawing.Point(9, 51);
            this.comboLocale.Name = "comboLocale";
            this.comboLocale.Size = new System.Drawing.Size(263, 21);
            this.comboLocale.TabIndex = 22;
            this.comboLocale.SelectedIndexChanged += new System.EventHandler(this.comboLocale_SelectedIndexChanged);
            // 
            // browserSC2VarFolder
            // 
            this.browserSC2VarFolder.Description = "Please select SC2 Variable.txt Location:";
            this.browserSC2VarFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.versionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(574, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
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
            // versionsToolStripMenuItem
            // 
            this.versionsToolStripMenuItem.Name = "versionsToolStripMenuItem";
            this.versionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.versionsToolStripMenuItem.Text = "Versions";
            this.versionsToolStripMenuItem.Click += new System.EventHandler(this.versionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormSC2RelocalizerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 255);
            this.Controls.Add(this.comboLocale);
            this.Controls.Add(this.comboAsset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkLaunchSC2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRelocalize);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(582, 282);
            this.MinimumSize = new System.Drawing.Size(582, 282);
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
    }
}

