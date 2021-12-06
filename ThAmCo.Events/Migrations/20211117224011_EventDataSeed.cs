using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class EventDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false),
                    EventTypeId = table.Column<string>(maxLength: 3, nullable: false),
                    EventType = table.Column<string>(nullable: true),
                    FoodBookingId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CustomerId", "EventDateTime", "EventType", "EventTypeId", "FoodBookingId", "ReservationId", "StaffId", "Title" },
                values: new object[] { 1, 0, new DateTime(2021, 2, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), null, "WED", 0, 0, 0, "Tannu weds mannu" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CustomerId", "EventDateTime", "EventType", "EventTypeId", "FoodBookingId", "ReservationId", "StaffId", "Title" },
                values: new object[] { 2, 0, new DateTime(2021, 4, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), null, "MET", 0, 0, 0, "Web apps and services ICA disscussion" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
