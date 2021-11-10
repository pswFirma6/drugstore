﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyLibrary.Model;

namespace PharmacyLibrary.Migrations.HospitalDb
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20211108135419_Hospital6")]
    partial class Hospital6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PharmacyLibrary.Model.Hospital", b =>
                {
                    b.Property<string>("HospitalName")
                        .HasColumnType("text");

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("HospitalAddress")
                        .HasColumnType("text");

                    b.Property<string>("HospitalCity")
                        .HasColumnType("text");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("text");

                    b.HasKey("HospitalName");

                    b.ToTable("Hospitals");
                });
#pragma warning restore 612, 618
        }
    }
}
