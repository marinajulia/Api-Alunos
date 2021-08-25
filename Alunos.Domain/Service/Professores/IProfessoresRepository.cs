using Alunos.Domain.Service.Professores.Entities;
using System.Collections.Generic;

namespace Alunos.Domain.Service.Professores
{
    public interface IProfessoresRepository
    {
        IEnumerable<ProfessoresEntity> Get();
        ProfessoresEntity GetById(int id);
        ProfessoresEntity GetNames(string name);
        ProfessoresEntity Post(ProfessoresEntity professor);
        IEnumerable<ProfessoresEntity> GetByName(string nome);
        bool Delete(ProfessoresEntity professor);
    }
}
