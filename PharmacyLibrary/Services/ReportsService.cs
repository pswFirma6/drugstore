using PharmacyLibrary.DTO;
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

        public void GenerateReport(String medicineName)
        {
            String filePath = Directory.GetCurrentDirectory();
            String fileName = "MedicineSpecification (" + medicineName + ").txt";


            StreamWriter File = new StreamWriter(Path.Combine(filePath, fileName), true);
            File.Write(GetReportContent(medicineName));
            File.Close();

            SendReport(Path.Combine(filePath, fileName));

        }

        private void SendReport(String filePath)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();

                using (Stream stream = File.OpenRead(filePath))
                {
                    client.UploadFile(stream, @"\public\" + Path.GetFileName(filePath), null);
                }
                client.Disconnect();
            }
        }


        private String GetReportContent(String medicineName)
        {
            String content = "Specification for " + medicineName + "\r\n";
            Medicine medicine = GetMedicine(medicineName);
            content += "Manufacturer: " + medicine.Manufacturer + "\r\n";
            content += "Medicine type: " + medicine.MedicineType.ToString() + "\r\n";
            content += "Medicine description: " + medicine.Description + "\r\n";
            content += "Side effects: " + medicine.SideEffects + "\r\n";
            content += "Intensity: " + medicine.Intensity + "\r\n";
            content += "RecommendedDose: " + medicine.RecommendedDose + "\r\n";

            return content;
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
