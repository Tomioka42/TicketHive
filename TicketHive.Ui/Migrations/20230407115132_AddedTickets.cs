using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Ui.Migrations
{
    /// <inheritdoc />
    public partial class AddedTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "Image3.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image3.jpg", 5 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image4.jpg", 100 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image7.jpg", 15 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image7.jpg", 14 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image10.jpg", 90 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image3.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image6.jpg", 8 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image8.jpg", 55 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image9.jpg", 16 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "Image10.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image7.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image3.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image5.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image2.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image6.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image10.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image8.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image3.jpg", 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Image", "TotalTickets" },
                values: new object[] { "Image3.jpg", 0 });
        }
    }
}
