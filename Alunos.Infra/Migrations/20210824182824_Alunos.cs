using Microsoft.EntityFrameworkCore.Migrations;

namespace Alunos.Infra.Migrations
{
    public partial class Alunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MateriaAlunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlunos = table.Column<int>(type: "int", nullable: false),
                    IdAMaterias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaAlunos_Alunos_IdAlunos",
                        column: x => x.IdAlunos,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaAlunos_Materias_IdAMaterias",
                        column: x => x.IdAMaterias,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaProfessores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfessores = table.Column<int>(type: "int", nullable: false),
                    IdAMaterias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaProfessores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaProfessores_Materias_IdAMaterias",
                        column: x => x.IdAMaterias,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaProfessores_Professores_IdProfessores",
                        column: x => x.IdProfessores,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAlunos_IdAlunos",
                table: "MateriaAlunos",
                column: "IdAlunos");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAlunos_IdAMaterias",
                table: "MateriaAlunos",
                column: "IdAMaterias");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfessores_IdAMaterias",
                table: "MateriaProfessores",
                column: "IdAMaterias");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfessores_IdProfessores",
                table: "MateriaProfessores",
                column: "IdProfessores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaAlunos");

            migrationBuilder.DropTable(
                name: "MateriaProfessores");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
