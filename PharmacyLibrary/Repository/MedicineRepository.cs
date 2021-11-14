using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using PharmacyLibrary.Model;

namespace PharmacyLibrary.Repository
{
    public class MedicineRepository : Repo<Medicine>, IMedicineRepository
    {
        public MedicineRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
