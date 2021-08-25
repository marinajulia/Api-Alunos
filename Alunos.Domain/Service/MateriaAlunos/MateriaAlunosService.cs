using Alunos.Domain.Service.MateriaAlunos.Dto;
using Alunos.SharedKernel.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Domain.Service.MateriaAlunos
{
    public class MateriaAlunosService : IMateriaAlunosService
    {
        private readonly INotification _notification;
        private readonly IMateriaAlunosRepository _materiaAlunosRepository;

        public MateriaAlunosService(IMateriaAlunosRepository materiaAlunosRepository, INotification notification)
        {
            _materiaAlunosRepository = materiaAlunosRepository;
            _notification = notification;
        }

        public bool Delete(int materiaAluno)
        {
            var materiaAlunoData = _materiaAlunosRepository.GetById(materiaAluno);
            if (materiaAlunoData == null)
                return _notification.AddWithReturn<bool>("Ops.. a relação de aluno e matéria não pode ser encontrada!");

            _materiaAlunosRepository.Delete(materiaAlunoData);
            _notification.Add("A relação de matéria/aluno foi deletada com sucesso");
            return true;
        }

        public IEnumerable<MateriaAlunosDto> Get()
        {
            var materiaAlunos = _materiaAlunosRepository.Get();

            return materiaAlunos.Select(x => new MateriaAlunosDto
            {
                Id = x.Id,
                IdAlunos = x.IdAlunos,
                IdMaterias = x.IdMaterias
            });
        }

        public MateriaAlunosDto GetById(int id)
        {
            var materiaAluno = _materiaAlunosRepository.GetById(id);
            if (materiaAluno == null)
                return _notification.AddWithReturn<MateriaAlunosDto>
                    ("Ops.. o Id da matéria e aluno não pode ser encontrado");
            return new MateriaAlunosDto
            {
                Id = materiaAluno.Id,
                IdAlunos = materiaAluno.IdAlunos,
                IdMaterias = materiaAluno.IdMaterias
            };
        }

        public IEnumerable<MateriaAlunosDto> GetByNameAlunos(string nome)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MateriaAlunosDto> GetByNameMateria(string nome)
        {
            throw new System.NotImplementedException();
        }

        public MateriaAlunosDto Post(MateriaAlunosDto materiaAlunoDto)
        {

            var verificaCadastro = _materiaAlunosRepository
                .GetByCadastroExistente(materiaAlunoDto.IdMaterias, materiaAlunoDto.IdAlunos);

            if (verificaCadastro)
                return _notification.AddWithReturn<MateriaAlunosDto>("Ops.. este cadastro já existe");

            var materiaAluno = _materiaAlunosRepository.Post(new MateriaAlunosEntity
            {
                IdAlunos = materiaAlunoDto.IdAlunos,
                IdMaterias = materiaAlunoDto.IdMaterias,
            });

            return new MateriaAlunosDto
            {
                Id = materiaAluno.Id,
                IdAlunos = materiaAluno.IdAlunos,
                IdMaterias = materiaAluno.IdMaterias
            };
        }
    }
}
