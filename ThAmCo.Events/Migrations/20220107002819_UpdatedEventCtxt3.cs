using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class UpdatedEventCtxt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventDateTime",
                value: new DateTime(2021, 12, 3, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "EventDateTime", "EventTitle" },
                values: new object[] { new DateTime(2022, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Web apps ICA Final Discussion" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventDateTime",
                value: new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2,
                columns: new[] { "EventDateTime", "EventTitle" },
                values: new object[] { new DateTime(2022, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), "Web apps ICA Final Report Discussion" });
        }
    }
}
