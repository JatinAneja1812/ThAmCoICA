using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class addedstaffFirstAider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFirstAider",
                table: "Staff",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 1,
                columns: new[] { "CheckAvailibility", "isFirstAider" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 2,
                columns: new[] { "CheckAvailibility", "isFirstAider" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 3,
                column: "CheckAvailibility",
                value: false);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 4,
                column: "isFirstAider",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 6,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 8,
                column: "CheckAvailibility",
                value: false);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 10,
                column: "isFirstAider",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 11,
                column: "isFirstAider",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 14,
                columns: new[] { "CheckAvailibility", "isFirstAider" },
                values: new object[] { false, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFirstAider",
                table: "Staff");

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
                keyValue: 6,
                column: "CheckAvailibility",
                value: false);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 8,
                column: "CheckAvailibility",
                value: true);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 14,
                column: "CheckAvailibility",
                value: true);
        }
    }
}
