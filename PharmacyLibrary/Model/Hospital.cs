using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Hospital
    {

        [Key]
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalCity { get; set; }
        public string ApiKey { get; set; }
        public Hospital()
        {

        }

        public Hospital(string hospitalName, string hospitalAddress, string hospitalCity, string apiKey)
        {
            HospitalName = hospitalName;
            HospitalAddress = hospitalAddress;
            HospitalCity = hospitalCity;
            ApiKey = apiKey;
        }


    }
}