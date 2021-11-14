using DrugstoreLibrary.Model;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class MedicineController 
    {
        private readonly DatabaseContext context;
        private MedicineService medicineService;
        public MedicineController(DatabaseContext context)
        {
            this.context = context;
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
