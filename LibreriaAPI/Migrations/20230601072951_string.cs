using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaAPI.Migrations
{
    /// <inheritdoc />
    public partial class @string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnnoDiRilascio",
                table: "Documenti",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnnoDiRilascio",
                table: "Documenti",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
