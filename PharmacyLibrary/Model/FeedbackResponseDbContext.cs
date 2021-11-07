using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class FeedbackResponseDbContext : DbContext
    {
        public FeedbackResponseDbContext(DbContextOptions<FeedbackResponseDbContext> options) : base(options)
        {

        }
        public DbSet<FeedbackResponse> FeedbackResponses { get; set; }
    }
}
