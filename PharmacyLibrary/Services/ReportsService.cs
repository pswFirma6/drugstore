using PharmacyLibrary.DTO;
using PharmacyLibrary.Exceptions;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Model.Enums;
using PharmacyLibrary.Repository;
using PhramacyLibrary.Model;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class ReportsService
    {
        private readonly IMedicineRepository medicineRepository;

        public ReportsService(IMedicineRepository imedicineRepository)
        {
            medicineRepository = imedicineRepository;
        }

        public Medicine GetMedicine(String medicineName)
        {
            foreach (Medicine medicine in medicineRepository.GetAll())
            {
                if (medicine.Name.Equals(medicineName))
                    return medicine;
            }
            return null;
        }



        public void GetConsumption(string fileName)
        {
            String localFile = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            String serverFile = @"\public\consumptions\" + fileName;

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                try
                {
                    client.Connect();
                }
                catch
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

        public FileDto GetConsumptionReport()
        {
            string localFile = Path.Combine(Directory.GetCurrentDirectory(), "ConsumptionReport.txt");
            string serverFile = @"\public\MedicationConsumptionReport.txt";
            FileDto file = new FileDto();

            //promenjen server IP za potrebe testiranja
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.0.15", "tester", "password")))
            {
                client.Connect();
                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(serverFile, stream, null);
                }
                client.Disconnect();
            }
            //promenjeno za probu!
            string[] fileName = serverFile.Split('\\');
            file.Name = fileName[fileName.Length - 1];
            return file;

        }
        public List<string> GetMedicineNames()
        {
            List<String> names = new List<String>();
            foreach (Medicine med in medicineRepository.GetAll())
            {
                names.Add(med.Name);
            }
            return names;
        }

    }
}
