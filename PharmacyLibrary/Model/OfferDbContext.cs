using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PharmacyLibrary.Model
{
    public class OfferDbContext : DbContext
    {
        public OfferDbContext(DbContextOptions<OfferDbContext> options) : base(options)
        {

        }

        public DbSet<Offer> Offers { get; set; }
    }
}
