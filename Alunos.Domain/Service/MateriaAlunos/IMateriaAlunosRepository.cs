using System.Collections.Generic;

namespace Alunos.Domain.Service.MateriaAlunos
{
    public interface IMateriaAlunosRepository
    {
        IEnumerable<MateriaAlunosEntity> Get();
        MateriaAlunosEntity GetById(int id);
        MateriaAlunosEntity GetByIdAluno(int id);
        MateriaAlunosEntity GetByIdMateria(int id);
        MateriaAlunosEntity Post(MateriaAlunosEntity materiaAluno);
        IEnumerable<MateriaAlunosEntity> GetByNameAluno(string nomeAluno);
        IEnumerable<MateriaAlunosEntity> GetByNameMateria(string nomeMateria);
        bool Delete(MateriaAlunosEntity materiaAlunos);
    }
}
