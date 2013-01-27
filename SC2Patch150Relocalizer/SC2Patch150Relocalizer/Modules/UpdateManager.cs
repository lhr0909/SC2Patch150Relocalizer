using System;
using System.IO;
using System.Net;
using System.Text;
using SimonsRelocalizer.Properties;

namespace SimonsRelocalizer
{
    internal class UpdateManager
    {
        private static string url = "https://raw.github.com/lhr0909/SC2Patch150Relocalizer/master/versions.txt";
        private static int versionCount = 0;
        private static string versionNumber = "";
        private static string downloadURL = "";

        public static bool CheckIfUpdatesAvailable()
        {
            var content = CheckUpdateFile();
            versionCount = Convert.ToInt32(content[0]);
            versionNumber = content[1];
            downloadURL = content[2];
            return (versionCount > Settings.Default.VersionCount);
        }

        public static string GetNewVersionNumber()
        {
            if (versionNumber.Length == 0)
            {
                var content = CheckUpdateFile();
                versionNumber = content[1];
            }
            
            return versionNumber;
        }

        public static string GetDownloadURL()
        {
            if (versionNumber.Length == 0)
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