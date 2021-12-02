﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThAmCo.Events.EventDTOs.EventTypeDTO", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventTypeDTO");
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            EmailId = "oliie_12star@gmail.com",
                            FirstName = "Ollie",
                            LastName = "Smith",
                            PhoneNumber = "07293829323"
                        },
                        new
                        {
                            CustomerId = 2,
                            EmailId = "i_amStacy20@gmail.com",
                            FirstName = "Stacy",
                            LastName = "Parks",
                            PhoneNumber = "0724679809"
                        },
                        new
                        {
                            CustomerId = 3,
                            EmailId = "andrewpool1992@gmail.com",
                            FirstName = "Andrew",
                            LastName = "Pool",
                            PhoneNumber = "07908789323"
                        },
                        new
                        {
                            CustomerId = 4,
                            EmailId = "n.Malendez200@gmail.com",
                            FirstName = "Neil",
                            LastName = "Malendez"
                        },
                        new
                        {
                            CustomerId = 5,
                            EmailId = "Jennie.non.White200@gmail.com",
                            FirstName = "Jennie",
                            LastName = "White",
                            PhoneNumber = "0766839432"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTypeId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            EventDateTime = new DateTime(2021, 2, 10, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            EventTitle = "Tannu weds mannu",
                            EventTypeId = "WED"
                        },
                        new
                        {
                            EventId = 2,
                            EventDateTime = new DateTime(2021, 4, 5, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTitle = "Web apps and services ICA disscussion",
                            EventTypeId = "MET"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.GuestBooking", b =>
                {
                    b.Property<int>("GuestBookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("GuestAttendence")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuestBookingID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EventId");

                    b.ToTable("GuestBookings");

                    b.HasData(
                        new
                        {
                            GuestBookingID = 1,
                            CustomerId = 2,
                            EventId = 2,
                            GuestAttendence = "Yes"
                        },
                        new
                        {
                            GuestBookingID = 2,
                            CustomerId = 1,
                            EventId = 1,
                            GuestAttendence = "No"
                        },
                        new
                        {
                            GuestBookingID = 3,
                            CustomerId = 1,
                            EventId = 2,
                            GuestAttendence = "Yes"
                        },
                        new
                        {
                            GuestBookingID = 4,
                            CustomerId = 5,
                            EventId = 1,
                            GuestAttendence = "Yes"
                        },
                        new
                        {
                            GuestBookingID = 5,
                            CustomerId = 3,
                            EventId = 2,
                            GuestAttendence = "No"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Staff", b =>
                {
                    b.Property<int>("Staffid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CheckAvailibility")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Staffid");

                    b.ToTable("Staff");

                    b.HasData(
                        new
                        {
                            Staffid = 1,
                            CheckAvailibility = true,
                            FirstName = "Paulo",
                            LastName = "Marks",
                            StaffType = "Waiter"
                        },
                        new
                        {
                            Staffid = 2,
                            CheckAvailibility = true,
                            FirstName = "Mary",
                            LastName = "Gibbs",
                            StaffType = "Manager"
                        },
                        new
                        {
                            Staffid = 3,
                            CheckAvailibility = true,
                            FirstName = "Kacy",
                            LastName = "Holland",
                            StaffType = "Wedding Planner"
                        },
                        new
                        {
                            Staffid = 4,
                            CheckAvailibility = false,
                            FirstName = "Arvind",
                            LastName = "Sharma",
                            StaffType = "Bartender"
                        },
                        new
                        {
                            Staffid = 5,
                            CheckAvailibility = true,
                            FirstName = "Raghav",
                            LastName = "Kuma",
                            StaffType = "Event Organiser"
                        },
                        new
                        {
                            Staffid = 6,
                            CheckAvailibility = false,
                            FirstName = "Kyle",
                            LastName = "Butler",
                            StaffType = "Photographer"
                        },
                        new
                        {
                            Staffid = 7,
                            CheckAvailibility = false,
                            FirstName = "Andy",
                            LastName = "Angels",
                            StaffType = "Caterer"
                        },
                        new
                        {
                            Staffid = 8,
                            CheckAvailibility = true,
                            FirstName = "Mandy",
                            LastName = "Green",
                            StaffType = "DJ Music Mixer"
                        },
                        new
                        {
                            Staffid = 9,
                            CheckAvailibility = true,
                            FirstName = "Sandy",
                            LastName = "Geller",
                            StaffType = "Waiter"
                        },
                        new
                        {
                            Staffid = 10,
                            CheckAvailibility = true,
                            FirstName = "Barry",
                            LastName = "Tribbiani",
                            StaffType = "Waiter"
                        },
                        new
                        {
                            Staffid = 11,
                            CheckAvailibility = true,
                            FirstName = "Penny",
                            LastName = "Parks",
                            StaffType = "Event Organiser"
                        },
                        new
                        {
                            Staffid = 12,
                            CheckAvailibility = false,
                            FirstName = "Larc",
                            LastName = "Meads",
                            StaffType = "Caterer"
                        },
                        new
                        {
                            Staffid = 13,
                            CheckAvailibility = true,
                            FirstName = "Garry",
                            LastName = "James",
                            StaffType = "Waiter"
                        },
                        new
                        {
                            Staffid = 14,
                            CheckAvailibility = true,
                            FirstName = "Kirti",
                            LastName = "Sanon",
                            StaffType = "Photographer"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.GuestBooking", b =>
                {
                    b.HasOne("ThAmCo.Events.Models.Customer", "Custs")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Models.Event", "Events")
                        .WithMany("Guests")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
