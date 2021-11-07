using DrugstoreLibrary.Model;
using PharmacyLibrary.Interfaces;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class PharmacyController : IRepo<PharmacyLibrary.Model.Pharmacy>
    {
        private readonly DatabaseContext context;
        public PharmacyController(DatabaseContext context)
        {
            this.context = context;
        }
        public void Add(PharmacyLibrary.Model.Pharmacy newObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PharmacyLibrary.Model.Pharmacy FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PharmacyLibrary.Model.Pharmacy> GetAll()
        {
            List<PharmacyLibrary.Model.Pharmacy> result = new List<PharmacyLibrary.Model.Pharmacy>();
            context.Pharmacies.ToList().ForEach(pharmacy => result.Add(pharmacy));
            return result;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
