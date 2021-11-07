using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class FeedbackResponse
    {
        public int Id { get; set; }
        [Key]
        public int FeedbackId { get; set; }
        public string Content { get; set; }
        public string FeedbackResponseDate { get; set; }
    }
}
