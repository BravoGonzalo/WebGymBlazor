using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Gym.Migrations
{
    /// <inheritdoc />
    public partial class cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Entrenadores_EntrenadorId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_EntrenadorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "EntrenadorId",
                table: "Clientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntrenadorId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EntrenadorId",
                table: "Clientes",
                column: "EntrenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Entrenadores_EntrenadorId",
                table: "Clientes",
                column: "EntrenadorId",
                principalTable: "Entrenadores",
                principalColumn: "Id");
        }
    }
}
