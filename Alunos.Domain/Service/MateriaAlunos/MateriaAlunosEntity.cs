using Alunos.Domain.Service.Alunos.Entities;
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
    }
}
