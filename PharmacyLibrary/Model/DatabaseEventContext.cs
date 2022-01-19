using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class DatabaseEventContext:DbContext
    {
        public DatabaseEventContext()
        {

        }
        public DatabaseEventContext(DbContextOptions<DatabaseEventContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = CreateConnectionStringFromEnvironment();
                optionsBuilder.UseNpgsql(connectionString);
            }

        }
        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "events_db";
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "true";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";
            return $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
        }

    }
}
