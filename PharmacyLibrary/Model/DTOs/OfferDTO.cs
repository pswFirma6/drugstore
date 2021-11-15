using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model.DTOs
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public OfferDTO(string title, string content, string startDate, string endDate)
        {
            Title = title;
            Content = content;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
