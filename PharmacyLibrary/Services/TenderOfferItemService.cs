using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PhramacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class TenderOfferItemService
    {
        private readonly ITenderOfferItemRepository tenderOfferItemRepository;
        private readonly MedicineService medicineService;


        public TenderOfferItemService(ITenderOfferItemRepository iRepository)
        {
            tenderOfferItemRepository = iRepository;
            DatabaseContext context = new DatabaseContext();
            IMedicineRepository medicineRepository = new MedicineRepository(context);
            medicineService = new MedicineService(medicineRepository);

        }

        public List<TenderOfferItem> GetAll()
        {
            return tenderOfferItemRepository.GetAll();
        }

        public List<TenderOfferItem> GetById(int id)
        {
            List<TenderOfferItem> items = new List<TenderOfferItem>();
           foreach(TenderOfferItem offerItem in GetAll())
            {
                if(offerItem.TenderOfferId == id)
                {
                    items.Add(offerItem);
                }
            }
            return items;
        }
        public List<TenderOfferItemDto> GetTenderOfferItems(int offerId)
        {
            List<TenderOfferItemDto> offerItems = new List<TenderOfferItemDto>();
            foreach (TenderOfferItem item in GetAll())
            {
                if (item.TenderOfferId == offerId)
                {
                    TenderOfferItemDto dto = new TenderOfferItemDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        TenderOfferId = offerId
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
                tenderOfferItemRepository.Add(item);
                tenderOfferItemRepository.Save();
            }
        }

        public bool CheckQuantity(List<TenderOfferItemDto> offerItems)
        {
            foreach (TenderOfferItemDto tenderOfferItem in offerItems)
            {
                Medicine medicine = medicineService.GetMedicineInformationByName(tenderOfferItem.Name);
                if (medicine == null || !medicineService.IsEnoughAmount(medicine.Id, tenderOfferItem.Quantity)) return false;
                
            }
            return true;
        }
    }
}
