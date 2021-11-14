using PhramacyLibrary.Model;

using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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

        public List<PharmacyLibrary.Model.Pharmacy> GetAll()
        {
            List<PharmacyLibrary.Model.Pharmacy> result = new List<PharmacyLibrary.Model.Pharmacy>();
            context.Pharmacies.ToList().ForEach(pharmacy => result.Add(pharmacy));
            return result;
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
