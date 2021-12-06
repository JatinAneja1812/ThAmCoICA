using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class addedStaffingsforEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staffings",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffings", x => new { x.EventId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_Staffings_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffings_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Staffid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Staffings",
                columns: new[] { "EventId", "StaffId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 12 },
                    { 2, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_StaffId",
                table: "Staffings",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffings");
        }
    }
}
