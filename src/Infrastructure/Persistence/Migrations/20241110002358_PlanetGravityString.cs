using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PlanetGravityString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gravity",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Gravity",
                table: "Planets",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
