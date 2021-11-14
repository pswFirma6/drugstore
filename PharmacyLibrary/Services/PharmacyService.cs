using DrugstoreLibrary.Model;
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
        private IPharmacyRepository pharmacyRepository;
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
    }
}
