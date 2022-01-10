using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Shared
{
    public class DateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateRange() { }

        public DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
