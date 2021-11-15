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
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public Offer(string title, string content, DateTime dateStart, DateTime dateEnd)
        {
            Title = title;
            Content = content;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }
    }
}
