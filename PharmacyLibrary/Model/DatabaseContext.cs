using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.Shared;
using PhramacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.FileProviders;
using System.Text;
using Microsoft.Extensions.Configuration;

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
        }

        private  string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "drugstoredb";
            var user = GetSecretOrEnvVar("db_user") ?? "root";
            var password = GetSecretOrEnvVar("db_pass") ?? "root";
            var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "true";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";
            return $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
        }

        private string GetSecretOrEnvVar(string key)
        {
            const string DOCKER_SECRET_PATH = "/run/secrets/";
            if (Directory.Exists(DOCKER_SECRET_PATH))
            {
                IFileProvider provider = new PhysicalFileProvider(DOCKER_SECRET_PATH);
                IFileInfo fileInfo = provider.GetFileInfo(key);
                if (fileInfo.Exists)
                {
                    using (var stream = fileInfo.CreateReadStream())
                    using (var streamReader = new StreamReader(stream))
                    {
                        String retVal = streamReader.ReadToEnd();
                        Console.WriteLine(retVal);
                        return retVal;
                    }
                }
            }

            return null;
        }
    }
}
