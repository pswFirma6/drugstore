using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;

namespace Pharmacy.Controllers
{
    [ApiController]
    public class MedicineController
    {
        private MedicineService medicineService;
        private IMedicineRepository medicineRepository;
        public MedicineController(DatabaseContext context)
        {
            medicineRepository = new MedicineRepository(context);
            medicineService = new MedicineService(medicineRepository);
        }

        [HttpPost]
        [Route("addMedicine")]
        public void Add(Medicine medicine)
        {
            medicineService.Add(medicine);
        }

        [HttpGet]
        [Route("getMedicines")]
        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }

        [HttpPost]
        [Route("checkMedicine")]
        public bool CheckMedicine(MedicineDTO medicine)
        {
            return medicineService.CheckMedicine(medicine);
        }

        [HttpPost]
        [Route("orderMedicine")]
        public void OrderMedicine(MedicineDTO medicine)
        {
            medicineService.OrderMedicine(medicine);
        }

    }
}
