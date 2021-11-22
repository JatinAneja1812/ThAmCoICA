using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class UpdatedEventContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "FoodBookingId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Event");

            migrationBuilder.CreateTable(
                name: "EventTypeDTO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 3, nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypeDTO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTypeDTO");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodBookingId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
