using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugstoreLibrary.Model
{
  public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Medicine> Medicines { get; set;}
        public DbSet<Feedback> FeedBacks { get; set;}
        public DbSet<Pharmacy> Pharmacies { get; set;}
        public DbSet<PharmacyMedicines> PharmacyMedicines { get; set; }



    }
}
