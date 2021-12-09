using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IMedicineRepository medicineRepository;
        private ReportsService reportsService;
        private PrescriptionService prescriptionService;

        public ReportsController(DatabaseContext context)
        {
            medicineRepository = new MedicineRepository(context);
            reportsService = new ReportsService(medicineRepository);
            prescriptionService = new PrescriptionService();
        }

        [HttpGet]
        [Route("prescriptions")]
        public string[] GetPrescriptionNames()
        {
            return prescriptionService.GetPrescriptionFileNames();
        }


        [HttpPost]
        [Route("report")]
        public String GetMedicineSpecification([FromBody] String medicineName)
        {
            if (reportsService.GetMedicine(medicineName) != null)
            {
                reportsService.GenerateReport(medicineName);
                return "OK";
            }
            return "Not ok";
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
            prescriptionService.RecieveFileFromHttp(content,fileName);
        }
    }
}
