using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Model;
using PharmacyLibrary.Model.DTOs;
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

        [HttpGet]
        [Route("createOffer")]
        public IActionResult AddOffer()
        {
            Offer offer = new Offer("title", "content", DateTime.Now, new DateTime());
            _context.Offers.Add(offer);
            _context.SaveChanges();
            return Ok(offer);

        }
    }
}
