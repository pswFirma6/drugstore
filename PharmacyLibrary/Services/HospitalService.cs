using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class HospitalService
    {
        private readonly IHospitalRepository hospitalRepository;
        public HospitalService(DatabaseContext context)
        {
            hospitalRepository = new HospitalRepository(context);
        }
        public List<Hospital> GetAll()
        {
            return hospitalRepository.GetAll();
        }
        public Hospital FindById(int id)
        {
            return hospitalRepository.FindById(id);
        }
        public void Add(Hospital hospital)
        {
            hospitalRepository.Add(hospital);
        }
        public void Update(Hospital hospital)
        {
            hospitalRepository.Update(hospital);
        }
        public void Delete(int id)
        {
            hospitalRepository.Delete(id);
        }
        public void Save()
        {
            hospitalRepository.Save();
        }
    }
}
