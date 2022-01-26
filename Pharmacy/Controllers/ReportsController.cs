using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.DTO;
using PharmacyLibrary.Exceptions;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IMedicineRepository medicineRepository;
        private ReportsService reportsService;
        private readonly MedicineSpecificationService specificationsService;
        private readonly PrescriptionService prescriptionService;

        public ReportsController(DatabaseContext context)
        {
            medicineRepository = new MedicineRepository(context);
            reportsService = new ReportsService(medicineRepository);
            prescriptionService = new PrescriptionService();
            specificationsService = new MedicineSpecificationService(medicineRepository);
        }

        [HttpGet]
        [Route("prescriptions")]
        public string[] GetPrescriptionNames()
        {
            return prescriptionService.GetPrescriptionFileNames();
        }

        [HttpGet]
        [Route("specifications")]
        public string[] GetSpecificationNames()
        {
            return specificationsService.GetSpecificationsDirectoryFileNames();
        }

        [HttpGet]
        [Route("getPrescriptionPdf/{fileName}")]
        public async Task<IActionResult> GetPrescriptionFile(String fileName)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(prescriptionService.GetPrescriptionFile(fileName), FileMode.Open))
                await stream.CopyToAsync(memory);

            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";

            return File(memory, contentType, fileName);
        }
        [HttpGet]
        [Route("getSpecificationPdf/{fileName}")]
        public async Task<IActionResult> GetSpecificationFile(String fileName)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(specificationsService.GetSpecificationFile(fileName), FileMode.Open))
                await stream.CopyToAsync(memory);

            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";

            return File(memory, contentType, fileName);
        }


        [HttpPost]
        [Route("report")]
        public IActionResult GetMedicineSpecification([FromBody] String medicineName)
        {
            if (reportsService.GetMedicine(medicineName) != null)
            {
                specificationsService.GenerateReport(medicineName);
                return Ok();
            } else
            {
                throw new CustomNotFoundException("Medicine by name: " + medicineName + " doesn't exist!");
            }
        }

        [HttpGet]
        [Route("consumptionReport")]
        public FileDto GetConsumptionReport()
        {
            return reportsService.GetConsumptionReport();
        }

        [HttpGet]
        [Route("pharmacyMedicine")]
        public List<String> GetPharmacyMedications()
        {
            return reportsService.GetMedicineNames();
        }

        [HttpPost]
        [Route("sendPrescription")]
        public void GetPrescription([FromBody] string content, [FromHeader] string fileName)
        {
            prescriptionService.RecieveFileFromHttp(content, fileName);
        }

        [HttpPost]
        [Route("downloadPrescription")]
        public void DownloadPrescription([FromBody] string fileName)
        {
            prescriptionService.GetPrescription(fileName);
        }

        [HttpPost]
        [Route("downloadConsumption")]
        public void DownloadConsumption([FromBody] string fileName)
        {
            reportsService.GetConsumption(fileName);
        }
    }
}
