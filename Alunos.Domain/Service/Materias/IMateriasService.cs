using Alunos.Domain.Service.Materias.Dto;
using System.Collections.Generic;

namespace Alunos.Domain.Service.Materias
{
    public interface IMateriasService
    {
        MateriasDto Post(MateriasDto materiaDto);
        IEnumerable<MateriasDto> Get();
        MateriasDto GetById(int id);
        bool Delete(int materia);
        IEnumerable<MateriasDto> GetByName(string nome);
    }
}
