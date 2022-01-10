using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ClickTime { get; set; }
        public string ApplicationName { get; set; }

    }
}
