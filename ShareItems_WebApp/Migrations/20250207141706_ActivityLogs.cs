using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareItems_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ActivityLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dateTimes",
                table: "UserCredentials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTimes",
                table: "UserCredentials");
        }
    }
}
