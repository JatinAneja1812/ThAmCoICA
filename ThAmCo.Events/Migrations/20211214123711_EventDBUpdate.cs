using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class EventDBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "Event",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EventDateTime", "EventTitle" },
                values: new object[] { new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jammie Weds Quinn " });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2,
                column: "EventTitle",
                value: "Web apps ICA Final Report Discussion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Event");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1,
                columns: new[] { "EventDateTime", "EventTitle" },
                values: new object[] { new DateTime(2021, 11, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), "Tannu weds mannu" });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2,
                column: "EventTitle",
                value: "Web apps and services ICA disscussion");
        }
    }
}
