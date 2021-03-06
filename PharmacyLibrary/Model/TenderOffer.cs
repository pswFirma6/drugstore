using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class TenderOffer
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public String PharmacyName { get; set; }
        public bool isWinner { get; set; } = false;
        public DateTime CreationDate { get; set; }

        public TenderOffer() { }
        public TenderOffer(int id, int tenderId, string pharmacyName, DateTime creationDate)
        {
            Id = id;
            TenderId = tenderId;
            PharmacyName = pharmacyName;
            CreationDate = creationDate;
        }
    }
}
