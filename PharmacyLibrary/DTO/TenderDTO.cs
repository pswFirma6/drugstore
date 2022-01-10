using System;
using System.Collections.Generic;
using System.Text;
using PharmacyLibrary.DTO;

namespace PharmacyLibrary.DTO
{
    public class TenderDto
    {
        public int Id { get; set; }
        public string CreationDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<TenderItemDto> TenderItems { get; set; }
        public string HospitalApiKey { get; set; }
        public int HospitalTenderId { get; set; }

        public bool Opened { get; set; }

        public TenderDto() { }

        public TenderDto(int id, string creationDate, string startDate, string endDate, List<TenderItemDto> tenderItems, string hospitalApiKey, int hospitalTnederId)
        {
            Id = id;
            CreationDate = creationDate;
            StartDate = startDate;
            EndDate = endDate;
            TenderItems = tenderItems;
            HospitalApiKey = hospitalApiKey;
            HospitalTenderId = hospitalTnederId;
        }
    }
}
