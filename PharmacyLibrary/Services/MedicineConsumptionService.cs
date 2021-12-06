using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class MedicineConsumptionService
    {

        public void GetConsumptionReport()
        {
            String localFile = Path.Combine(Directory.GetCurrentDirectory(), "ConsumptionReport.pdf");
            String serverFile = @"\public\consumptions\MedicationConsumptionReport.pdf";

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();
                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream, null);
                }
                client.Disconnect();
            }

        }


    }
}
