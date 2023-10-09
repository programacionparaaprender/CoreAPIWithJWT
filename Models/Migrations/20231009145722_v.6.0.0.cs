using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class v600 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuario",
                newName: "password");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Usuario",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "Usuario",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "Usuario",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Usuario",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Usuario",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuarioId");
        }
    }
}
