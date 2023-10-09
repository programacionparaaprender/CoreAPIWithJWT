using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class v700 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstname",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Usuario",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "Usuario",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "Usuario",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "Usuario",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Usuario",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}
