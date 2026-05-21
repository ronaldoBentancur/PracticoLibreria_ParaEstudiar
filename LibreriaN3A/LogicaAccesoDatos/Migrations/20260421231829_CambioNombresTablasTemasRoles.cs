using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombresTablasTemasRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TiposUsuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposUsuarios",
                table: "TiposUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "TiposUsuarios",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Temas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temas",
                table: "Temas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temas",
                table: "Temas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Temas",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "TiposUsuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposUsuarios",
                table: "TiposUsuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TiposUsuarios_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "TiposUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
