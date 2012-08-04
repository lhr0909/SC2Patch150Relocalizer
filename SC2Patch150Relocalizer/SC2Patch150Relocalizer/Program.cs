using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimonsRelocalizer
{
    static class Program
    {

        public static string[] languageList = {
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
                                                  "enSG - SEA - English (Singapore)"
                                              };

        public static FormSC2RelocalizerMain mainForm;

        public static string currentLocale;
        public static string currentAsset;
        public static string newLocale;
        public static string newAsset;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new FormSC2RelocalizerMain();
            Application.Run(mainForm);
        }
    }
}
