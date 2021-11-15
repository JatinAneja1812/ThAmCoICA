using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class seeddataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 1,
                column: "UnitPrice",
                value: 4.5f);

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 2,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "Buritos", 5.2f });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 3,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "MexianChickenSandwich", 3.95f });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 4,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "Risotto", 6.1f });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 5,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "CheeseBurger ", 5.14f });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "FoodItemId1", "UnitPrice" },
                values: new object[,]
                {
                    { 14, "ChickenWings", null, 3f },
                    { 13, "Shahi Paneer", null, 6.5f },
                    { 6, "American BigDaddy Burger ", null, 7.64f },
                    { 11, "Classic Margherita Piozza ", null, 6.4f },
                    { 10, "Chicken Tikka Masala", null, 5f },
                    { 9, "Rice Papper Rools", null, 9.37f },
                    { 8, "PepproniPizza", null, 6.27f },
                    { 7, "Chicken Pasta", null, 4.5f },
                    { 12, "ApplePie", null, 3.5f }
                });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "MenuId", "FoodItemId", "MenuId1" },
                values: new object[,]
                {
                    { 2, 3, null },
                    { 4, 5, null },
                    { 2, 1, null }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "MenuName",
                value: "ItalianMenu");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2,
                column: "MenuName",
                value: "MexicanMenu");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 3,
                column: "MenuName",
                value: "IndianMenu");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 4,
                column: "MenuName",
                value: "AmericanMenu");

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[] { 5, "ThaiMenu" });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "MenuId", "FoodItemId", "MenuId1" },
                values: new object[,]
                {
                    { 4, 6, null },
                    { 1, 7, null },
                    { 1, 8, null },
                    { 3, 10, null },
                    { 1, 11, null },
                    { 4, 12, null },
                    { 3, 13, null },
                    { 5, 9, null },
                    { 5, 4, null },
                    { 5, 14, null },
                    { 5, 5, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 5, 14 });

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 1,
                column: "UnitPrice",
                value: 8.13f);

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 2,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "TunaSandwich", 2.95f });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 3,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "Risotto", 10.21f });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 4,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "CheeseBurger ", 5.64f });

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 5,
                columns: new[] { "Description", "UnitPrice" },
                values: new object[] { "ChickenWings", 3.37f });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "MenuId", "FoodItemId", "MenuId1" },
                values: new object[,]
                {
                    { 3, 3, null },
                    { 2, 5, null },
                    { 4, 1, null }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1,
                column: "MenuName",
                value: "BurgersKings");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2,
                column: "MenuName",
                value: "ComfortFood");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 3,
                column: "MenuName",
                value: "ChickenPotPie");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 4,
                column: "MenuName",
                value: "TacoBell");
        }
    }
}
