using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string ApiKey { get; set; }

        public Pharmacy () { }

        public Pharmacy(int id, string name, string address, string apiKey)
        {
            Id = id;
            Name = name;
            Address = address;
            ApiKey = apiKey;
        }
    }
}
