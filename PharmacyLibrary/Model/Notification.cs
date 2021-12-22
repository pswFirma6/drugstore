using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public bool Read { get; set; }

        public Notification() { 
        
        }

        public Notification(int id, string title, string content, DateTime date, string name, bool read)
        {
            Id = id;
            Title = title;
            Content = content;
            Date = date;
            Name = name;
            Read = read;
        }

        
    }
}
