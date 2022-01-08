using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class HospitalRepository : Repo<Hospital>, IHospitalRepository
    {
        public HospitalRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
