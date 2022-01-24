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
            return tenderRepository.GetTenders();
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
                    StartDate = tender.TenderDateRange.StartDate.ToString(),
                    EndDate = tender.TenderDateRange.EndDate.ToString(),
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
                Id = GetLastID() + 1,
                CreationDate = DateTime.Parse(dto.CreationDate),
                TenderDateRange = new Shared.DateRange
                {
                    StartDate = DateTime.Parse(dto.StartDate),
                    EndDate = AssignEndDate(dto.EndDate)
                },
                HospitalApiKey = dto.HospitalApiKey,
                HospitalTenderId = dto.Id,
                Opened = dto.Opened
            };
            SetTenderItems(dto.TenderItems, tender);
            tenderRepository.Add(tender);
            tenderRepository.Save();
        }

        private int GetLastID()
        {
            List<Tender> tenders = GetTenders();
            if (tenders.Count == 0)
            {
                return 0;
            }
            return tenders[tenders.Count - 1].Id;
        }

        private DateTime AssignEndDate(string endDate)
        {
            return string.IsNullOrEmpty(endDate) ? new DateTime(2050, 01, 01) : DateTime.Parse(endDate);
        }

        public void CloseTender(TenderOffer tenderOffer, string url)
        {
            Tender tender = GetTenders().Find(tender => tenderOffer.TenderId == tender.HospitalTenderId);
            tender.Opened = false;
            List<MedicineDTO> medicines = tenderItemService.GetMedicines(tenderOffer.Id, url);
            foreach (MedicineDTO medicine in medicines)
            {
                medicineService.OrderMedicine(medicine);
            }
            tenderRepository.Update(tender);
            tenderRepository.Save();
           
        }

        private Tender SetTenderItems(List<TenderItemDto> dtos, Tender tender)
        {
            foreach (TenderItemDto dto in dtos)
            {
                tender.AddTenderItem(tender, dto.Name, dto.Quantity);
            }
            return tender;
        }

        public Tender FindById(int tenderId)
        {
            return tenderRepository.FindById(tenderId);
        }



    }
}
