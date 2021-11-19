using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using PharmacyLibrary.Model;
using PharmacyLibrary.Model.Enums;

namespace PharmacyLibrary.Services
{
    public class MedicineService
    {
        private readonly IMedicineRepository medicineRepository;
        public MedicineService(IMedicineRepository iMedicineRepository)
        {
            medicineRepository = iMedicineRepository;
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
        public List<Medicine> SearchMedicineByNameAndSubstance(String medicineName, MedicineType medicineType)
        {
            List<Medicine> searchedMedicine = new List<Medicine>();
            foreach (Medicine medicine in GetAll())
            {
                if (medicineType == MedicineType.NO_TYPE && !medicineName.Equals(""))
                {
                    searchedMedicine = SearchMedicineOnlyByName(medicineName);
                }
                else if (medicineName.Equals("") && medicineType != MedicineType.NO_TYPE)
                {
                    searchedMedicine = SearchMedicineOnlyByType(medicineType);
                }
                else if (medicineType != MedicineType.NO_TYPE && !medicineName.Equals(""))
                {
                    searchedMedicine = SearchByBothNameAndType(medicineName, medicineType);
                }
                else
                {
                    searchedMedicine = GetAll();
                }
            }
            return searchedMedicine;
        }
        public List<Medicine> SearchMedicineOnlyByName(String medicineName)
        {
            List<Medicine> searchedMedicine = new List<Medicine>();
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.Name.Contains(medicineName))
                {
                    searchedMedicine.Add(medicine);
                }
            }
            return searchedMedicine;
        }
        public List<Medicine> SearchMedicineOnlyByType(MedicineType medicineType)
        {
            List<Medicine> searchedMedicine = new List<Medicine>();
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.MedicineType == medicineType)
                {
                    searchedMedicine.Add(medicine);
                }
            }
            return searchedMedicine;
        }
        public List<Medicine> SearchByBothNameAndType(String medicineName, MedicineType medicineType)
        {
            List<Medicine> searchedMedicine = new List<Medicine>();
            List<Medicine> tempListOfMedicine = SearchMedicineOnlyByName(medicineName);
            foreach (Medicine medicine in tempListOfMedicine)
            {
                if (medicine.MedicineType == medicineType)
                {
                    searchedMedicine.Add(medicine);
                }
            }
            return searchedMedicine;
        }

        public void SubstractMedicineQuantity(int idMedicine, int usedDrugs)
        {
            Medicine medicine = FindById(idMedicine);
            if(medicine != null && medicine.Quantity >= usedDrugs)
            {
                medicine.Quantity -= usedDrugs;
                Update(medicine);
            }
        }

        public void AddMedicineQuantity(int idMedicine, int addedDrugs)
        {
            Medicine medicine = FindById(idMedicine);
            if (medicine != null)
            {
                medicine.Quantity += addedDrugs;
                Update(medicine);
            }
        }

        public bool CheckQuantityOfMedicine(int idMedicine, int quantity)
        {
            Medicine medicine = FindById(idMedicine);

            return medicine != null && medicine.Quantity == quantity;
        }
    }
}
