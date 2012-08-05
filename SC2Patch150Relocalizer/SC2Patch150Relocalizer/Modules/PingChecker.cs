using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace SimonsRelocalizer
{
    public class PingChecker
    {
        private const string pingData = "SimonsRelocalizerTestingPingYeah";

//        public static int CheckPing(string hostname)
//        {
//            var ttl = 1;
//            var stopwatch = new Stopwatch();
//            stopwatch.Reset();
//            stopwatch.Start();
//            var reply = Ping(hostname, ttl);
//            stopwatch.Stop();
//
//            var result = new List<IPAddress>();
//            if (reply.Status == IPStatus.Success)
//            {
//                result.Add(reply.Address);
//            }
//            else if (reply.Status == IPStatus.TtlExpired)
//            {
//                result.Add(reply.Address);
//                var tempResult = GetTraceRoute(hostname, ttl + 1);
//                result.AddRange(tempResult);
//            }
//        }

        public static PingReply Ping(string hostname, int ttl)
        {
            return new Ping().Send(hostname, 1000, Encoding.ASCII.GetBytes(pingData), new PingOptions(ttl, true));
        }
    }
}
