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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Offer() { }

        public Offer(int id, string title, string content, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            Content = content;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Offer(string title, string content, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Content = content;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
