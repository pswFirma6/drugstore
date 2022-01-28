﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyLibrary.Model;

namespace PharmacyLibrary.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220126150800_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PharmacyLibrary.Model.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("FeedbackDate")
                        .HasColumnType("text");

                    b.Property<string>("HospitalName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.FeedbackResponse", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("FeedbackResponseDate")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("FeedbackId");

                    b.ToTable("FeedbackResponses");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HospitalName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.MedicineAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.ToTable("MedicineAds");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Tender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("HospitalApiKey")
                        .HasColumnType("text");

                    b.Property<int>("HospitalTenderId")
                        .HasColumnType("integer");

                    b.Property<bool>("Opened")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Tenders");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.TenderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("TenderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenderId");

                    b.ToTable("TenderItems");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.TenderOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("boolean");

                    b.Property<int>("TenderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TenderOffers");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.TenderOfferItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OfferId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("TenderOfferItems");
                });

            modelBuilder.Entity("PhramacyLibrary.Model.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Intensity")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsPrescribed")
                        .HasColumnType("boolean");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

                    b.Property<int>("MedicineType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("RecommendedDose")
                        .HasColumnType("text");

                    b.Property<string>("SideEffects")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Hospital", b =>
                {
                    b.OwnsOne("PharmacyLibrary.Model.Address", "HospitalAddress", b1 =>
                        {
                            b1.Property<int>("HospitalId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .HasColumnType("text");

                            b1.HasKey("HospitalId");

                            b1.ToTable("Hospitals");

                            b1.WithOwner()
                                .HasForeignKey("HospitalId");
                        });

                    b.OwnsOne("PharmacyLibrary.Model.ConnectionInfo", "HospitalConnectionInfo", b1 =>
                        {
                            b1.Property<int>("HospitalId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("ApiKey")
                                .HasColumnType("text");

                            b1.Property<string>("Url")
                                .HasColumnType("text");

                            b1.HasKey("HospitalId");

                            b1.ToTable("Hospitals");

                            b1.WithOwner()
                                .HasForeignKey("HospitalId");
                        });

                    b.Navigation("HospitalAddress");

                    b.Navigation("HospitalConnectionInfo");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.MedicineAd", b =>
                {
                    b.HasOne("PhramacyLibrary.Model.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId");

                    b.OwnsOne("PharmacyLibrary.Shared.DateRange", "dateRange", b1 =>
                        {
                            b1.Property<int>("MedicineAdId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("MedicineAdId");

                            b1.ToTable("MedicineAds");

                            b1.WithOwner()
                                .HasForeignKey("MedicineAdId");
                        });

                    b.Navigation("dateRange");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Offer", b =>
                {
                    b.OwnsOne("PharmacyLibrary.Shared.DateRange", "OfferDateRange", b1 =>
                        {
                            b1.Property<int>("OfferId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("OfferId");

                            b1.ToTable("Offers");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");
                        });

                    b.Navigation("OfferDateRange");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Tender", b =>
                {
                    b.OwnsOne("PharmacyLibrary.Shared.DateRange", "TenderDateRange", b1 =>
                        {
                            b1.Property<int>("TenderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tenders");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });

                    b.Navigation("TenderDateRange");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.TenderItem", b =>
                {
                    b.HasOne("PharmacyLibrary.Model.Tender", "Tender")
                        .WithMany("TenderItems")
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tender");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.TenderOfferItem", b =>
                {
                    b.HasOne("PharmacyLibrary.Model.TenderOffer", "Offer")
                        .WithMany("OfferItems")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.Tender", b =>
                {
                    b.Navigation("TenderItems");
                });

            modelBuilder.Entity("PharmacyLibrary.Model.TenderOffer", b =>
                {
                    b.Navigation("OfferItems");
                });
#pragma warning restore 612, 618
        }
    }
}