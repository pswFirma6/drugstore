using PhramacyLibrary.Model;
using PharmacyLibrary.IRepository;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace PharmacyLibrary.Services
{
    public class HospitalService
    {

        private readonly IHospitalRepository hospitalRepository;
        public HospitalService(IHospitalRepository iRepository)
        {
            hospitalRepository = iRepository;
        }

        public List<Hospital> GetAll()
        {
            return hospitalRepository.GetAll();
        }

        public void AddHospital(HospitalInfo hospital,PersonalInfo info)
        {
            String hospitalUrl = Environment.GetEnvironmentVariable("NASA_VARIJABLA") ?? hospital.Url;
            var client = new RestClient(hospitalUrl + "/registerPharmacy");
            var request = new RestRequest();
            request.AddJsonBody(info);
            var res = client.Post(request);
            
            String apiKey = res.Content;
            if(apiKey.Length == 0)
                apiKey = "jaksjdhagshjikps";
            apiKey = apiKey.Substring(1, apiKey.Length - 2);


            ConnectionInfo conInfo = new ConnectionInfo(hospital.Url, apiKey);
            Address address = new Address(hospital.HospitalAddress,hospital.HospitalCity);

            Hospital newHospital = new Hospital(hospital.HospitalName, address, conInfo);

            AddHospital(newHospital);
        }

        public void AddHospital(Hospital hospital)
        {
            hospitalRepository.Add(hospital);
            hospitalRepository.Save();
        }

        public bool CheckHospitalName(string hospital)
        {
            bool duplicate = false;
            foreach (Hospital currHospital in hospitalRepository.GetAll())
            {
                if (currHospital.HospitalName.Equals(hospital))
                {
                    duplicate = true;
                    break;
                }
            }
            return duplicate;
        }
    }
}
