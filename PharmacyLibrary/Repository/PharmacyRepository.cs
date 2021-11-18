using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class PharmacyRepository : Repo<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
