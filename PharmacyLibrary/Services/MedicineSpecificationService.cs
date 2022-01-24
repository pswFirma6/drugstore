using PharmacyLibrary.IRepository;
using PhramacyLibrary.Model;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using PharmacyLibrary.Exceptions;

namespace PharmacyLibrary.Services
{
    public class MedicineSpecificationService
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicineSpecificationService(IMedicineRepository imedicineRepository)
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
            String fileName = "MedicineSpecification (" + medicineName + ").pdf";

            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString(GetReportContent(medicineName), new PdfFont(PdfFontFamily.Helvetica, 11f), new PdfSolidBrush(Color.Black), 10, 10);


            StreamWriter File = new StreamWriter(Path.Combine(filePath, fileName), true);
            doc.SaveToStream(File.BaseStream);
            File.Close();

            SendReport(Path.Combine(filePath, fileName));

        }

        private void SendReport(String filePath)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                try
                {
                    client.Connect();
                }
                catch
                {
                    throw new CustomNotFoundException("Sftp server is not running!");
                }
                using (Stream stream = File.OpenRead(filePath))
                {
                    client.UploadFile(stream, @"\public\specifications" + Path.GetFileName(filePath), null);
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

        public List<string> GetMedicineNames()
        {
            List<String> names = new List<String>();
            foreach (Medicine med in medicineRepository.GetAll())
            {
                names.Add(med.Name);
            }
            return names;
        }

        public string GetSpecificationsDirectory()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "PharmacyLibrary\\Data\\Specifications\\").ToString();
            return path.Replace("\\bin\\Debug", "");
        }

        public string[] GetSpecificationsDirectoryFileNames()
        {
            return Directory.GetFiles(GetSpecificationsDirectory(), "*.pdf");
        }

        public string GetSpecificationFile(string fileName)
        {
            return Path.Combine(GetSpecificationsDirectory(), fileName);
        }

    }
}
