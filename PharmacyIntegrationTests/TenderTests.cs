using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PharmacyIntegrationTests
{
    public class TenderTests
    {
        private DatabaseContext context = new DatabaseContext();
        private ITenderRepository repository;
        private TenderService service;
        private ITenderItemRepository itemRepository;
        private TenderItemService itemService;

        [Fact]
        public void Add_tender()
        {
            repository = new TenderRepository(context);
            service = new TenderService(repository);

            Tender tender = new Tender
            {
                Id = 0,
                CreationDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = new DateTime(2022, 3, 1)
            };

            repository.Add(tender);
            repository.Save();

            tender.Id.ShouldNotBe(0);

        }

        [Fact]
        public void Add_tender_item()
        {
            itemRepository = new TenderItemRepository(context);
            itemService = new TenderItemService(itemRepository);

            TenderItem item = new TenderItem
            {
                Id = 0,
                Name = "Andol",
                Quantity = 20,
                TenderId = 2
            };

            itemRepository.Add(item);
            itemRepository.Save();

            item.Id.ShouldNotBe(0);
        }


    }
}
