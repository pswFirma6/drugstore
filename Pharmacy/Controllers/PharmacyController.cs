using DrugstoreLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Interfaces;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{

    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly PharmacyDbContext context;

        public PharmacyController(PharmacyDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("pharmacyNames")]
        public IActionResult GetPharmacyNames()
        {
            List<string> result = new List<string>();
            context.Pharmacies.ToList().ForEach(pharmacy => result.Add(pharmacy.Name));
            return Ok(result);
        }
    }
}
