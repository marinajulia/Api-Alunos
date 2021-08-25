using Alunos.Domain.Service.Alunos;
using Alunos.Domain.Service.MateriaAlunos.Dto;
using Alunos.Domain.Service.Materias;
using Alunos.SharedKernel.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Domain.Service.MateriaAlunos
{
    public class MateriaAlunosService : IMateriaAlunosService
    {
        private readonly INotification _notification;
        private readonly IMateriaAlunosRepository _materiaAlunosRepository;
        private readonly IMateriasRepository _materiasRepository;
        private readonly IAlunosRepository _alunosRepository;

        public MateriaAlunosService(IMateriaAlunosRepository materiaAlunosRepository, INotification notification,
            IMateriasRepository materiasRepository, IAlunosRepository alunosRepository)
        {
            _materiaAlunosRepository = materiaAlunosRepository;
            _notification = notification;
            _materiasRepository = materiasRepository;
            _alunosRepository = alunosRepository;
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
                IdMaterias = x.IdMaterias,
                Alunos = x.Alunos,
                Materias = x.Materias,
            }).ToList();
        }

        public IEnumerable<MateriaAlunosDto> GetAlunosdaMateria(int idMateria)
        {
            var materiaAlunos = _materiasRepository.GetById(idMateria);
            if (materiaAlunos == null)
                return _notification.AddWithReturn<IEnumerable<MateriaAlunosDto>>("Ops.. esta matéria não existe");

            var alunosDaMateria = _materiaAlunosRepository.GetAlunosDeUmaMateria(idMateria);
            if (alunosDaMateria == null)
                return _notification.AddWithReturn<IEnumerable<MateriaAlunosDto>>
                    ("Não foi encontrado nenhum aluno matriculado nesta matéria");

            return alunosDaMateria.Select(x => new MateriaAlunosDto
            {
                Id = x.Id,
                IdAlunos = x.IdAlunos,
                IdMaterias = x.IdMaterias,
                Alunos = x.Alunos,
                Materias = x.Materias,
            }).ToList();
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
                IdMaterias = materiaAluno.IdMaterias,
                Alunos = materiaAluno.Alunos,
                Materias = materiaAluno.Materias,
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

        public IEnumerable<MateriaAlunosDto> GetMateriasDoAluno(int idAluno)
        {
            var materiaAlunos = _alunosRepository.GetById(idAluno);
            if (materiaAlunos == null)
                return _notification.AddWithReturn<IEnumerable<MateriaAlunosDto>>("Ops.. este aluno não existe");

            var materiasDoAluno = _materiaAlunosRepository.GetMateriasDoAluno(idAluno);
            if (materiasDoAluno == null)
                return _notification.AddWithReturn<IEnumerable<MateriaAlunosDto>>
                    ("Não foi encontrado nenhuma matéria deste aluno");

            return materiasDoAluno.Select(x => new MateriaAlunosDto
            {
                Id = x.Id,
                IdAlunos = x.IdAlunos,
                IdMaterias = x.IdMaterias,
                Alunos = x.Alunos,
                Materias = x.Materias,
            }).ToList();
        }

        public MateriaAlunosDto Post(MateriaAlunosDto materiaAlunoDto)
        {

            var verificaCadastro = _materiaAlunosRepository
                .GetByCadastroExistente(materiaAlunoDto.IdMaterias, materiaAlunoDto.IdAlunos);

            if (verificaCadastro != null)
                return _notification.AddWithReturn<MateriaAlunosDto>("Ops.. este cadastro já existe");

            var verificaAluno = _alunosRepository.GetById(materiaAlunoDto.IdAlunos);
            if (verificaAluno == null)
                return _notification.AddWithReturn<MateriaAlunosDto>("Ops, este usuário não existe");

            var verificaMateria = _materiasRepository.GetById(materiaAlunoDto.IdMaterias);
            if (verificaMateria == null)
                return _notification.AddWithReturn<MateriaAlunosDto>("Ops.. esta matéria não existe");

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
