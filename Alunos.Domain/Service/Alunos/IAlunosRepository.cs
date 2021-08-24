using Alunos.Domain.Service.Alunos.Entities;
using System.Collections.Generic;

namespace Alunos.Domain.Service.Alunos
{
    public interface IAlunosRepository
    {
        IEnumerable<AlunosEntity> Get();
        IEnumerable<AlunosEntity> GetByName(string nome);
        AlunosEntity GetById(int id);
        AlunosEntity GetByRa(string ra);
        AlunosEntity Post(AlunosEntity aluno);
        bool Delete(AlunosEntity aluno);

    }
}
