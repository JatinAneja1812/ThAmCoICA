// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Catering.DataModels;

namespace ThAmCo.Catering.Migrations
{
    [DbContext(typeof(ThAmCo_CateringDBContext))]
    [Migration("20211114011908_seeddataUpdate")]
    partial class seeddataUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThAmCo.Catering.DataModels.FoodBooking", b =>
                {
                    b.Property<int>("FoodBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientReferenceId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.HasKey("FoodBookingId");

                    b.HasIndex("MenuId");

                    b.ToTable("FoodBookings");

                    b.HasData(
                        new
                        {
                            FoodBookingId = 1,
                            ClientReferenceId = 123,
                            MenuId = 2,
                            NumberOfGuests = 4
                        },
                        new
                        {
                            FoodBookingId = 2,
                            ClientReferenceId = 145,
                            MenuId = 1,
                            NumberOfGuests = 3
                        },
                        new
                        {
                            FoodBookingId = 3,
                            ClientReferenceId = 111,
                            MenuId = 2,
                            NumberOfGuests = 1
                        },
                        new
                        {
                            FoodBookingId = 4,
                            ClientReferenceId = 137,
                            MenuId = 3,
                            NumberOfGuests = 5
                        },
                        new
                        {
                            FoodBookingId = 5,
                            ClientReferenceId = 120,
                            MenuId = 4,
                            NumberOfGuests = 8
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.DataModels.FoodItem", b =>
                {
                    b.Property<int>("FoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FoodItemId1")
                        .HasColumnType("int");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("FoodItemId");

                    b.HasIndex("FoodItemId1");

                    b.ToTable("FoodItems");

                    b.HasData(
                        new
                        {
                            FoodItemId = 1,
                            Description = "Tacos",
                            UnitPrice = 4.5f
                        },
                        new
                        {
                            FoodItemId = 2,
                            Description = "Buritos",
                            UnitPrice = 5.2f
                        },
                        new
                        {
                            FoodItemId = 3,
                            Description = "MexianChickenSandwich",
                            UnitPrice = 3.95f
                        },
                        new
                        {
                            FoodItemId = 4,
                            Description = "Risotto",
                            UnitPrice = 6.1f
                        },
                        new
                        {
                            FoodItemId = 5,
                            Description = "CheeseBurger ",
                            UnitPrice = 5.14f
                        },
                        new
                        {
                            FoodItemId = 6,
                            Description = "American BigDaddy Burger ",
                            UnitPrice = 7.64f
                        },
                        new
                        {
                            FoodItemId = 7,
                            Description = "Chicken Pasta",
                            UnitPrice = 4.5f
                        },
                        new
                        {
                            FoodItemId = 8,
                            Description = "PepproniPizza",
                            UnitPrice = 6.27f
                        },
                        new
                        {
                            FoodItemId = 9,
                            Description = "Rice Papper Rools",
                            UnitPrice = 9.37f
                        },
                        new
                        {
                            FoodItemId = 10,
                            Description = "Chicken Tikka Masala",
                            UnitPrice = 5f
                        },
                        new
                        {
                            FoodItemId = 11,
                            Description = "Classic Margherita Piozza ",
                            UnitPrice = 6.4f
                        },
                        new
                        {
                            FoodItemId = 12,
                            Description = "ApplePie",
                            UnitPrice = 3.5f
                        },
                        new
                        {
                            FoodItemId = 13,
                            Description = "Shahi Paneer",
                            UnitPrice = 6.5f
                        },
                        new
                        {
                            FoodItemId = 14,
                            Description = "ChickenWings",
                            UnitPrice = 3f
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.DataModels.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            MenuName = "ItalianMenu"
                        },
                        new
                        {
                            MenuId = 2,
                            MenuName = "MexicanMenu"
                        },
                        new
                        {
                            MenuId = 3,
                            MenuName = "IndianMenu"
                        },
                        new
                        {
                            MenuId = 4,
                            MenuName = "AmericanMenu"
                        },
                        new
                        {
                            MenuId = 5,
                            MenuName = "ThaiMenu"
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.DataModels.MenuFoodItem", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<int?>("MenuId1")
                        .HasColumnType("int");

                    b.HasKey("MenuId", "FoodItemId");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("MenuId1");

                    b.ToTable("MenuFoodItems");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            FoodItemId = 4
                        },
                        new
                        {
                            MenuId = 1,
                            FoodItemId = 8
                        },
                        new
                        {
                            MenuId = 1,
                            FoodItemId = 7
                        },
                        new
                        {
                            MenuId = 1,
                            FoodItemId = 11
                        },
                        new
                        {
                            MenuId = 2,
                            FoodItemId = 1
                        },
                        new
                        {
                            MenuId = 2,
                            FoodItemId = 2
                        },
                        new
                        {
                            MenuId = 2,
                            FoodItemId = 3
                        },
                        new
                        {
                            MenuId = 3,
                            FoodItemId = 10
                        },
                        new
                        {
                            MenuId = 3,
                            FoodItemId = 13
                        },
                        new
                        {
                            MenuId = 4,
                            FoodItemId = 5
                        },
                        new
                        {
                            MenuId = 4,
                            FoodItemId = 6
                        },
                        new
                        {
                            MenuId = 4,
                            FoodItemId = 12
                        },
                        new
                        {
                            MenuId = 5,
                            FoodItemId = 9
                        },
                        new
                        {
                            MenuId = 5,
                            FoodItemId = 4
                        },
                        new
                        {
                            MenuId = 5,
                            FoodItemId = 14
                        },
                        new
                        {
                            MenuId = 5,
                            FoodItemId = 5
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.DataModels.FoodBooking", b =>
                {
                    b.HasOne("ThAmCo.Catering.DataModels.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ThAmCo.Catering.DataModels.FoodItem", b =>
                {
                    b.HasOne("ThAmCo.Catering.DataModels.FoodItem", null)
                        .WithMany("foodItms")
                        .HasForeignKey("FoodItemId1");
                });

            modelBuilder.Entity("ThAmCo.Catering.DataModels.MenuFoodItem", b =>
                {
                    b.HasOne("ThAmCo.Catering.DataModels.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Catering.DataModels.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Catering.DataModels.Menu", null)
                        .WithMany("MenuFoods")
                        .HasForeignKey("MenuId1");
                });
#pragma warning restore 612, 618
        }
    }
}
