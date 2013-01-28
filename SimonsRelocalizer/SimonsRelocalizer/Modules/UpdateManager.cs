using System;
using System.IO;
using System.Net;
using System.Text;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer.Modules
{
    class UpdateManager
    {
        public const int currentVersionCount = 21;
        public const string currentVersionNumber = "v2.0.0";

        public static int newVersionCount;
        public static string newVersionNumber;
        public static string downloadURL = "";

        private static string url = "https://raw.github.com/lhr0909/SC2Patch150Relocalizer/master/versions.txt";

        public static bool CheckIfUpdatesAvailable()
        {
            var content = CheckUpdateFile();
            newVersionCount = Convert.ToInt32(content[0]);
            newVersionNumber = content[1];
            downloadURL = content[2];
            return (newVersionCount > currentVersionCount);
        }

        public static string GetNewVersionNumber()
        {
            if (newVersionNumber.Length == 0)
            {
                var content = CheckUpdateFile();
                newVersionNumber = content[1];
            }

            return newVersionNumber;
        }

        public static string GetDownloadURL()
        {
            if (downloadURL.Length == 0)
            {
                var content = CheckUpdateFile();
                downloadURL = content[2];
            }
            return downloadURL;
        }

        private static string[] CheckUpdateFile()
        {
            try
            {
                var request = WebRequest.Create(url);
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var content = reader.ReadToEnd().Split('\n');
                return content;
            }
            catch (Exception)
            {
                if (url == "http://dl.dropbox.com/u/23413195/versions.txt")
                {
                    throw;
                }
                url = "http://dl.dropbox.com/u/23413195/versions.txt";
                return CheckUpdateFile();
            }
        }
    }
}
