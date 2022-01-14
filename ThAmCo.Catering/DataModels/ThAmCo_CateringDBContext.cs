using Microsoft.EntityFrameworkCore;

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
                .HasData(      ///  Data  for FoodItems

                new FoodItem { FoodItemId = 1, Description = "Tacos", UnitPrice = 4.50F },
                new FoodItem { FoodItemId = 2, Description = "Buritos", UnitPrice = 5.20F },
                new FoodItem { FoodItemId = 3, Description = "MexianChickenSandwich", UnitPrice = 3.95F },
                new FoodItem { FoodItemId = 4, Description = "Risotto", UnitPrice = 6.10F },
                new FoodItem { FoodItemId = 5, Description = "CheeseBurger ", UnitPrice = 5.14F },
                new FoodItem { FoodItemId = 6, Description = "American BigDaddy Burger ", UnitPrice = 7.64F },
                new FoodItem { FoodItemId = 7, Description = "Chicken Pasta", UnitPrice = 4.50F },
                new FoodItem { FoodItemId = 8, Description = "PepproniPizza", UnitPrice = 6.27F },
                new FoodItem { FoodItemId = 9, Description = "Rice Papper Rools", UnitPrice = 9.37F },
                new FoodItem { FoodItemId = 10, Description = "Chicken Tikka Masala", UnitPrice = 5.00F },
                new FoodItem { FoodItemId = 11, Description = "Classic Margherita Piozza ", UnitPrice = 6.40F },
                new FoodItem { FoodItemId = 12, Description = "ApplePie", UnitPrice = 3.50F },
                new FoodItem { FoodItemId = 13, Description = "Shahi Paneer", UnitPrice = 6.50F },
                new FoodItem { FoodItemId = 14, Description = "ChickenWings", UnitPrice = 3.00F }
                );

            builder.Entity<Menu>()
                .HasData(        // Data for Menues
                new Menu { MenuId = 1, MenuName = "ItalianMenu" },
                new Menu { MenuId = 2, MenuName = "MexicanMenu" },
                new Menu { MenuId = 3, MenuName = "IndianMenu" },
                new Menu { MenuId = 4, MenuName = "AmericanMenu" },
                new Menu { MenuId = 5, MenuName = "ThaiMenu" }
                );


            builder.Entity<FoodBooking>()
                .HasData(         // Data for Food   -- Fake data
                new FoodBooking { FoodBookingId = 1, ClientReferenceId = null, NumberOfGuests = 4, MenuId = 2 }
                );

            builder.Entity<MenuFoodItem>()
                .HasData(        // Menu Id
                new MenuFoodItem { MenuId = 1, FoodItemId = 4 },
                new MenuFoodItem { MenuId = 1, FoodItemId = 8 },
                new MenuFoodItem { MenuId = 1, FoodItemId = 7 },
                new MenuFoodItem { MenuId = 1, FoodItemId = 11 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 1 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 3 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 10 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 13 },
                new MenuFoodItem { MenuId = 4, FoodItemId = 5 },
                new MenuFoodItem { MenuId = 4, FoodItemId = 6 },
                new MenuFoodItem { MenuId = 4, FoodItemId = 12 },
                new MenuFoodItem { MenuId = 5, FoodItemId = 9 },
                new MenuFoodItem { MenuId = 5, FoodItemId = 4 },
                new MenuFoodItem { MenuId = 5, FoodItemId = 14 },
                new MenuFoodItem { MenuId = 5, FoodItemId = 5 }
                );



        }


    }
}
