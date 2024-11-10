using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PeoplePlanetToHomeworld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_Planets_PlanetId",
                table: "Peoples");

            migrationBuilder.RenameColumn(
                name: "PlanetId",
                table: "Peoples",
                newName: "HomeworldId");

            migrationBuilder.RenameIndex(
                name: "IX_Peoples_PlanetId",
                table: "Peoples",
                newName: "IX_Peoples_HomeworldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_Planets_HomeworldId",
                table: "Peoples",
                column: "HomeworldId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_Planets_HomeworldId",
                table: "Peoples");

            migrationBuilder.RenameColumn(
                name: "HomeworldId",
                table: "Peoples",
                newName: "PlanetId");

            migrationBuilder.RenameIndex(
                name: "IX_Peoples_HomeworldId",
                table: "Peoples",
                newName: "IX_Peoples_PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_Planets_PlanetId",
                table: "Peoples",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }
    }
}
