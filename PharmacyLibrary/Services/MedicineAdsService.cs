using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class MedicineAdsService
    {
        private readonly IMedicineAdsRepository medicineAdsRepository;
        public MedicineAdsService(IMedicineAdsRepository iRepository)
        {
            medicineAdsRepository = iRepository;
        }
        public List<MedicineAd> GetAll()
        {
            return medicineAdsRepository.GetAll();
        }
        public void AddMedicineAd(MedicineAd medicineAd)
        {
            medicineAd.Id = medicineAdsRepository.GetAll().Count + 1;
            medicineAdsRepository.Add(medicineAd);
            medicineAdsRepository.Save();
        }

        public void DeleteMedicineAd(MedicineAd medicineAd)
        {
            medicineAdsRepository.Delete(medicineAd.Id);
            medicineAdsRepository.Save();
        }
    }
}
