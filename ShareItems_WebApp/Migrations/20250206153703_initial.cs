using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareItems_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    matter = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: true),
                    secondaryPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_code",
                table: "UserCredentials",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCredentials");
        }
    }
}
