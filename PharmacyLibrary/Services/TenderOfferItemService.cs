using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class TenderOfferItemService
    {
        private readonly ITenderOfferItemRepository tenderOfferItemRepository;
        private MedicineService medicineService;
        private IMedicineRepository medicineRepository;


        public TenderOfferItemService(ITenderOfferItemRepository iRepository)
        {
            tenderOfferItemRepository = iRepository;
            DatabaseContext context = new DatabaseContext();
            medicineRepository = new MedicineRepository(context);
            medicineService = new MedicineService(medicineRepository);

        }

        public List<TenderOfferItem> GetAll()
        {
            return tenderOfferItemRepository.GetAll();
        }

        public List<TenderOfferItemDto> GetTenderOfferItems(int tenderId)
        {
            List<TenderOfferItemDto> offerItems = new List<TenderOfferItemDto>();
            foreach (TenderOfferItem item in GetAll())
            {
                if (item.Id == tenderId)
                {
                    TenderOfferItemDto dto = new TenderOfferItemDto
                    {
                        Id=item.Id,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Price=item.Price
                    };
                    offerItems.Add(dto);
                }
            }
            return offerItems;
        }
        public void AddTenderOfferItems(List<TenderOfferItem> tenderOfferItems)
        {
            foreach (TenderOfferItem item in tenderOfferItems)
            {
                item.Id = tenderOfferItemRepository.GetAll().Count + 1;
                tenderOfferItemRepository.Add(item);
                tenderOfferItemRepository.Save();
            }
        }
        public bool CheckQuantity(List<TenderOfferItem> offerItems)
        {
            foreach (TenderOfferItem tenderOfferItem in offerItems)
            {
                int id = medicineService.GetMedicineInformationByName(tenderOfferItem.Name).Id;
                if (!medicineService.IsEnoughAmount(id, tenderOfferItem.Quantity)) return false;
            }
            return true;
        }
    }
}
