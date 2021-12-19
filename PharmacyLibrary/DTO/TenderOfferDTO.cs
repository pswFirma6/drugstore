using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.DTO
{
    public class TenderOfferDTO
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public String PharmacyName { get; set; }

        public List<TenderOfferItemDTO> TenderOfferItems { get; set; }
        public TenderOfferDTO() { }

        public TenderOfferDTO(int id, int tenderId, string pharmacyName, List<TenderOfferItemDTO> tenderOfferItems)
        {
            Id = id;
            TenderId = tenderId;
            PharmacyName = pharmacyName;
            this.TenderOfferItems = tenderOfferItems;
        }
    }
}
