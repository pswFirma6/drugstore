using PhramacyLibrary.Model;

using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PharmacyLibrary.Services;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Repository;

namespace Pharmacy.Controllers
{
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private PharmacyService service;
        private IPharmacyRepository pharmacyRepository;

        public PharmacyController(DatabaseContext context)
        {
            pharmacyRepository = new PharmacyRepository(context);
            service = new PharmacyService(pharmacyRepository);
        }

        [HttpGet]
        [Route("pharmacyNames")]
        public IActionResult GetPharmacyNames()
        {        
            return Ok(service.GetPharmacyNames());
        }
    }
}
