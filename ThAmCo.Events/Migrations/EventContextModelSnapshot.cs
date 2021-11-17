﻿// <auto-generated />
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

                    b.Property<string>("TelePhoneNumber")
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
                            TelePhoneNumber = "07293829323"
                        },
                        new
                        {
                            CustomerId = 2,
                            EmailId = "i_amStacy20@gmail.com",
                            FirstName = "Stacy",
                            LastName = "Parks",
                            TelePhoneNumber = "0724679809"
                        },
                        new
                        {
                            CustomerId = 3,
                            EmailId = "andrewpool1992@gmail.com",
                            FirstName = "Andrew",
                            LastName = "Pool",
                            TelePhoneNumber = "07908789323"
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
                            TelePhoneNumber = "07668394322"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
