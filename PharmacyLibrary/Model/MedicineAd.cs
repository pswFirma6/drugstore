using PharmacyLibrary.Shared;
using PhramacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{

    public class MedicineAd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateRange dateRange { get; }
        public Medicine Medicine { get; set; }

        public MedicineAd() { }

        public MedicineAd(int id, string title, string description, DateRange dateRange, Medicine medicine)
        {
            Id = id;
            Title = title;
            Description = description;
            this.dateRange = dateRange;
            Medicine = medicine;
        }
    }
}
