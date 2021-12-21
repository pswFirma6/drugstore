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
        private readonly TenderService tenderService;

        public TenderController(DatabaseContext databaseContext, IConfiguration config)
        {
            ITenderOfferRepository tenderOfferRepository = new TenderOfferRepository(databaseContext);
            ITenderRepository tenderRepository = new TenderRepository(databaseContext);
            tenderService = new TenderService(tenderRepository);
        }

        [HttpGet]
        [Route("getTenders")]
        public List<TenderDto> GetTenders()
        {
            return tenderService.GetTendersWithItems();
        }
    }
}
