using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
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
        public String GetMedicineSpecification(String medicineName)
        {
            if (reportsService.GetMedicine(medicineName)!=null)
                reportsService.GenerateReport(medicineName);

            return "OK";
        }

        [HttpPost]
        [Route("consumptionReport")]
        public String GetConsumptionReport()
        {
            reportsService.GetConsumptionReport();
            return "OK";
        }
    }
}
