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

            modelBuilder.Entity("ThAmCo.Events.EventDTOs.VenueDTO", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<double>("CostPerHour")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.HasIndex("EventId");

                    b.ToTable("VenueDb");
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

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CostPerHour")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReservationId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            EventDateTime = new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTitle = "Jammie Weds Quinn ",
                            EventTypeId = "WED",
                            IsDeleted = false
                        },
                        new
                        {
                            EventId = 2,
                            EventDateTime = new DateTime(2021, 11, 5, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTitle = "Web apps ICA Final Report Discussion",
                            EventTypeId = "MET",
                            IsDeleted = false
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

                    b.Property<bool>("isFirstAider")
                        .HasColumnType("bit");

                    b.HasKey("Staffid");

                    b.ToTable("Staff");

                    b.HasData(
                        new
                        {
                            Staffid = 1,
                            CheckAvailibility = false,
                            FirstName = "Paulo",
                            LastName = "Marks",
                            StaffType = "Waiter",
                            isFirstAider = true
                        },
                        new
                        {
                            Staffid = 2,
                            CheckAvailibility = false,
                            FirstName = "Mary",
                            LastName = "Gibbs",
                            StaffType = "Manager",
                            isFirstAider = true
                        },
                        new
                        {
                            Staffid = 3,
                            CheckAvailibility = false,
                            FirstName = "Kacy",
                            LastName = "Holland",
                            StaffType = "Wedding Planner",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 4,
                            CheckAvailibility = false,
                            FirstName = "Arvind",
                            LastName = "Sharma",
                            StaffType = "Bartender",
                            isFirstAider = true
                        },
                        new
                        {
                            Staffid = 5,
                            CheckAvailibility = true,
                            FirstName = "Raghav",
                            LastName = "Kuma",
                            StaffType = "Event Organiser",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 6,
                            CheckAvailibility = true,
                            FirstName = "Kyle",
                            LastName = "Butler",
                            StaffType = "Photographer",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 7,
                            CheckAvailibility = false,
                            FirstName = "Andy",
                            LastName = "Angels",
                            StaffType = "Caterer",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 8,
                            CheckAvailibility = false,
                            FirstName = "Mandy",
                            LastName = "Green",
                            StaffType = "DJ Music Mixer",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 9,
                            CheckAvailibility = true,
                            FirstName = "Sandy",
                            LastName = "Geller",
                            StaffType = "Waiter",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 10,
                            CheckAvailibility = true,
                            FirstName = "Barry",
                            LastName = "Tribbiani",
                            StaffType = "Waiter",
                            isFirstAider = true
                        },
                        new
                        {
                            Staffid = 11,
                            CheckAvailibility = true,
                            FirstName = "Penny",
                            LastName = "Parks",
                            StaffType = "Event Organiser",
                            isFirstAider = true
                        },
                        new
                        {
                            Staffid = 12,
                            CheckAvailibility = false,
                            FirstName = "Larc",
                            LastName = "Meads",
                            StaffType = "Caterer",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 13,
                            CheckAvailibility = true,
                            FirstName = "Garry",
                            LastName = "James",
                            StaffType = "Waiter",
                            isFirstAider = false
                        },
                        new
                        {
                            Staffid = 14,
                            CheckAvailibility = false,
                            FirstName = "Kirti",
                            LastName = "Sanon",
                            StaffType = "Photographer",
                            isFirstAider = true
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Models.Staffing", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "StaffId");

                    b.HasIndex("StaffId");

                    b.ToTable("Staffings");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            StaffId = 1
                        },
                        new
                        {
                            EventId = 1,
                            StaffId = 2
                        },
                        new
                        {
                            EventId = 1,
                            StaffId = 3
                        },
                        new
                        {
                            EventId = 1,
                            StaffId = 4
                        },
                        new
                        {
                            EventId = 2,
                            StaffId = 7
                        },
                        new
                        {
                            EventId = 2,
                            StaffId = 8
                        },
                        new
                        {
                            EventId = 2,
                            StaffId = 12
                        },
                        new
                        {
                            EventId = 2,
                            StaffId = 14
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.EventDTOs.VenueDTO", b =>
                {
                    b.HasOne("ThAmCo.Events.Models.Event", null)
                        .WithMany("EventVenues")
                        .HasForeignKey("EventId");
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

            modelBuilder.Entity("ThAmCo.Events.Models.Staffing", b =>
                {
                    b.HasOne("ThAmCo.Events.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
