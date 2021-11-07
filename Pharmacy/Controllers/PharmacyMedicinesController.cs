using DrugstoreLibrary.Model;
using PharmacyLibrary.Interfaces;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class PharmacyMedicinesController : IRepo<PharmacyMedicines>
    {
        private readonly DatabaseContext context;
        public PharmacyMedicinesController(DatabaseContext context)
        {
            this.context = context;
        }

        public void Add(PharmacyMedicines newObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PharmacyMedicines FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PharmacyMedicines> GetAll()
        {
            List<PharmacyMedicines> result = new List<PharmacyMedicines>();
            context.PharmacyMedicines.ToList().ForEach(pharmacyMedicines => result.Add(pharmacyMedicines));
            return result;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
