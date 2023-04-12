using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Ui.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingModel_IdentityUsers_IdentityUserModelId",
                table: "BookingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingModel_UserModel_UserId",
                table: "BookingModel");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropIndex(
                name: "IX_BookingModel_IdentityUserModelId",
                table: "BookingModel");

            migrationBuilder.DropColumn(
                name: "IdentityUserModelId",
                table: "BookingModel");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookingModel_Users_UserId",
                table: "BookingModel",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingModel_Users_UserId",
                table: "BookingModel");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<int>(
                name: "IdentityUserModelId",
                table: "BookingModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingModel_IdentityUserModelId",
                table: "BookingModel",
                column: "IdentityUserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingModel_IdentityUsers_IdentityUserModelId",
                table: "BookingModel",
                column: "IdentityUserModelId",
                principalTable: "IdentityUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingModel_UserModel_UserId",
                table: "BookingModel",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id");
        }
    }
}
