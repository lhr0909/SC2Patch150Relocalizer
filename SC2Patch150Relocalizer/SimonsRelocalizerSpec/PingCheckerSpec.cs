using System.Net.NetworkInformation;
using SimonsRelocalizer;
using NUnit.Framework;

namespace SimonsRelocalizerSpec
{
    [TestFixture]
    public class AccountTest
    {
        [Test]
        public void TestPing()
        {
            var pingReply = PingChecker.Ping("127.0.0.1", 1);
            Assert.AreEqual(pingReply.Status, IPStatus.Success);
        }
    }
}