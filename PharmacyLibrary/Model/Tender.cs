using PharmacyLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Tender
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateRange TenderDateRange { get; set; }
        public string HospitalApiKey { get; set; }
        public int HospitalTenderId { get; set; }
        public bool Opened { get; set; } = true;

        private readonly List<TenderItem> _tenderItems = new List<TenderItem>();
        public IReadOnlyCollection<TenderItem> TenderItems => _tenderItems;

        public Tender() { }

        public Tender(int id, DateTime creationDate,  DateRange dateRange, string hospitalApiKey, int hospitalTenderId)
        {
            Id = id;
            CreationDate = creationDate;
            TenderDateRange = dateRange;
            HospitalApiKey = hospitalApiKey;
            HospitalTenderId = hospitalTenderId;
        }

        public void AddTenderItem(Tender tender, string name, int quantity)
        {
            var tenderItem = new TenderItem(tender, name, quantity);
            _tenderItems.Add(tenderItem);
        }
    }
}
