using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InstitutoWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CursosPredeterminados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Cursos_CursoId",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "Curso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Categoria", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ciencias", "Matematicas" },
                    { 2, "Letras", "Lenguaje y Comunicacion" },
                    { 3, "Ciencias", "Química" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Curso_CursoId",
                table: "Notas",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Curso_CursoId",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Curso",
                newName: "Cursos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Cursos_CursoId",
                table: "Notas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
