using Alunos.Domain.Service.Alunos.Entities;
using Alunos.Domain.Service.Materias.Entities;

namespace Alunos.Domain.Service.MateriaAlunos.Dto
{
    public class MateriaAlunosDto
    {
        public int Id { get; set; }

        public int IdAlunos { get; set; }
        public AlunosEntity Alunos { get; set; }

        public int IdMaterias { get; set; }
        public MateriasEntity Materias { get; set; }
    }
}
