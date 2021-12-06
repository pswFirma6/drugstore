using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class PrescriptionService
    {
        public PrescriptionService() { }

        public void GetPrescription(string prescriptionId)
        {
            string fileName = "Prescription" + prescriptionId +".pdf";
            String localFile = Path.Combine(GetPrescriptionsDirectory(), fileName);
            String serverFile = @"\public\prescriptions\" + fileName + ".pdf";

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

        public string GetPrescriptionsDirectory()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "Data\\Prescriptions\\").ToString();
            return path.Replace("\\bin\\Debug", "");
        }

    }
}
