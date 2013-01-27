using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace SimonsRelocalizer
{
    public class PingChecker
    {
        private const string pingData = "SimonsRelocalizerTestingPingHere";

        public static List<IPAddress> result;

        public static List<long> pingTimeout; 

        public static void CheckPing(string hostname)
        {
            if (hostname == null)
            {
                return;
            }
            int failCount = 0;
            result = new List<IPAddress>();
            pingTimeout = new List<long>();
            for (int ttl = 1; ttl < 20; ttl++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                var reply = Ping(hostname, ttl);
                stopwatch.Stop();
                if (reply.Status == IPStatus.TtlExpired)
                {
                    result.Add(reply.Address);
                    pingTimeout.Add(stopwatch.ElapsedMilliseconds);
                }
                else if (reply.Status == IPStatus.Success)
                {
                    result.Add(reply.Address);
                    pingTimeout.Add(stopwatch.ElapsedMilliseconds);
                    break;
                }
                else
                {
                    failCount = failCount + 1;
                    if (failCount > 5)
                    {
                        break;
                    }
                }
            }
        }

        public static PingReply Ping(string hostname, int ttl)
        {
            return new Ping().Send(hostname, 700, Encoding.ASCII.GetBytes(pingData), new PingOptions(ttl, true));
        }

        public static string GetBattleNetHostname(string region)
        {
            if (region.Equals("us"))
            {
                return "us.logon.battle.net";
            }
            if (region.Equals("eu"))
            {
                return "eu.logon.battle.net";
            }
            if (region.Equals("sg"))
            {
                return "sg.logon.battle.net";
            }
            if (region.Equals("kr"))
            {
                return "kr.logon.battle.net";
            }
            if (region.Equals("CN"))
            {
//                return "cn.logon.battle.net";
                return "124.160.81.22";
            }
            return null;
        }

        public static string GetPingTimeout()
        {
            if (pingTimeout.Count > 0)
            {
                return pingTimeout[pingTimeout.Count - 1].ToString() + "ms"; 
            }
            else
            {
                return "N/A";
            }
        }
    }
}
