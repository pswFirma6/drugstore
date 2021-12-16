using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Services
{
    public class HospitalService
    {
        private const int APIKEY_LENGTH = 16;

        private readonly IHospitalRepository hospitalRepository;
        private readonly EventService eventService;
        public HospitalService(IHospitalRepository iRepository)
        {
            hospitalRepository = iRepository;
        }

        public List<Hospital> GetAll()
        {
            return hospitalRepository.GetAll();
        }

        public void AddHospital(Hospital hospital)
        {
            hospital.ApiKey = GenerateApiKey();
            hospitalRepository.Add(hospital);
            hospitalRepository.Save();
            Event e = new Event();
            e.Id = eventService.GetAll().Count + 1;
            e.ApplicationName = "AppForPharmacy";
            e.ClickTime = DateTime.Now;
            e.Name = "Register hospital";
            eventService.Add(e);
        }

        public bool CheckHospitalName(Hospital hospital)
        {
            bool duplicate = false;
            foreach (Hospital currHospital in hospitalRepository.GetAll())
            {
                if (currHospital.HospitalName.Equals(hospital.HospitalName))
                {
                    duplicate = true;
                    break;
                }
            }
            return duplicate;
        }

        private String GenerateApiKey()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < APIKEY_LENGTH; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
