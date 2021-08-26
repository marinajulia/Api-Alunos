using Alunos.Domain.Service.Materias.Entities;
using Alunos.Domain.Service.Professores.Entities;

namespace Alunos.Domain.Service.MateriaProfessores.Dto
{
    public  class MateriaProfessoresDto
    {
        public int Id { get; set; }
        public int IdProfessores { get; set; }
        public ProfessoresEntity Professores { get; set; }
        public int IdMaterias { get; set; }
        public MateriasEntity Materias { get; set; }
    }
}
