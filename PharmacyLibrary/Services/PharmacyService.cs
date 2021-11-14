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
        public PharmacyService(DatabaseContext context) {
            pharmacyRepository = new PharmacyRepository(context);
        }
        public List<Pharmacy> GetAll()
        {
            return pharmacyRepository.GetAll();
        }
        public Pharmacy FindById(int id)
        {
            return pharmacyRepository.FindById(id);
        }
        public void Add(Pharmacy pharmacy)
        {
            pharmacyRepository.Add(pharmacy);
        }
        public void Update(Pharmacy pharmacy)
        {
            pharmacyRepository.Update(pharmacy);
        }
        public void Delete(int id)
        {
            pharmacyRepository.Delete(id);
        }
        public void Save()
        {
            pharmacyRepository.Save();
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
