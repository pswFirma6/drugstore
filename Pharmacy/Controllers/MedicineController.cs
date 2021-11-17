using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.Model;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private MedicineService medicineService;
        public MedicineController(DatabaseContext context)
        {
            medicineService = new MedicineService(context);
        }
        public void Add(Medicine medicine)
        {
            medicineService.Add(medicine);
        }
        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }
    }
}
