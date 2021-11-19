using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class PharmacyService
    {
        private readonly IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository iRepository) {
            pharmacyRepository = iRepository;
        }

        public List<Pharmacy> GetAll()
        {
            return pharmacyRepository.GetAll();
        }
        
        public List<string> GetPharmacyNames()
        {
            List<string> pharmacyNames = new List<string>();
            foreach (Pharmacy pharmacy in GetAll())
                pharmacyNames.Add(pharmacy.Name);
            return pharmacyNames;
        }
    }
}
