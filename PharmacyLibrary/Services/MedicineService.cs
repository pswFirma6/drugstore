using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using PharmacyLibrary.Model;

namespace PharmacyLibrary.Services
{
    public class MedicineService
    {
        private readonly IMedicineRepository medicineRepository;
        public MedicineService(DatabaseContext context)
        {
            medicineRepository = new MedicineRepository(context);
        }
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }
        public Medicine FindById(int id)
        {
            return medicineRepository.FindById(id);
        }
        public void Add(Medicine medicine)
        {
            medicineRepository.Add(medicine);
        }
        public void Update(Medicine medicine)
        {
            medicineRepository.Update(medicine);
        }
        public void Delete(int id)
        {
            medicineRepository.Delete(id);
        }
        public void Save()
        {
            medicineRepository.Save();
        }
        public Medicine GetMedicineInformationByName(String medicineName)
        {
            foreach(Medicine medicine in GetAll())
            {
                if (medicine.Name.Equals(medicineName))
                    return medicine;
            }
            return null;
        }
    }
}
