using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class v400 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuario",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuario",
                newName: "Nombre");
        }
    }
}
