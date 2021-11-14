using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {

        }

        public DbSet<Pharmacy> Pharmacies { get; set; }

    }
}