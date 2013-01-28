using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SimonsRelocalizer.Modules;

namespace SimonsRelocalizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!UpdateManager.CheckIfUpdatesAvailable())
            {
                Application.Run(new Form1());
            }
            else
            {
                var result = MessageBox.Show(
                    "New update available! Version "
                    + UpdateManager.GetNewVersionNumber() +
                    "\nDo you want to get it now?", "New Update Available", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Process.Start(UpdateManager.GetDownloadURL());
                }
                else
                {
                    Application.Run(new Form1());
                }
            }
        }
    }
}
