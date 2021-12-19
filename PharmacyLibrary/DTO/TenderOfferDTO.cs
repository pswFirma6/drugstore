using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.DTO
{
    public class TenderOfferDto
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public String PharmacyName { get; set; }

        public List<TenderOfferItemDto> TenderOfferItems { get; set; }
        public TenderOfferDto() { }

        public TenderOfferDto(int id, int tenderId, string pharmacyName, List<TenderOfferItemDto> tenderOfferItems)
        {
            Id = id;
            TenderId = tenderId;
            PharmacyName = pharmacyName;
            this.TenderOfferItems = tenderOfferItems;
        }
    }
}
