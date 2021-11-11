using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.DataModels
{
    public class ThAmCo_CateringDBContext : DbContext
    {

        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        public ThAmCo_CateringDBContext(DbContextOptions<ThAmCo_CateringDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // RelationShips
            builder.Entity<FoodBooking>()
                .HasOne(a => a.Menu)
                .WithMany()
                .HasForeignKey(b => b.MenuId);

            // Composite key
            builder.Entity<MenuFoodItem>()
                .HasKey(a => new { a.MenuId, a.FoodItemId });

            builder.Entity<MenuFoodItem>()
                .HasOne(a => a.Menu)
                .WithMany()
                .HasForeignKey(b => b.MenuId);

            builder.Entity<MenuFoodItem>()
                .HasOne(a => a.FoodItem)
                .WithMany()
                .HasForeignKey(b => b.FoodItemId);


            // seed data

            builder.Entity<FoodItem>()
                .HasData(

                new FoodItem { FoodItemId = 1, Description = "Tacos", UnitPrice = 8.13F },
                new FoodItem { FoodItemId = 2, Description = "TunaSandwich", UnitPrice = 2.95F },
                new FoodItem { FoodItemId = 3, Description = "Risotto", UnitPrice = 10.21F },
                new FoodItem { FoodItemId = 4, Description = "CheeseBurger ", UnitPrice = 5.64F },
                new FoodItem { FoodItemId = 5, Description = "ChickenWings", UnitPrice = 3.37F }
                );

            builder.Entity<Menu>()
                .HasData(

                new Menu { MenuId = 1, MenuName  = "BurgersKings" },
                new Menu { MenuId = 2, MenuName = "ComfortFood" },
                new Menu { MenuId = 3, MenuName = "ChickenPotPie" },
                new Menu { MenuId = 4, MenuName = "TacoBell" }
                );


            builder.Entity<FoodBooking>()
                .HasData(

                new FoodBooking { FoodBookingId = 1, ClientReferenceId = 123, NumberOfGuests = 4, MenuId = 2 },
                new FoodBooking { FoodBookingId = 2, ClientReferenceId = 145, NumberOfGuests = 3, MenuId = 1 },
                new FoodBooking { FoodBookingId = 3, ClientReferenceId = 111, NumberOfGuests = 1, MenuId = 2 },
                new FoodBooking { FoodBookingId = 4, ClientReferenceId = 137, NumberOfGuests = 5, MenuId = 3 },
                new FoodBooking { FoodBookingId = 5, ClientReferenceId = 120, NumberOfGuests = 8, MenuId = 4 }
                );

            builder.Entity<MenuFoodItem>()
                .HasData(

                new MenuFoodItem { MenuId = 3,  FoodItemId = 3},
                new MenuFoodItem { MenuId = 1, FoodItemId = 4 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 5 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 4, FoodItemId = 1 }
                );



        }


    }
}
