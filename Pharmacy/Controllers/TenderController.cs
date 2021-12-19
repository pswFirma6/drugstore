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
    public class TenderController
    {
        private ITenderOfferRepository tenderOfferRepository;
        private TenderOfferService tenderOfferService;
        private readonly IConfiguration _config;

        public TenderController(DatabaseContext databaseContext, IConfiguration config)
        {
            tenderOfferRepository = new TenderOfferRepository(databaseContext);
            tenderOfferService = new TenderOfferService(tenderOfferRepository);
            _config = config;
        }

        [HttpPost]
        [Route("postTenderOffer")]
        public void PostTenderOffer(TenderOfferDto dto)
        {
            var apiKey = _config.GetValue<string>("ApiKey");
            tenderOfferService.AddTenderOffer(dto, apiKey);
        }
    }
}
