using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class PharmacyMedicinesService
    {
        private readonly IPharmacyMedicinesRepository pharmacyMedicinesRepository;
        public PharmacyMedicinesService(DatabaseContext context)
        {
            pharmacyMedicinesRepository = new PharmacyMedicinesRepository(context);
        }
        public List<PharmacyMedicines> GetAll()
        {
            return pharmacyMedicinesRepository.GetAll();
        }
        public PharmacyMedicines FindById(int id)
        {
            return pharmacyMedicinesRepository.FindById(id);
        }
        public void Add(PharmacyMedicines pharmacyMedicines)
        {
            pharmacyMedicinesRepository.Add(pharmacyMedicines);
        }
        public void Update(PharmacyMedicines pharmacyMedicines)
        {
            pharmacyMedicinesRepository.Update(pharmacyMedicines);
        }
        public void Delete(int id)
        {
            pharmacyMedicinesRepository.Delete(id);
        }
        public void Save()
        {
            pharmacyMedicinesRepository.Save();
        }
        public void UpdatePharmacyMedicineQuantity(int idPharmacy, int idMedicine, int spentNumberOfDrugs)
        {
            foreach (PharmacyMedicines pharmacyMedicine in GetAll())
            {
                if (pharmacyMedicine.IdMedicine == idMedicine && pharmacyMedicine.IdPharmacy == idPharmacy)
                {
                    pharmacyMedicine.Quantity -= spentNumberOfDrugs;
                    Update(pharmacyMedicine);
                    break;
                }
            }
        }
    }
}
