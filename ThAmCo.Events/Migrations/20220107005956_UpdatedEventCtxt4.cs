using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class UpdatedEventCtxt4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Staffid", "CheckAvailibility", "FirstName", "LastName", "StaffType", "isFirstAider" },
                values: new object[] { 15, true, "Jason", "Millar", "Manager", true });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Staffid", "CheckAvailibility", "FirstName", "LastName", "StaffType", "isFirstAider" },
                values: new object[] { 16, true, "George", "Tyson", "Manager", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Staffid",
                keyValue: 16);
        }
    }
}
