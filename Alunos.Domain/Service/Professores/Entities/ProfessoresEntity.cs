using System.ComponentModel.DataAnnotations;

namespace Alunos.Domain.Service.Professores.Entities
{
    public class ProfessoresEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
