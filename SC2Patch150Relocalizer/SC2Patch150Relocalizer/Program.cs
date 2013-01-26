using System;
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

        public static FormSC2RelocalizerMain mainForm;
        public static FormRunAsAdmin runAsAdminForm;

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
            var fromAddress = new MailAddress("simons.relocalizer.sc2@gmail.com", "Simon's Relocalizer");
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
            WindowsIdentity cur = WindowsIdentity.GetCurrent();
            foreach (IdentityReference role in cur.Groups)
            {
                if (role.IsValidTargetType(typeof(SecurityIdentifier)))
                {
                    SecurityIdentifier sid = (SecurityIdentifier)role.Translate(typeof(SecurityIdentifier));
                    if (sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) || sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid))
                    {
                        return true;
                    }

                }
            }

            return false;
        }
    }
}
