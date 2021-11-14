using DrugstoreLibrary.Model;
using PharmacyLibrary.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class MedicineRepository : Repo<Medicine>, IMedicineRepository
    {
        public MedicineRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
