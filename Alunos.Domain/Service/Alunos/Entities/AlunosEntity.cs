using System.ComponentModel.DataAnnotations;
namespace Alunos.Domain.Service.Alunos.Entities
{
    public class AlunosEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
    }
}
