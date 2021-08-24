using Alunos.Domain.Service.Alunos.Dto;
using System.Collections.Generic;

namespace Alunos.Domain.Service.Alunos
{
    public interface IAlunosService
    {
        AlunosDto Post(AlunosDto alunoDto);
        IEnumerable<AlunosDto> Get();
        AlunosDto GetById(int id);
        bool Delete(int aluno);
        IEnumerable<AlunosDto> GetByName(string nome);
    }
}
