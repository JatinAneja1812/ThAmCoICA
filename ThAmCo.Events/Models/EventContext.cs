using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Models
{
    public class EventContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }

        public EventContext(DbContextOptions<EventContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed data

            builder.Entity<Customer>()
                .HasData(
                new Customer { CustomerId = 1, FirstName = "Ollie" , LastName = "Smith" , TelePhoneNumber = "07293829323" , EmailId = "oliie_12star@gmail.com"  },
                new Customer { CustomerId = 2, FirstName = "Stacy", LastName = "Parks", TelePhoneNumber = "0724679809", EmailId = "i_amStacy20@gmail.com" },
                new Customer { CustomerId = 3, FirstName = "Andrew", LastName = "Pool", TelePhoneNumber = "07908789323", EmailId = "andrewpool1992@gmail.com" },
                new Customer { CustomerId = 4, FirstName = "Neil", LastName = "Malendez", EmailId = "n.Malendez200@gmail.com" },
                new Customer { CustomerId = 5, FirstName = "Jennie", LastName = "White", TelePhoneNumber = "0766839432", EmailId = "Jennie.non.White200@gmail.com" }
                );

            builder.Entity<Staff>()
                .HasData(
                new Staff {  Staffid = 1, FirstName ="Paulo" , LastName = "Marks", StaffType = "Waiter"},
                new Staff { Staffid = 2, FirstName = "Mary", LastName = "Gibbs", StaffType = "Manager" },
                new Staff { Staffid = 3, FirstName = "Kacy", LastName = "Holland", StaffType = "Wedding Planner" },
                new Staff { Staffid = 4, FirstName = "Arvind", LastName = "Sharma", StaffType = "Bartender" },
                new Staff { Staffid = 5, FirstName = "Raghav", LastName = "Kuma", StaffType = "Event Organiser" },
                new Staff { Staffid = 6, FirstName = "Kyle", LastName = "Butler", StaffType = "Photographer" },
                new Staff { Staffid = 7, FirstName = "Andy", LastName = "Angels", StaffType = "Caterer" },
                new Staff { Staffid = 8, FirstName = "Mandy", LastName = "Green", StaffType = "DJ Music Mixer" },
                new Staff { Staffid = 9, FirstName = "Sandy", LastName = "Geller", StaffType = "Waiter" },
                new Staff { Staffid = 10, FirstName = "Barry", LastName = "Tribbiani", StaffType = "Waiter" },
                new Staff { Staffid = 11, FirstName = "Penny", LastName = "Parks", StaffType = "Event Organiser" },
                new Staff { Staffid = 12, FirstName = "Larc", LastName = "Meads", StaffType = "Caterer" },
                new Staff { Staffid = 13, FirstName = "Garry", LastName = "James", StaffType = "Waiter" },
                new Staff { Staffid = 14, FirstName = "Kirti", LastName = "Sanon", StaffType = "Photographer" }
                );

        }
        
    }
}
