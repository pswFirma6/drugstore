using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly MedicineSpecificationService reportsService;
        private readonly MedicineConsumptionService consumptionsService;
        private readonly PrescriptionService prescriptionService;

        public ReportsController(DatabaseContext context)
        {
            IMedicineRepository medicineRepository = new MedicineRepository(context);
            reportsService = new MedicineSpecificationService(medicineRepository);
            consumptionsService = new MedicineConsumptionService();
            prescriptionService = new PrescriptionService();
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
        public String GetConsumptionReport()
        {
            consumptionsService.GetConsumptionReport();
            return "OK";
        }

        [HttpGet]
        [Route("pharmacyMedicine")]
        public List<String> GetPharmacyMedications()
        {
            return reportsService.GetMedicineNames();
        }

        [HttpPost]
        [Route("SendPrescription")]
        public String GetPrescription()
        {
            return "OK";
        }
    }
}
