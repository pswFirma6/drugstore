using Microsoft.AspNetCore.Mvc;
using Pharmacy.DTO;
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
    public class OfferController : ControllerBase
    {
        private OfferService service;
        private IOfferRepository repository;

        public OfferController(DatabaseContext dcontext)
        {
            repository = new OfferRepository(dcontext);
            service = new OfferService(repository);
        }

        [HttpPost]
        [Route("addOffer")]
        public IActionResult AddOffer(OfferDTO offer)
        {
            Offer newOffer = new Offer { Title = offer.Title, Content = offer.Content, OfferDateRange = new PharmacyLibrary.Shared.DateRange(offer.StartDate,offer.EndDate) };
            service.AddOffer(newOffer);
            service.SendOffer(newOffer);
            return Ok(newOffer);
        }

        [HttpGet]
        [Route("getOffers")]
        public List<Offer> GetOffers()
        {
            return service.GetOffers();
        }
    }
}
