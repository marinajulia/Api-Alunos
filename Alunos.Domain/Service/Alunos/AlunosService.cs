using Alunos.Domain.Service.Alunos.Dto;
using Alunos.Domain.Service.Alunos.Entities;
using Alunos.Domain.Service.MateriaAlunos;
using Alunos.SharedKernel.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Domain.Service.Alunos
{
    public class AlunosService : IAlunosService
    {
        private readonly INotification _notification;
        private readonly IAlunosRepository _alunosRepository;
        private readonly IMateriaAlunosRepository _materiaAlunosRepository;

        public AlunosService(IAlunosRepository alunosRepository, INotification notification,
            IMateriaAlunosRepository materiaAlunosRepository)
        {
            _alunosRepository = alunosRepository;
            _notification = notification;
            _materiaAlunosRepository = materiaAlunosRepository;
        }

        public bool Delete(int aluno)
        {
            var alunoData = _alunosRepository.GetById(aluno);
            if (alunoData == null)
                return _notification.AddWithReturn<bool>("Ops.. O aluno não pode ser encontrado!");

            var verificaRelacaoAlunoMateria = _materiaAlunosRepository.GetByIdAluno(alunoData.Id);

            if (verificaRelacaoAlunoMateria != null)
                return _notification.AddWithReturn<bool>("Ops.. você não pode apagar este aluno pois ele já está com matérias");

            _alunosRepository.Delete(alunoData);
            _notification.Add("O aluno foi deletado com sucesso");
            return true;
        }

        public IEnumerable<AlunosDto> Get()
        {
            var alunos = _alunosRepository.Get();

            return alunos.Select(x => new AlunosDto
            {
                Id = x.Id,
                Nome = x.Nome,
                RA = x.RA
            });
        }

        public AlunosDto GetById(int id)
        {
            var aluno = _alunosRepository.GetById(id);
            if (aluno == null)
                return _notification.AddWithReturn<AlunosDto>("Ops.. o aluno não pode ser encontrado");
            return new AlunosDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                RA = aluno.RA
            };
        }

        public IEnumerable<AlunosDto> GetByName(string nome)
        {
            var aluno = _alunosRepository.GetByName(nome);
            if (aluno == null)
                return _notification.AddWithReturn<IEnumerable<AlunosDto>>("Ops.. o aluno não pode ser encontrado");

            return aluno.Select(x => new AlunosDto
            {
                Id = x.Id,
                Nome = x.Nome,
                RA = x.RA

            });
        }

        public AlunosDto Post(AlunosDto alunoDto)
        {
            if (alunoDto.Nome == "" || alunoDto.RA == "")
                return _notification.AddWithReturn<AlunosDto>("Ops, você não pode inserir um campo vazio");

            var consultaRa = _alunosRepository.GetByRa(alunoDto.RA);
            if (consultaRa != null)
                return _notification.AddWithReturn<AlunosDto>("Ops.. este aluno já está cadastrado");

            var aluno = _alunosRepository.Post(new AlunosEntity
            {
                Nome = alunoDto.Nome,
                RA = alunoDto.RA,
            });

            return new AlunosDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                RA = aluno.RA
            };

        }
    }
}
