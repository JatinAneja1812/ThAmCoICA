using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class GuestBookingSeeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventTypeId",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GuestBooking",
                columns: table => new
                {
                    GuestBookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    GuestAttendence = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestBooking", x => x.GuestBookingID);
                });

            migrationBuilder.InsertData(
                table: "GuestBooking",
                columns: new[] { "GuestBookingID", "CustomerId", "EventId", "GuestAttendence" },
                values: new object[,]
                {
                    { 1, 2, 2, "Yes" },
                    { 2, 1, 1, "No" },
                    { 3, 1, 2, "Yes" },
                    { 4, 5, 1, "Yes" },
                    { 5, 3, 2, "No" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestBooking");

            migrationBuilder.AlterColumn<string>(
                name: "EventTypeId",
                table: "Event",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
