using PharmacyLibrary.Exceptions;
using Renci.SshNet;
using System;
using System.IO;


namespace PharmacyLibrary.Services
{
    public class PrescriptionService
    {
        public PrescriptionService() { }

        public void GetPrescription(string prescriptionId)
        {
            string fileName = "Prescription" + prescriptionId + ".pdf";
            String localFile = Path.Combine(GetPrescriptionsDirectory(), fileName);
            String serverFile = @"\public\prescriptions\" + fileName + ".pdf";

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                try
                {
                    client.Connect();
                } catch
                {
                    throw new CustomNotFoundException("Sftp server refuses to connect!");
                }
                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream, null);
                }
                client.Disconnect();
            }

        }
        public void RecieveFileFromHttp(string content, string fileName)
        {
            byte[] bytes = Convert.FromBase64String(content);
            File.WriteAllBytes(Path.Combine(GetPrescriptionsDirectory(), fileName), bytes);
        }

        public string GetPrescriptionsDirectory()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "PharmacyLibrary\\Data\\Prescriptions\\").ToString();
            return path.Replace("\\bin\\Debug", "");
        }

        public string[] GetPrescriptionFileNames()
        {
            return Directory.GetFiles(GetPrescriptionsDirectory(), "*.pdf");
        }

        public string GetPrescriptionFile(string fileName)
        {
            return Path.Combine(GetPrescriptionsDirectory(), fileName);
        }

    }
}
