using PharmacyLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateRange OfferDateRange { get; set; }

        public Offer() { }

        public Offer(int id, string title, string content, DateRange offerDateRange)
        {
            Id = id;
            Title = title;
            Content = content;
            OfferDateRange = offerDateRange;
        }

        public Offer(string title, string content, DateRange offerDateRange)
        {
            Title = title;
            Content = content;
            OfferDateRange = offerDateRange;
        }
    }
}
