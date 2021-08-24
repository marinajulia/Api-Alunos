using Alunos.Domain.Service.Alunos.Entities;
using Alunos.Domain.Service.Materias.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alunos.Domain.Service.MateriaAlunos
{
    public class MateriaAlunosEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Alunos")]
        public int IdAlunos { get; set; }
        public AlunosEntity Alunos  { get; set; }

        [ForeignKey("Materias")]
        public int IdAMaterias { get; set; }
        public MateriasEntity Materias { get; set; }
    }
}
