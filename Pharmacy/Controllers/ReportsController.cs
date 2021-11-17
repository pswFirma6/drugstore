using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Model;
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
        public ReportsController(DatabaseContext context)
        {
            reportsService = new ReportsService(context);
        }

        [HttpPost]
        [Route("report")]
        public String GetMedicineSpecification(String medicineName)
        {
            if (reportsService.GetMedicine(medicineName)!=null)
                reportsService.GenerateReport("Brufen");

            return "OK";
        }
    }
}
