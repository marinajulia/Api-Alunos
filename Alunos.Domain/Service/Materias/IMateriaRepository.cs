using Alunos.Domain.Service.Materias.Entities;
using System.Collections.Generic;

namespace Alunos.Domain.Service.Materias
{
    public interface IMateriaRepository
    {
        IEnumerable<MateriasEntity> Get();
        MateriasEntity GetById(int id);
        MateriasEntity Post(MateriasEntity materia);
        IEnumerable<MateriasEntity> GetByName(string nome);
        bool Delete(MateriasEntity materia);
    }
}
