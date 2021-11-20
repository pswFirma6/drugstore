﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FeedbackDate { get; set; }
        public string HospitalName { get; set; }
    }
}
