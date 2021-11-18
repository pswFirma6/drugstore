using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using PhramacyLibrary.Model;

namespace Pharmacy.Controllers
{
    public class MedicineController
    {
        private MedicineService medicineService;
        private IMedicineRepository medicineRepository;
        public MedicineController(DatabaseContext context)
        {
            medicineRepository = new MedicineRepository(context);
            medicineService = new MedicineService(medicineRepository);
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
