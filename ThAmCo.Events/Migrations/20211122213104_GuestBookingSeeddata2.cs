using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class GuestBookingSeeddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestBooking",
                table: "GuestBooking");

            migrationBuilder.RenameTable(
                name: "GuestBooking",
                newName: "GuestBookings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestBookings",
                table: "GuestBookings",
                column: "GuestBookingID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_CustomerId",
                table: "GuestBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_EventId",
                table: "GuestBookings",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Customers_CustomerId",
                table: "GuestBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Event_EventId",
                table: "GuestBookings",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Customers_CustomerId",
                table: "GuestBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Event_EventId",
                table: "GuestBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestBookings",
                table: "GuestBookings");

            migrationBuilder.DropIndex(
                name: "IX_GuestBookings_CustomerId",
                table: "GuestBookings");

            migrationBuilder.DropIndex(
                name: "IX_GuestBookings_EventId",
                table: "GuestBookings");

            migrationBuilder.RenameTable(
                name: "GuestBookings",
                newName: "GuestBooking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestBooking",
                table: "GuestBooking",
                column: "GuestBookingID");
        }
    }
}
