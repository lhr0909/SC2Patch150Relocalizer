﻿using System;
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
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            var content = reader.ReadToEnd().Split('\n');
            versionCount = Convert.ToInt32(content[0]);
            versionNumber = content[1];
            downloadURL = content[2];
            return (versionCount > Settings.Default.VersionCount);
        }

        public static string GetNewVersionNumber()
        {
            if (versionNumber.Length == 0)
            {
                var request = WebRequest.Create(url);
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var content = reader.ReadToEnd().Split('\n');
                versionNumber = content[1];
            }
            return versionNumber;
        }

        public static string GetDownloadURL()
        {
            if (versionNumber.Length == 0)
            {
                var request = WebRequest.Create(url);
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                var content = reader.ReadToEnd().Split('\n');
                downloadURL = content[2];
            }
            return downloadURL;
        }
    }
}