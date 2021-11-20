using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddOffer(Offer offer)
        {
            Offer newOffer = new Offer { Title = offer.Title, Content = offer.Content, StartDate = offer.StartDate, EndDate = offer.EndDate };
            service.AddOffer(newOffer);
            return Ok();
        }

        [HttpGet]
        [Route("getOffers")]
        public List<Offer> GetOffers()
        {
            return service.GetOffers();
        }
    }
}
