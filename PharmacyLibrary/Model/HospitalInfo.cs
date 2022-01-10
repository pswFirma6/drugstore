using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class HospitalInfo
    {
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalCity { get; set; }
        public string Url { get; set; }
        public HospitalInfo() { }

        public HospitalInfo(string hospitalName, string hospitalAddress, string hospitalCity, string url)
        {
            HospitalName = hospitalName;
            HospitalAddress = hospitalAddress;
            HospitalCity = hospitalCity;
            Url = url;
        }
    }
}
