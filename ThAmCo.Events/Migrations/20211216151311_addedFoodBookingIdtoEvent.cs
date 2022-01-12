using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class addedFoodBookingIdtoEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VenueDb_Event_EventId",
                table: "VenueDb");

            migrationBuilder.DropIndex(
                name: "IX_VenueDb_EventId",
                table: "VenueDb");

            migrationBuilder.AddColumn<int>(
                name: "FoodBookingId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FoodItemDTO",
                columns: table => new
                {
                    FoodItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemDTO", x => x.FoodItemId);
                });

            migrationBuilder.CreateTable(
                name: "MenusDTO",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenusDTO", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "FoodBookingDTO",
                columns: table => new
                {
                    FoodBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientReferenceId = table.Column<int>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBookingDTO", x => x.FoodBookingId);
                    table.ForeignKey(
                        name: "FK_FoodBookingDTO_MenusDTO_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MenusDTO",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuFoodItemsDTO",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    FoodItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuFoodItemsDTO", x => new { x.MenuId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_MenuFoodItemsDTO_FoodItemDTO_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItemDTO",
                        principalColumn: "FoodItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuFoodItemsDTO_MenusDTO_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MenusDTO",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodBookingDTO_MenuId",
                table: "FoodBookingDTO",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuFoodItemsDTO_FoodItemId",
                table: "MenuFoodItemsDTO",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodBookingDTO");

            migrationBuilder.DropTable(
                name: "MenuFoodItemsDTO");

            migrationBuilder.DropTable(
                name: "FoodItemDTO");

            migrationBuilder.DropTable(
                name: "MenusDTO");

            migrationBuilder.DropColumn(
                name: "FoodBookingId",
                table: "Event");

            migrationBuilder.CreateIndex(
                name: "IX_VenueDb_EventId",
                table: "VenueDb",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_VenueDb_Event_EventId",
                table: "VenueDb",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
