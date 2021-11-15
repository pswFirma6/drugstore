using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly OfferDbContext _context;

        public OfferController(OfferDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("createOffer")]
        public IActionResult AddHospital(Offer offer)
        {
                _context.Offers.Add(new Offer(offer.Title, offer.Content, offer.DateStart, offer.DateEnd));
                _context.SaveChanges();
                return Ok();

        }
    }
}
