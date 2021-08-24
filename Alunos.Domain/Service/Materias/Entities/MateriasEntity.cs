using System.ComponentModel.DataAnnotations;

namespace Alunos.Domain.Service.Materias.Entities
{
    public class MateriasEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}
