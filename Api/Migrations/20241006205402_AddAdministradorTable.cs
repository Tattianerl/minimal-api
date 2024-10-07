using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api.Migrations
{
    /// <inheritdoc />
    public partial class AddAdministradorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Veiculos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Administradores",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Veiculos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Administradores",
                newName: "id");
        }
    }
}
