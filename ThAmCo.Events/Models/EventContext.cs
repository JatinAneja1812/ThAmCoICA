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
        // Context Models
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Staffing> Staffings { get; set; }
        public DbSet<VenueDTO> VenueDb { get; set; }

        // DTOS
        public DbSet<ThAmCo.Events.EventDTOs.EventTypeDTO> EventTypeDTO { get; set; }
        public DbSet<ThAmCo.Events.EventDTOs.FoodBookingDTO> FoodBookingDTO { get; set; }
        public DbSet<ThAmCo.Events.EventDTOs.MenusDTO> MenusDTO { get; set; }
        public DbSet<ThAmCo.Events.EventDTOs.FoodItemDTO> FoodItemDTO { get; set; }
        public DbSet<ThAmCo.Events.EventDTOs.MenusDTO> MenuFoodItems { get; set; }

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

            // from the api
            builder.Entity<MenuFoodItemsDTO>()
                .HasKey(a => new { a.MenuId, a.FoodItemId });

            builder.Entity<MenuFoodItemsDTO>()
                 .HasOne(m => m.Menu)
                 .WithMany()
                 .HasForeignKey(m => m.MenuId);

            builder.Entity<MenuFoodItemsDTO>()
               .HasOne(n => n.FoodItem)
               .WithMany()
               .HasForeignKey(n => n.FoodItemId);

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
                new Staff { Staffid = 1, FirstName ="Paulo" , LastName = "Marks", StaffType = "Waiter" , CheckAvailibility= false, isFirstAider= true },
                new Staff { Staffid = 2, FirstName = "Mary", LastName = "Gibbs", StaffType = "Manager", CheckAvailibility = false, isFirstAider = true },
                new Staff { Staffid = 3, FirstName = "Kacy", LastName = "Holland", StaffType = "Wedding Planner", CheckAvailibility = false, isFirstAider = false },
                new Staff { Staffid = 4, FirstName = "Arvind", LastName = "Sharma", StaffType = "Bartender", CheckAvailibility = false, isFirstAider = true },
                new Staff { Staffid = 5, FirstName = "Raghav", LastName = "Kuma", StaffType = "Event Organiser", CheckAvailibility = true, isFirstAider = false },
                new Staff { Staffid = 6, FirstName = "Kyle", LastName = "Butler", StaffType = "Photographer", CheckAvailibility = true, isFirstAider = false },
                new Staff { Staffid = 7, FirstName = "Andy", LastName = "Angels", StaffType = "Caterer", CheckAvailibility = false, isFirstAider = false },
                new Staff { Staffid = 8, FirstName = "Mandy", LastName = "Green", StaffType = "DJ Music Mixer", CheckAvailibility = false, isFirstAider = false },
                new Staff { Staffid = 9, FirstName = "Sandy", LastName = "Geller", StaffType = "Waiter", CheckAvailibility = true, isFirstAider = false },
                new Staff { Staffid = 10, FirstName = "Barry", LastName = "Tribbiani", StaffType = "Waiter", CheckAvailibility = true, isFirstAider = true },
                new Staff { Staffid = 11, FirstName = "Penny", LastName = "Parks", StaffType = "Event Organiser", CheckAvailibility = true, isFirstAider = true },
                new Staff { Staffid = 12, FirstName = "Larc", LastName = "Meads", StaffType = "Caterer", CheckAvailibility = false, isFirstAider = false },
                new Staff { Staffid = 13, FirstName = "Garry", LastName = "James", StaffType = "Waiter", CheckAvailibility = true, isFirstAider = false },
                new Staff { Staffid = 14, FirstName = "Kirti", LastName = "Sanon", StaffType = "Photographer", CheckAvailibility = false, isFirstAider = true },
                new Staff { Staffid = 15, FirstName = "Jason", LastName = "Millar", StaffType = "Manager", CheckAvailibility = true, isFirstAider = true },
                new Staff { Staffid = 16, FirstName = "George", LastName = "Tyson", StaffType = "Manager", CheckAvailibility = true, isFirstAider = true }
                );

            builder.Entity<Event>()
                .HasData(
                new Event { EventId = 1, EventTitle = "Jammie Weds Quinn ",EventDateTime = new DateTime(2021, 12, 03, 10,00,00),EventTypeId = "WED"},
                new Event { EventId = 2, EventTitle = "Web apps ICA Final Discussion", EventDateTime = new DateTime(2022, 01, 01, 11, 00, 00), EventTypeId = "MET" }
                );

            builder.Entity<GuestBooking>()
                .HasData(
                new GuestBooking {  GuestBookingID = 1, CustomerId = 2, EventId = 2 , GuestAttendence = "Yes"},
                new GuestBooking { GuestBookingID = 2, CustomerId = 1, EventId = 1, GuestAttendence = "No"},
                new GuestBooking { GuestBookingID = 3, CustomerId = 1, EventId = 2, GuestAttendence = "Yes"},
                new GuestBooking { GuestBookingID = 4, CustomerId = 5, EventId = 1, GuestAttendence = "Yes"},
                new GuestBooking {  GuestBookingID = 5, CustomerId = 3, EventId = 2 , GuestAttendence = "No"}
                );
            builder.Entity<Staffing>()
                .HasData(
                new Staffing { EventId = 1, StaffId = 1 },
                new Staffing { EventId = 1, StaffId = 2 },
                new Staffing { EventId = 1, StaffId = 3 },
                new Staffing { EventId = 1, StaffId = 4 },
                new Staffing { EventId = 2, StaffId = 7 },
                new Staffing { EventId = 2, StaffId = 8 },
                new Staffing { EventId = 2, StaffId = 12 },
                new Staffing { EventId = 2, StaffId = 14 }
                );


        }
        public DbSet<ThAmCo.Events.EventDTOs.MenuFoodItemsDTO> MenuFoodItemsDTO { get; set; }



    }
}
