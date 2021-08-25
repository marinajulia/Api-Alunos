using Alunos.Domain.Service.Materias.Entities;
using Alunos.Domain.Service.Professores.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alunos.Domain.Service.MateriaProfessores
{
    public class MateriaProfessoresEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Professores")]
        public int IdProfessores { get; set; }
        public ProfessoresEntity Professores { get; set; }

        [ForeignKey("Materias")]
        public int IdMaterias { get; set; }
        public MateriasEntity Materias { get; set; }
    }
}
