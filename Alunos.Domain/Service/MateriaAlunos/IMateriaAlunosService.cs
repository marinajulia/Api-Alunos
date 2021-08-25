using Alunos.Domain.Service.MateriaAlunos.Dto;
using System.Collections.Generic;

namespace Alunos.Domain.Service.MateriaAlunos
{
    public interface IMateriaAlunosService
    {
        MateriaAlunosDto Post(MateriaAlunosDto materiaAlunoDto);
        IEnumerable<MateriaAlunosDto> Get();
        IEnumerable<MateriaAlunosDto> GetMateriasDoAluno(int idAluno);
        IEnumerable<MateriaAlunosDto> GetAlunosdaMateria(int idMateria);
        MateriaAlunosDto GetById(int id);
        bool Delete(int materiaAluno);
        IEnumerable<MateriaAlunosDto> GetByNameMateria(string nome);
        IEnumerable<MateriaAlunosDto> GetByNameAlunos(string nome);
    }
}
