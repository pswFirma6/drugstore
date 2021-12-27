
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
using Microsoft.Extensions.Configuration;

namespace FakePharmacy.Controller
{
    //[Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private HospitalService service;
        private IHospitalRepository hospitalRepository;
        private readonly IConfiguration _config;

        public HospitalController(DatabaseContext dcontext, IConfiguration config)
        {
            hospitalRepository = new HospitalRepository(dcontext);
            service = new HospitalService(hospitalRepository);
            _config = config;
        }

        [HttpPost]
        [Route("registerHospital")]
        public IActionResult AddHospital(HospitalInfo hospitalInfo)
        {
            if (service.CheckHospitalName(hospitalInfo.HospitalName))
            {
                return BadRequest();
            }
            else
            {   
                string pharmacyName = _config.GetValue<string>("Name");
                string street = _config.GetValue<string>("Street").ToString();
                string city = _config.GetValue<string>("City").ToString();
                string apiKey = _config.GetValue<string>("ApiKey").ToString();
                string fileprotocol = _config.GetValue<string>("FileProtocol").ToString();
                string url = _config.GetValue<string>("Url").ToString();

                service.AddHospital(hospitalInfo, new PersonalInfo(pharmacyName,street,city,apiKey,fileprotocol,url));
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