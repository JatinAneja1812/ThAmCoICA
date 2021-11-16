using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class initalCustomerSeeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    TelePhoneNumber = table.Column<long>(nullable: false),
                    EmailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "EmailId", "FirstName", "LastName", "TelePhoneNumber" },
                values: new object[,]
                {
                    { 1, "oliie_12star@gmail.com", "Ollie", "Smith", 7293829323L },
                    { 2, "i_amStacy20@gmail.com", "Stacy", "Parks", 724679809L },
                    { 3, "andrewpool1992@gmail.com", "Andrew", "Pool", 7908789323L },
                    { 4, "n.Malendez200@gmail.com", "Neil", "Malendez", 0L },
                    { 5, "Jennie.non.White200@gmail.com", "Jennie", "White", 7668394322L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
