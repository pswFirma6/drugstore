using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.DTO
{
    public class OfferDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public OfferDTO() { }

        public OfferDTO(int id, string title, string content, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Content = content;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
