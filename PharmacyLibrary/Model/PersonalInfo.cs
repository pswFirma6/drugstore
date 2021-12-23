using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class PersonalInfo
    {
        public string PharmacyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ApiKey { get; set; }
        public string Fileprotocol { get; set; }
        public string Url { get; set; }

        public PersonalInfo(string pharmacyName, string street, string city, string apiKey, string fileprotocol, string url)
        {
            PharmacyName = pharmacyName;
            Street = street;
            City = city;
            ApiKey = apiKey;
            Fileprotocol = fileprotocol;
            Url = url;
        }

        public PersonalInfo()
        {
        }
    }
}
