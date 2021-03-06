using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class TenderService
    {
        private readonly ITenderRepository tenderRepository;
        private readonly TenderItemService tenderItemService;
        private readonly MedicineService medicineService;
        
        public TenderService(ITenderRepository iRepository)
        {
            tenderRepository = iRepository;
            DatabaseContext context = new DatabaseContext();
            ITenderItemRepository itemRepository = new TenderItemRepository(context);
            tenderItemService = new TenderItemService(itemRepository);
            IMedicineRepository medicineRepository = new MedicineRepository(context);
            medicineService = new MedicineService(medicineRepository);
        }

        public List<Tender> GetTenders()
        {
            return tenderRepository.GetAll();
        }

        public List<TenderDto> GetTendersWithItems()
        {
            List<TenderDto> tendersWithItems = new List<TenderDto>();
            foreach(Tender tender in GetTenders())
            {
                TenderDto dto = new TenderDto
                {
                    Id = tender.Id,
                    CreationDate = tender.CreationDate.ToString(),
                    StartDate = tender.StartDate.ToString(),
                    EndDate = tender.EndDate.ToString(),
                    TenderItems = tenderItemService.GetTenderItems(tender.Id),
                    Opened = tender.Opened
                };
                tendersWithItems.Add(dto);
            }
            return tendersWithItems;
        }

        public void AddTender(TenderDto dto)
        {
            Tender tender = new Tender
            {
                Id = GetTenders().Count + 1,
                CreationDate = DateTime.Now,
                StartDate = DateTime.Parse(dto.StartDate),
                EndDate = AssignEndDate(dto.EndDate),
                HospitalApiKey = dto.HospitalApiKey,
                HospitalTenderId = dto.Id
            };
            tenderRepository.Add(tender);
            tenderRepository.Save();
            tenderItemService.AddTenderItems(SetTenderItems(dto.TenderItems, tender.Id));
        }

        private DateTime AssignEndDate(string endDate)
        {
            return string.IsNullOrEmpty(endDate) ? new DateTime(2050, 01, 01) : DateTime.Parse(endDate);
        }

        public void CloseTender(TenderOffer tenderOffer, string url)
        {
            Console.WriteLine("Drugstore CloseTender tenderOFfer: " + tenderOffer.Id + " tenderOffer.tenderId: " + tenderOffer.TenderId);
            Tender tender = GetTenders().Find(tender => tenderOffer.TenderId == tender.HospitalTenderId);
            Console.WriteLine("Tender: " + tender.Id);
            tender.Opened = false;
            List<MedicineDTO> medicines = tenderItemService.GetMedicines(tenderOffer.Id, url);
            foreach (MedicineDTO medicine in medicines)
            {
                medicineService.OrderMedicine(medicine);
            }
            tenderRepository.Update(tender);
            tenderRepository.Save();
           
        }

        private List<TenderItem> SetTenderItems(List<TenderItemDto> dtos, int tenderId)
        {
            List<TenderItem> items = new List<TenderItem>();
            foreach (TenderItemDto dto in dtos)
            {
                TenderItem item = new TenderItem()
                {
                    Name = dto.Name,
                    Quantity = dto.Quantity,
                    TenderId = tenderId
                };
                items.Add(item);
            }
            return items;
        }

        public Tender FindById(int tenderId)
        {
            return tenderRepository.FindById(tenderId);
        }



    }
}
