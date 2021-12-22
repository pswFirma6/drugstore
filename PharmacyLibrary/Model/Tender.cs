using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Tender
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string HospitalApiKey { get; set; }
        public int HospitalTenderId { get; set; }

        public Tender() { }

        public Tender(int id, DateTime creationDate, DateTime startDate, DateTime endDate, string hospitalApiKey, int hospitalTenderId)
        {
            Id = id;
            CreationDate = creationDate;
            StartDate = startDate;
            EndDate = endDate;
            HospitalApiKey = hospitalApiKey;
            HospitalTenderId = hospitalTenderId;
        }
    }
}
