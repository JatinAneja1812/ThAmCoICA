using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class EventContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

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
                new Customer { CustomerId = 5, FirstName = "Jennie", LastName = "White", TelePhoneNumber = "07668394322", EmailId = "Jennie.non.White200@gmail.com" }
                );

        }
    }
}
