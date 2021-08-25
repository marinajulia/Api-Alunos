using Alunos.Domain.Service.MateriaProfessores.Dto;
using System.Collections.Generic;

namespace Alunos.Domain.Service.MateriaProfessores
{
    public interface IMateriaProfessoresService
    {
        MateriaProfessoresDto Post(MateriaProfessoresDto materiaProfessoresDto);
        IEnumerable<MateriaProfessoresDto> Get();
        MateriaProfessoresDto GetById(int id);
        bool Delete(int materiaProfessor);
        IEnumerable<MateriaProfessoresDto> GetByNameMateria(string nome);
        IEnumerable<MateriaProfessoresDto> GetByNameProfessores (string nome);
    }
}
