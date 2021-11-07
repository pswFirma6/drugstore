using DrugstoreLibrary.Model;
using PharmacyLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class MedicineController : IRepo<Medicine>
    {
        private readonly DatabaseContext context;
        public MedicineController(DatabaseContext context)
        {
            this.context = context;
        }
        public void Add(Medicine newObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Medicine FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medicine> GetAll()
        {
            List<Medicine> result = new List<Medicine>();
            context.Medicines.ToList().ForEach(medicine => result.Add(medicine));
            return result;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
