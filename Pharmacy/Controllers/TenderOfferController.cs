using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PharmacyLibrary.DTO;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using PharmacyLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [ApiController]
    public class TenderOfferController
    {
        private readonly TenderOfferService offerService;
        private readonly TenderOfferItemService itemService;
        private readonly IConfiguration _config;

        public TenderOfferController(DatabaseContext databaseContext, IConfiguration config)
        {
            ITenderOfferRepository offerRepository = new TenderOfferRepository(databaseContext);
            offerService = new TenderOfferService(offerRepository);
            ITenderOfferItemRepository itemRepository = new TenderOfferItemRepository(databaseContext);
            itemService = new TenderOfferItemService(itemRepository);
            _config = config;
        }

        [HttpPost]
        [Route("checkOfferItemsAvailability")]
        public bool CheckOfferItemsAvailability(List<TenderOfferItemDto> items)
        {
            return itemService.CheckQuantity(items);
        }

        [HttpGet]
        [Route("getTenderOffers")]
        public List<TenderOfferDto> GetTenderOffersWithItems()
        {
            List<TenderOfferDto> dtos = offerService.GetTenderOffersWithItems();
            return dtos;
        }

        [HttpPost]
        [Route("postTenderOffer")]
        public void PostTenderOffer(TenderOfferDto dto)
        {
            var apiKey = _config.GetValue<string>("ApiKey");
            dto.PharmacyName = _config.GetValue <string>("PharmacyName");
            
            offerService.AddTenderOffer(dto, apiKey);
        }
    }
}
