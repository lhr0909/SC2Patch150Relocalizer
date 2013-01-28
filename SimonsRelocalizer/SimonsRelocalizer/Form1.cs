using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SimonsRelocalizer.Modules;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChangeComboBoxesValues()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (((string) comboBox1.Items[i]).StartsWith(SettingsManager.currentLocale))
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (((string) comboBox2.Items[i]).StartsWith(SettingsManager.currentAsset))
                {
                    comboBox2.SelectedIndex = i;
                    break;
                }
            }
        }

        private void ChangeRadioButtonsValues()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            if (SettingsManager.currentRegion != null)
            {
                if (SettingsManager.currentRegion.Equals("us"))
                {
                    radioButton1.Checked = true;
                }
                else if (SettingsManager.currentRegion.Equals("eu"))
                {
                    radioButton2.Checked = true;
                }
                else if (SettingsManager.currentRegion.Equals("kr"))
                {
                    radioButton3.Checked = true;
                }
                else if (SettingsManager.currentRegion.Equals("sg"))
                {
                    radioButton4.Checked = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = "Version: " + UpdateManager.currentVersionNumber;
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "http://www.teamliquid.net/forum/viewmessage.php?topic_id=357860");
            linkLabel2.Links.Add(0, linkLabel2.Text.Length, "https://github.com/lhr0909/SC2Patch150Relocalizer/blob/master/README.md");
            linkLabel3.Links.Add(0, linkLabel3.Text.Length, "https://github.com/lhr0909/SC2Patch150Relocalizer");

            if (SettingsManager.IsInSC2Folder())
            {
                SettingsManager.CheckCurrentLocaleAsset();
                SettingsManager.CheckCurrentRegion();

                ChangeRadioButtonsValues();
                ChangeComboBoxesValues();
            }
            else
            {
                MessageBox.Show(Resources.Form1_Form1_Load_WrongFolderMessage, "Wrong Folder", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocaleChanger.newLocale = Regex.Split((string)comboBox1.SelectedItem, " - ")[0];
            LocaleChanger.newAsset = Regex.Split((string)comboBox2.SelectedItem, " - ")[0];

            if (radioButton1.Checked)
            {
                LocaleChanger.newRegion = "us";
            }
            else if (radioButton2.Checked)
            {
                LocaleChanger.newRegion = "eu";
            }
            else if (radioButton3.Checked)
            {
                LocaleChanger.newRegion = "kr";
            }
            else if (radioButton4.Checked)
            {
                LocaleChanger.newRegion = "sg";
            }
            else
            {
                LocaleChanger.newRegion = LocaleChanger.newLocale;
            }
           
            var result = LocaleChanger.Relocalize();
            if (result == 0)
            {
                ShowSuccessMessage();
            }
            else if (result == 1)
            {
                var dialog_result = MessageBox.Show("You don't have asset " + LocaleChanger.newAsset +
                                " downloaded. You have to relocalize your client to " + LocaleChanger.newAsset +
                                " to let SC2 finish the asset download. Do you want to proceed?", "Missing Asset Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog_result == DialogResult.Yes)
                {
                    LocaleChanger.newLocale = LocaleChanger.newAsset;
                    LocaleChanger.newRegion = LocaleChanger.newAsset;
                    result = LocaleChanger.Relocalize();
                    if (result == 0)
                    {
                        MessageBox.Show("Success!\n"
                            +
                            "Please start SC2 and let it finish download before using the relocalizer again!"
                            + "\nProgram will now close.", "Success!");
                        Application.Exit();
                    }
                }
            }
        }

        private static void ShowSuccessMessage()
        {
            var result = MessageBox.Show("Success!\n"
                + "Do you want to close the relocalizer and run the game now?",
                "Success!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Process.Start(SettingsManager.SC2Name + ".exe");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LocaleChanger.newLocale = textBox1.Text;
            LocaleChanger.newAsset = textBox2.Text;
            LocaleChanger.newRegion = LocaleChanger.newLocale;
            var result = LocaleChanger.Relocalize();
            if (result == 0)
            {
                ShowSuccessMessage();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

    }
}
