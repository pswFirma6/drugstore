using PharmacyLibrary.Exceptions;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class MedicineConsumptionService
    {

        public MedicineConsumptionService() { }

        public void GetConsumptionReport()
        {
            string fileName = "ConsumptionReport.pdf";
            String localFile = Path.Combine(GetConsumptionsDirectory(),fileName);
            String serverFile = @"\public\consumptions\"+fileName+".pdf";

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                try
                {
                    client.Connect();
                } catch
                {
                    throw new CustomNotFoundException("Sftp server is not running!");
                }
                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream, null);
                }
                client.Disconnect();
            }

        }

        public string GetConsumptionsDirectory()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "PharmacyLibrary\\Data\\Consumptions\\").ToString();
            return path.Replace("\\bin\\Debug", "");
        }


    }
}
