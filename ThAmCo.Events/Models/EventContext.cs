using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.Models;
using ThAmCo.Events.EventDTOs;

namespace ThAmCo.Events.Models
{
    public class EventContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Event> Event { get; set; }
         public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Staffing> Staffings { get; set; }
        public EventContext(DbContextOptions<EventContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //RelationShips

            builder.Entity<GuestBooking>()
                .HasOne(m => m.Custs) 
                .WithMany()
                .HasForeignKey(m => m.CustomerId);

            builder.Entity<GuestBooking>()
               .HasOne(m => m.Events)
               .WithMany(g=> g.Guests)  
               .HasForeignKey(m => m.EventId);

            // Composite key
            builder.Entity<Staffing>()
                .HasKey(a => new { a.EventId, a.StaffId });

            builder.Entity<Staffing>()
                 .HasOne(m => m.Event)
                 .WithMany()
                 .HasForeignKey(m => m.EventId);

            builder.Entity<Staffing>()
               .HasOne(n => n.Staff)
               .WithMany()
               .HasForeignKey(n => n.StaffId);

            // seed data

            builder.Entity<Customer>()
                .HasData(
                new Customer { CustomerId = 1, FirstName = "Ollie" , LastName = "Smith" , PhoneNumber = "07293829323" , EmailId = "oliie_12star@gmail.com"  },
                new Customer { CustomerId = 2, FirstName = "Stacy", LastName = "Parks", PhoneNumber = "0724679809", EmailId = "i_amStacy20@gmail.com" },
                new Customer { CustomerId = 3, FirstName = "Andrew", LastName = "Pool", PhoneNumber = "07908789323", EmailId = "andrewpool1992@gmail.com" },
                new Customer { CustomerId = 4, FirstName = "Neil", LastName = "Malendez", EmailId = "n.Malendez200@gmail.com" },
                new Customer { CustomerId = 5, FirstName = "Jennie", LastName = "White", PhoneNumber = "0766839432", EmailId = "Jennie.non.White200@gmail.com" }
                );

            builder.Entity<Staff>()
                .HasData(
                new Staff {  Staffid = 1, FirstName ="Paulo" , LastName = "Marks", StaffType = "Waiter" , CheckAvailibility=true},
                new Staff { Staffid = 2, FirstName = "Mary", LastName = "Gibbs", StaffType = "Manager", CheckAvailibility = true },
                new Staff { Staffid = 3, FirstName = "Kacy", LastName = "Holland", StaffType = "Wedding Planner", CheckAvailibility = true },
                new Staff { Staffid = 4, FirstName = "Arvind", LastName = "Sharma", StaffType = "Bartender", CheckAvailibility = false },
                new Staff { Staffid = 5, FirstName = "Raghav", LastName = "Kuma", StaffType = "Event Organiser", CheckAvailibility = true },
                new Staff { Staffid = 6, FirstName = "Kyle", LastName = "Butler", StaffType = "Photographer", CheckAvailibility = false },
                new Staff { Staffid = 7, FirstName = "Andy", LastName = "Angels", StaffType = "Caterer", CheckAvailibility = false },
                new Staff { Staffid = 8, FirstName = "Mandy", LastName = "Green", StaffType = "DJ Music Mixer", CheckAvailibility = true },
                new Staff { Staffid = 9, FirstName = "Sandy", LastName = "Geller", StaffType = "Waiter", CheckAvailibility = true },
                new Staff { Staffid = 10, FirstName = "Barry", LastName = "Tribbiani", StaffType = "Waiter", CheckAvailibility = true },
                new Staff { Staffid = 11, FirstName = "Penny", LastName = "Parks", StaffType = "Event Organiser", CheckAvailibility = true },
                new Staff { Staffid = 12, FirstName = "Larc", LastName = "Meads", StaffType = "Caterer", CheckAvailibility = false },
                new Staff { Staffid = 13, FirstName = "Garry", LastName = "James", StaffType = "Waiter", CheckAvailibility = true },
                new Staff { Staffid = 14, FirstName = "Kirti", LastName = "Sanon", StaffType = "Photographer", CheckAvailibility = true }
                );

            builder.Entity<Event>()
                .HasData(
                new Event { EventId = 1, EventTitle = "Tannu weds mannu",EventDateTime = new DateTime(2021, 2, 10, 9,30,0),EventTypeId = "WED"},
                new Event { EventId = 2, EventTitle = "Web apps and services ICA disscussion", EventDateTime = new DateTime(2021, 4, 5, 11, 00, 0), EventTypeId = "MET" }
                );

            builder.Entity<GuestBooking>()
                .HasData(
                new GuestBooking {  GuestBookingID = 1, CustomerId = 2, EventId = 2 , GuestAttendence = "Yes"},
                new GuestBooking { GuestBookingID = 2, CustomerId = 1, EventId = 1, GuestAttendence = "No"},
                new GuestBooking { GuestBookingID = 3, CustomerId = 1, EventId = 2, GuestAttendence = "Yes"},
                new GuestBooking { GuestBookingID = 4, CustomerId = 5, EventId = 1, GuestAttendence = "Yes"},
                new GuestBooking {  GuestBookingID = 5, CustomerId = 3, EventId = 2 , GuestAttendence = "No"}
                );

        }
        public DbSet<ThAmCo.Events.EventDTOs.EventTypeDTO> EventTypeDTO { get; set; }
       
        
    }
}
