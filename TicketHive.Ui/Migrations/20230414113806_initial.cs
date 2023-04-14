using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketHive.Ui.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTickets = table.Column<int>(type: "int", nullable: false),
                    TicketsSold = table.Column<int>(type: "int", nullable: false)
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AmountOfTickets = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DateTime", "EventType", "GuestCapacity", "Image", "Location", "Name", "TicketPrice", "TicketsSold", "TotalTickets" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music festival", 35000, "Image10.jpg", "Sölvesborg", "Sweden Rock", 600m, 0, 0 },
                    { 2, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music festival", 125000, "Image4.jpg", "Indio, California", "Coachella Music Festival", 429.99m, 0, 5 },
                    { 3, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beer festival", 6000, "Image7.jpg", "Munich, Germany", "Oktoberfest", 50m, 0, 30 },
                    { 4, new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art festival", 70000, "Image9.jpg", "Black Rock City, Nevada", "Burning Man", 475m, 0, 5 },
                    { 5, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entertainment convention", 135000, "Image6.jpg", "San Diego, California", "San Diego Comic-Con", 150m, 0, 100 },
                    { 6, new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports event", 2500, "Image1.jpg", "Beijing, China", "Winter Olympics", 250m, 0, 15 },
                    { 7, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film festival", 40000, "Image10.jpg", "Cannes, France", "Cannes Film Festival", 50m, 0, 14 },
                    { 8, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carnival", 1000000, "Image3.jpg", "New Orleans, Louisiana", "Mardi Gras", 300m, 0, 90 },
                    { 9, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Technology convention", 170000, "Image4.jpg", "Las Vegas, Nevada", "Consumer Electronics Show", 200m, 0, 1 },
                    { 10, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports event", 39000, "Image1.jpg", "London, United Kingdom", "Wimbledon Tennis Championships", 500m, 0, 0 },
                    { 11, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cultural event", 2000000, "Image8.jpg", "Pamplona, Spain", "Running of the Bulls", 150m, 0, 55 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2024), "Sports event", 40000, "Image0.jpg", "Various cities", "World Series", 70000m, 0, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventId",
                table: "Bookings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
