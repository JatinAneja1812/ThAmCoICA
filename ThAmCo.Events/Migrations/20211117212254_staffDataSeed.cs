using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class staffDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Staffid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StaffType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Staffid);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "TelePhoneNumber",
                value: "0766839432");

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Staffid", "FirstName", "LastName", "StaffType" },
                values: new object[,]
                {
                    { 1, "Paulo", "Marks", "Waiter" },
                    { 2, "Mary", "Gibbs", "Manager" },
                    { 3, "Kacy", "Holland", "Wedding Planner" },
                    { 4, "Arvind", "Sharma", "Bartender" },
                    { 5, "Raghav", "Kuma", "Event Organiser" },
                    { 6, "Kyle", "Butler", "Photographer" },
                    { 7, "Andy", "Angels", "Caterer" },
                    { 8, "Mandy", "Green", "DJ Music Mixer" },
                    { 9, "Sandy", "Geller", "Waiter" },
                    { 10, "Barry", "Tribbiani", "Waiter" },
                    { 11, "Penny", "Parks", "Event Organiser" },
                    { 12, "Larc", "Meads", "Caterer" },
                    { 13, "Garry", "James", "Waiter" },
                    { 14, "Kirti", "Sanon", "Photographer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "TelePhoneNumber",
                value: "07668394322");
        }
    }
}
