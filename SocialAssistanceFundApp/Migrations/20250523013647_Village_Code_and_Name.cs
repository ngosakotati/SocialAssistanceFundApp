using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialAssistanceFundApp.Migrations
{
    /// <inheritdoc />
    public partial class Village_Code_and_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Villages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Villages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Villages");
        }
    }
}
