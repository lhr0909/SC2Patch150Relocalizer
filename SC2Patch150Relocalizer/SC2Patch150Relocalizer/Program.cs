using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new FormSC2RelocalizerMain();
            Application.Run(mainForm);
        }
    }
}
