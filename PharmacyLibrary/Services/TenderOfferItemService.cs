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
                tenderOfferItemRepository.Add(item);
                tenderOfferItemRepository.Save();
            }
        }

        public bool CheckQuantity(List<TenderOfferItemDto> offerItems)
        {
            foreach (TenderOfferItemDto tenderOfferItem in offerItems)
            {
                Medicine medicine = medicineService.GetMedicineInformationByName(tenderOfferItem.Name);
                if(medicine != null)
                {
                    if (!medicineService.IsEnoughAmount(medicine.Id, tenderOfferItem.Quantity)) return false;
                }
                else
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
