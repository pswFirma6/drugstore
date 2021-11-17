using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PhramacyLibrary.Model;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PharmacyLibrary.Services
{
    class MedicineSpecificationService
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicineSpecificationService(DatabaseContext context)
        {
            medicineRepository = new MedicineRepository(context);
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
            String filePath = @"C:\Users\Milica\Desktop\PSW-repos\drugstore-repo\drugstore";
            String fileName = "MedicineSpecification (" + medicineName + ").txt";


            StreamWriter File = new StreamWriter(Path.Combine(filePath, "MedicationConsumptionReport.txt"), true);
            File.Write(GetReportContent(medicineName));
            File.Close();

            SendReport(Path.Combine(filePath, "MedicineSpecification.txt"));

        }

        private void SendReport(String filePath)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();

                using (Stream stream = File.OpenRead(filePath))
                {
                    client.UploadFile(stream, @"\MedicineSpecifications\" + Path.GetFileName(filePath), null);
                }
                client.Disconnect();
            }
        }

        private String GetReportContent(String medicineName)
        {
            String content = "Specification for " + medicineName +"\r\n";
            Medicine medicine = GetMedicine(medicineName);
            content += "Manufacturer: " + medicine.Manufacturer + "\r\n";
            content += "Medicine type: " + medicine.MedicineType.ToString() + "\r\n";
            content += "Medicine description: " + medicine.Description + "\r\n";
            content += "Side effects: " + medicine.SideEffects + "\r\n";
            content += "Intensity: " + medicine.Intensity + "\r\n";
            content += "RecommendedDose: " + medicine.RecommendedDose + "\r\n";

            return content;
        }

    }
}
