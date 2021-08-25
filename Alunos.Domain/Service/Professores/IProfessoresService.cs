using Alunos.Domain.Service.Professores.Dto;
using System.Collections.Generic;

namespace Alunos.Domain.Service.Professores
{
    public interface IProfessoresService
    {
        ProfessoresDto Post(ProfessoresDto professor);
        IEnumerable<ProfessoresDto> Get();
        ProfessoresDto GetById(int id);
        bool Delete(int professor);
        IEnumerable<ProfessoresDto> GetByName(string nome);
    }
}
