
using Pharmacy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyLibrary.Services;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Repository;

namespace FakePharmacy.Controller
{
    //[Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private HospitalService service;
        private IHospitalRepository hospitalRepository;

        public HospitalController(DatabaseContext dcontext)
        {
            hospitalRepository = new HospitalRepository(dcontext);
            service = new HospitalService(hospitalRepository);
        }

        [HttpPost]
        [Route("registerHospital")]
        public IActionResult AddHospital(Hospital hospital)
        {
            if (service.CheckHospitalName(hospital))
            {
                return BadRequest();
            }
            else
            {
                service.AddHospital(hospital);
                return Ok();
            }
        }

        [HttpGet]
        [Route("hospitals")]
        public IActionResult GetAllRegisteredHospitals()
        {
            return Ok(service.GetAll());
        }

    }

}