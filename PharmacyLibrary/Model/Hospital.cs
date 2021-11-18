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
        public string PharmacyName { get; set; }
        public string ApiKey { get; set; }

        public Hospital(string hospitalName, string hospitalAddress, string hospitalCity, string pharmacyName, string apiKey)
        {
            HospitalName = hospitalName;
            HospitalAddress = hospitalAddress;
            HospitalCity = hospitalCity;
            PharmacyName = pharmacyName;
            ApiKey = apiKey;
        }

        public Hospital()
        {

        }

    }
}