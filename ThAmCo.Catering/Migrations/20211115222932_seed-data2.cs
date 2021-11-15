using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class seeddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId1",
                table: "MenuFoodItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuFoodItems_MenuId1",
                table: "MenuFoodItems");

            migrationBuilder.DropColumn(
                name: "MenuId1",
                table: "MenuFoodItems");

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "Menus",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "MenuId1",
                table: "MenuFoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuFoodItems_MenuId1",
                table: "MenuFoodItems",
                column: "MenuId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuFoodItems_Menus_MenuId1",
                table: "MenuFoodItems",
                column: "MenuId1",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
