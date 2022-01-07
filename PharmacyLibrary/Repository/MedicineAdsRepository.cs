using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository
{
    public class MedicineAdsRepository: Repo<MedicineAd>, IMedicineAdsRepository
    {
        public MedicineAdsRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
