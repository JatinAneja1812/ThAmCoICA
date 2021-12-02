using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class addeddatatoStaffDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckAvailibility",
                table: "Staff",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 1,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 2,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 3,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 5,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 8,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 9,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 10,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 11,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 13,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 14,
                column: "CheckAvailibility",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckAvailibility",
                table: "Staff");
        }
    }
}
