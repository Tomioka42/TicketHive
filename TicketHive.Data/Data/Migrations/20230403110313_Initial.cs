using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHive.Ui.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestCapacity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Events_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DateTime", "EventType", "GuestCapacity", "Location", "Name", "TicketPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music festival", 35000, "Sölvesborg", "Sweden Rock", 600m },
                    { 2, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music festival", 125000, "Indio, California", "Coachella Music Festival", 429.99m },
                    { 3, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beer festival", 6000, "Munich, Germany", "Oktoberfest", 50m },
                    { 4, new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art festival", 70000, "Black Rock City, Nevada", "Burning Man", 475m },
                    { 5, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entertainment convention", 135000, "San Diego, California", "San Diego Comic-Con", 150m },
                    { 6, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports event", 2500, "Beijing, China", "Winter Olympics", 250m },
                    { 7, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film festival", 40000, "Cannes, France", "Cannes Film Festival", 50m },
                    { 8, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carnival", 1000000, "New Orleans, Louisiana", "Mardi Gras", 300m },
                    { 9, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technology convention", 170000, "Las Vegas, Nevada", "Consumer Electronics Show", 200m },
                    { 10, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports event", 39000, "London, United Kingdom", "Wimbledon Tennis Championships", 500m },
                    { 11, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cultural event", 2000000, "Pamplona, Spain", "Running of the Bulls", 150m },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2024), "Sports event", 40000, "Various cities", "World Series", 70000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserModelId",
                table: "Bookings",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventModelId",
                table: "Users",
                column: "EventModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
