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
    //[Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private ReportsService reportsService;
        private IMedicineRepository medicineRepository;

        public ReportsController(DatabaseContext context)
        {
            medicineRepository = new MedicineRepository(context);
            reportsService = new ReportsService(medicineRepository);
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
        public FileDTO GetConsumptionReport()
        {
            return reportsService.GetConsumptionReport();
        }

        [HttpGet]
        [Route("pharmacyMedicine")]
        public List<String> GetPharmacyMedications()
        {
            return reportsService.GetMedicineNames();
        }
    }
}
