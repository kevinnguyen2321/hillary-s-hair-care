﻿// <auto-generated />
using System;
using HillaryHairCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillaryHairCare.Migrations
{
    [DbContext(typeof(HillaryHairCareDbContext))]
    partial class HillaryHairCareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HillaryHairCare.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Canceled")
                        .HasColumnType("boolean");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Canceled = false,
                            CustomerId = 1,
                            ScheduledTime = new DateTime(2024, 12, 5, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 2
                        },
                        new
                        {
                            Id = 2,
                            Canceled = false,
                            CustomerId = 2,
                            ScheduledTime = new DateTime(2024, 12, 5, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 3
                        },
                        new
                        {
                            Id = 3,
                            Canceled = true,
                            CustomerId = 3,
                            ScheduledTime = new DateTime(2024, 12, 6, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 1
                        },
                        new
                        {
                            Id = 4,
                            Canceled = false,
                            CustomerId = 4,
                            ScheduledTime = new DateTime(2024, 12, 7, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 5
                        },
                        new
                        {
                            Id = 5,
                            Canceled = true,
                            CustomerId = 5,
                            ScheduledTime = new DateTime(2024, 12, 8, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            StylistId = 4
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.AppointmentService", b =>
                {
                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("AppointmentId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            ServiceId = 1,
                            Id = 1
                        },
                        new
                        {
                            AppointmentId = 1,
                            ServiceId = 3,
                            Id = 2
                        },
                        new
                        {
                            AppointmentId = 2,
                            ServiceId = 2,
                            Id = 3
                        },
                        new
                        {
                            AppointmentId = 3,
                            ServiceId = 1,
                            Id = 4
                        },
                        new
                        {
                            AppointmentId = 4,
                            ServiceId = 4,
                            Id = 5
                        },
                        new
                        {
                            AppointmentId = 5,
                            ServiceId = 1,
                            Id = 6
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alice Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bob Smith"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Charlie Davis"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Diana Roberts"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Edward Martinez"
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Haircut",
                            Price = 25.00m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hair Coloring",
                            Price = 75.00m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Beard Trim",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Blow Dry and Style",
                            Price = 40.00m
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Sophia Anderson"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Liam Thompson"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Olivia Brown"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = false,
                            Name = "Noah Wilson"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Name = "Emma Taylor"
                        });
                });

            modelBuilder.Entity("HillaryHairCare.Models.Appointment", b =>
                {
                    b.HasOne("HillaryHairCare.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillaryHairCare.Models.Stylist", "Stylist")
                        .WithMany()
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("HillaryHairCare.Models.AppointmentService", b =>
                {
                    b.HasOne("HillaryHairCare.Models.Appointment", "Appointment")
                        .WithMany("AppointmentServices")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillaryHairCare.Models.Service", "Service")
                        .WithMany("AppointmentServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HillaryHairCare.Models.Appointment", b =>
                {
                    b.Navigation("AppointmentServices");
                });

            modelBuilder.Entity("HillaryHairCare.Models.Service", b =>
                {
                    b.Navigation("AppointmentServices");
                });
#pragma warning restore 612, 618
        }
    }
}
