using Renci.SshNet;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace PharmacyAppTests.IntegrationTests
{
    public class ReportTests
    {

        [Fact]
        public void CheckConnection()
        {
            bool connected = true;
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "passwor")))
            {
                if (!client.IsConnected)
                    connected = false;
            }

            connected.ShouldBeFalse();
        }
    }
}
