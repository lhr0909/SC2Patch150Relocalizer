using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using SimonsRelocalizer.Forms;

namespace SimonsRelocalizer
{
    static class Program
    {

        public static string[] languageList = {
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
                                                  "KR/TW - 한국어 - koKR",
                                                  "KR/TW - 繁體中文 (Taiwan, tranditional) - zhTW",
                                                  "SEA - English (Singapore) - enSG"
                                              };

        public static string[] regionList = {
                                                "Default",
                                                "AM (North America, Latin America)",
                                                "EU (Europe)",
                                                "SEA (Southeast Asia + Australia)",
                                                "KR (Korea + Taiwan)",
                                                "CN (China)"
                                            };
        public static FormSC2RelocalizerMain mainForm;
        public static FormRunAsAdmin runAsAdminForm;

        public static string currentRegion;
        public static string newRegion;
        public static string currentLocale;
        public static string currentAsset;
        public static string newLocale;
        public static string newAsset;

        public static int scrollOffset = 7;
        public static string pingRegion;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsRunningAsLocalAdmin())
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.ThreadException += Application_ThreadException;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                mainForm = new FormSC2RelocalizerMain();
                Application.Run(mainForm);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                runAsAdminForm = new FormRunAsAdmin();
                Application.Run(runAsAdminForm);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            try
            {
                result =
                    MessageBox.Show(
                        "There is an error occurred.\n"
                        + "Would you like to email the following email message to Simon?\n\n"
                        + e.Exception.Message + e.Exception.StackTrace, 
                        "Application Error", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Stop);
            }
            finally
            {
                if (result == DialogResult.Yes)
                {
                    EmailException(e.Exception.Message, e.Exception.StackTrace);
                }
                Application.Exit();
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            Exception ex = new Exception();
            try
            {
                ex = (Exception)e.ExceptionObject;
                result =
                    MessageBox.Show(
                        "There is an error occurred.\n"
                        + "Would you like to email the following email message to Simon?\n\n"
                        + ex.Message + ex.StackTrace,
                        "Application Error",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Stop);
            }
            finally
            {
                if (result == DialogResult.Yes)
                {
                    EmailException(ex.Message, ex.StackTrace);
                }
                Application.Exit();
            }
        }

        private static void EmailException(string errorMessage, string stackTrace)
        {
            var emailAddress = "Simon's Relocalizer";
            if(InputBox.Show("Input Contact Email",
                    "Please put in your email address if you would love to "
                    + "get an email feedback from me. If not hit 'Cancel':", ref emailAddress) != DialogResult.OK)
            {
                emailAddress = "Simon's Relocalizer";
            }
            var fromAddress = new MailAddress("simons.relocalizer.sc2@gmail.com", emailAddress);
            var toAddress = new MailAddress("no.lhr0909@gmail.com", "Simon");
            const string fromPassword = "KL3kBGVPxY";
            const string subject = "Simon's Relocalizer Exception Message";
            string body = errorMessage + "\n\n" + stackTrace;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private static bool IsRunningAsLocalAdmin()
        {
            return new WindowsPrincipal
    (WindowsIdentity.GetCurrent()).IsInRole
    (WindowsBuiltInRole.Administrator);
        }
    }

    internal class InputBox
    {
        public static DialogResult Show(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
