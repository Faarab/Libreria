using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updatedtipologie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Tipologie",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Tipologie");
        }
    }
}
