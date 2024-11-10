using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PeopleBirthYearString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BirthYear",
                table: "Peoples",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BirthYear",
                table: "Peoples",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
