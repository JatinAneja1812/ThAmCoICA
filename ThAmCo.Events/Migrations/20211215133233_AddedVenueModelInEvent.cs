using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class AddedVenueModelInEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VenueDb",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    CostPerHour = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueDb", x => x.Code);
                    table.ForeignKey(
                        name: "FK_VenueDb_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VenueDb_EventId",
                table: "VenueDb",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueDb");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Event");
        }
    }
}
