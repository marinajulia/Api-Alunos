using Microsoft.EntityFrameworkCore.Migrations;

namespace Alunos.Infra.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAlunos_Materias_IdAMaterias",
                table: "MateriaAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfessores_Materias_IdAMaterias",
                table: "MateriaProfessores");

            migrationBuilder.RenameColumn(
                name: "IdAMaterias",
                table: "MateriaProfessores",
                newName: "IdMaterias");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaProfessores_IdAMaterias",
                table: "MateriaProfessores",
                newName: "IX_MateriaProfessores_IdMaterias");

            migrationBuilder.RenameColumn(
                name: "IdAMaterias",
                table: "MateriaAlunos",
                newName: "IdMaterias");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAlunos_IdAMaterias",
                table: "MateriaAlunos",
                newName: "IX_MateriaAlunos_IdMaterias");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAlunos_Materias_IdMaterias",
                table: "MateriaAlunos",
                column: "IdMaterias",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfessores_Materias_IdMaterias",
                table: "MateriaProfessores",
                column: "IdMaterias",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaAlunos_Materias_IdMaterias",
                table: "MateriaAlunos");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfessores_Materias_IdMaterias",
                table: "MateriaProfessores");

            migrationBuilder.RenameColumn(
                name: "IdMaterias",
                table: "MateriaProfessores",
                newName: "IdAMaterias");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaProfessores_IdMaterias",
                table: "MateriaProfessores",
                newName: "IX_MateriaProfessores_IdAMaterias");

            migrationBuilder.RenameColumn(
                name: "IdMaterias",
                table: "MateriaAlunos",
                newName: "IdAMaterias");

            migrationBuilder.RenameIndex(
                name: "IX_MateriaAlunos_IdMaterias",
                table: "MateriaAlunos",
                newName: "IX_MateriaAlunos_IdAMaterias");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaAlunos_Materias_IdAMaterias",
                table: "MateriaAlunos",
                column: "IdAMaterias",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfessores_Materias_IdAMaterias",
                table: "MateriaProfessores",
                column: "IdAMaterias",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
