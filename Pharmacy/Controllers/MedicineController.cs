using PhramacyLibrary.Model;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyLibrary.Model;

namespace Pharmacy.Controllers
{
    public class MedicineController 
    {
        private readonly MedicineService medicineService;
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
