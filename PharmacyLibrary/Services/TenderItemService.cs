using Microsoft.Extensions.Configuration;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class TenderItemService
    {
        private readonly ITenderItemRepository tenderItemRepository;
        private readonly TenderOfferItemService tenderOfferItemService;
        public TenderItemService(ITenderItemRepository iRepository)
        {
            tenderItemRepository = iRepository;
            DatabaseContext context = new DatabaseContext();
            ITenderOfferItemRepository itenderOfferItemRepository = new TenderOfferItemRepository(context);
            tenderOfferItemService = new TenderOfferItemService(itenderOfferItemRepository);
        }

        public List<TenderItem> GetAll()
        {
            return tenderItemRepository.GetAll();
        }

        public List<TenderItemDto> GetTenderItems(int tenderId)
        {
            List<TenderItemDto> items = new List<TenderItemDto>();
            foreach(TenderItem item in GetAll())
            {
                if(item.TenderId == tenderId)
                {
                    TenderItemDto dto = new TenderItemDto
                    {
                        Name = item.Name,
                        Quantity = item.Quantity
                    };
                    items.Add(dto);
                }
            }
            return items;
        }

        public void AddTenderItems(List<TenderItem> items)
        {
            foreach(TenderItem item in items)
            {
                tenderItemRepository.Add(item);
                tenderItemRepository.Save();
            }
        }

        public List<MedicineDTO> GetMedicines(int id, string url)
        {
            List<TenderOfferItem> tenderOfferItems = tenderOfferItemService.GetById(id);
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            foreach (TenderOfferItem tenderOfferItem in tenderOfferItems)
            {
                MedicineDTO medicine = new MedicineDTO(tenderOfferItem.Name, tenderOfferItem.Quantity);
                PostRequest(url, medicine);
                medicines.Add(medicine);
            }
            return medicines;
        }
        private void PostRequest(string url, MedicineDTO medicine)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddJsonBody(medicine);
            client.Post(request);
        }
    }
}
