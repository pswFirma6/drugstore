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
    public class TenderOfferTests
    {
        private DatabaseContext context = new DatabaseContext();
        private ITenderOfferRepository offerRepository;
        private TenderOfferService offerService;
        private ITenderOfferItemRepository itemRepository;
        private TenderOfferItemService itemService;

        [Fact]
        public void Add_tender_offer()
        {
            offerRepository = new TenderOfferRepository(context);
            offerService = new TenderOfferService(offerRepository);

            TenderOffer offer = new TenderOffer
            {
                Id = 0,
                TenderId = 1,
                PharmacyName = "Pharmacy1"
            };

            offerRepository.Add(offer);
            offerRepository.Save();

            offer.Id.ShouldNotBe(0);
        }

        [Fact]
        public void Add_tender_offer_item()
        {
            itemRepository = new TenderOfferItemRepository(context);
            itemService = new TenderOfferItemService(itemRepository);

            TenderOfferItem item = new TenderOfferItem
            {
                Id = 0,
                Name = "Brufen",
                Quantity = 20,
                Price = 500.0,
                TenderOfferId = 1
            };

            itemRepository.Add(item);
            itemRepository.Save();

            item.Id.ShouldNotBe(0);
        }
    }
}
