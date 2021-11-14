
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


namespace FakePharmacy.Controller
{
    //[Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public HospitalController(HospitalDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("registerHospital")]
        public IActionResult AddHospital(Hospital hospital)
        {
            if (checkHospitalName(hospital))
            {

                return BadRequest();
            }
            else
            {
                string apiKey = generateApiKey();
                _context.Hospitals.Add(new Hospital(hospital.HospitalName, hospital.HospitalAddress, hospital.HospitalCity, hospital.PharmacyName, apiKey));
                _context.SaveChanges();
                return Ok();
            }

        }

        private bool checkHospitalName(Hospital hospital)
        {
            List<Hospital> result = new List<Hospital>();
            _context.Hospitals.ToList().ForEach(hospital => result.Add(hospital));
            bool duplicate = false;
            foreach (Hospital currHospital in result)
            {
                if (currHospital.HospitalName.Equals(hospital.HospitalName))
                {
                    duplicate = true;
                    break;
                }
            }
            return duplicate;
        }

        [HttpGet]
        [Route("hospitals")]
        public IActionResult GetAllRegisteredHospitals()
        {
            //kako se pristupa listi svih
            List<Hospital> result = new List<Hospital>();
            _context.Hospitals.ToList().ForEach
                (hospital => result.Add(hospital));

            return Ok(result);
        }

        private String generateApiKey()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 16;
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }

}