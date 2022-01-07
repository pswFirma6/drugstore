using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.Shared;
using PhramacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackResponse> FeedbackResponses { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TenderOffer> TenderOffers { get; set; }
        public DbSet<TenderOfferItem> TenderOfferItems { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderItem> TenderItems { get; set; }
        public DbSet<MedicineAd> MedicineAds { get; set; }

        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             string connectionString = CreateConnectionStringFromEnvironment();
                optionsBuilder.UseNpgsql(connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().OwnsOne(typeof(Address), "HospitalAddress");
            modelBuilder.Entity<Hospital>().OwnsOne(typeof(ConnectionInfo), "HospitalConnectionInfo");
            modelBuilder.Entity<Offer>().OwnsOne(typeof(DateRange), "OfferDateRange");
            modelBuilder.Entity<Offer>().OwnsOne(typeof(DateRange), "MedicineAdDateRange");
        }

        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "drugstoredb";
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "true";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";
            return $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
        }
    }
}
