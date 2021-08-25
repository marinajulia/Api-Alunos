using Alunos.Domain.Service.MateriaAlunos;
using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Domain.Service.Materias.Dto;
using Alunos.Domain.Service.Materias.Entities;
using Alunos.SharedKernel.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Domain.Service.Materias
{
    public class MateriasService : IMateriasService
    {
        private readonly INotification _notification;
        private readonly IMateriasRepository _materiasRepository;
        private readonly IMateriaAlunosRepository _materiaAlunoRepository;
        private readonly IMateriaProfessoresRepository _materiaProfessoresRepository;

        public MateriasService(IMateriasRepository materiasRepository, INotification notification,
            IMateriaAlunosRepository materiaAlunosRepository, IMateriaProfessoresRepository materiaProfessoresRepository)
        {
            _materiasRepository = materiasRepository;
            _notification = notification;
            _materiaAlunoRepository = materiaAlunosRepository;
            _materiaProfessoresRepository = materiaProfessoresRepository;
        }

        public bool Delete(int materia)
        {
            var materiaData = _materiasRepository.GetById(materia);
            if (materiaData == null)
                return _notification.AddWithReturn<bool>("Ops.. A matéria não pode ser encontrada!");

            var verificaRelacaoAlunoMateria = _materiaAlunoRepository.GetByIdMateria(materiaData.Id);

            if (verificaRelacaoAlunoMateria != null)
                return _notification.AddWithReturn<bool>("Ops.. você não pode apagar esta matéria pois ela já está com alunos matriculados");

            var verificaRelacaoMateriaProfessor = _materiaProfessoresRepository.GetByIdMateria(materiaData.Id);

            if (verificaRelacaoMateriaProfessor != null)
                return _notification.AddWithReturn<bool>("Ops.. você não pode apagar esta matéria pois ela já está com professores no cargo");

            _materiasRepository.Delete(materiaData);
            _notification.Add("A matéria foi deletada com sucesso");
            return true;
        }

        public IEnumerable<MateriasDto> Get()
        {
            var materias = _materiasRepository.Get();

            return materias.Select(x => new MateriasDto
            {
                Id = x.Id,
                Nome = x.Nome
            });
        }

        public MateriasDto GetById(int id)
        {
            var materia = _materiasRepository.GetById(id);
            if (materia == null)
                return _notification.AddWithReturn<MateriasDto>("Ops.. a matéria não pode ser encontrada");
            return new MateriasDto
            {
                Id = materia.Id,
                Nome = materia.Nome
            };
        }

        public IEnumerable<MateriasDto> GetByName(string nome)
        {
            var materia = _materiasRepository.GetByName(nome);
            if (materia == null)
                return _notification.AddWithReturn<IEnumerable<MateriasDto>>("Ops.. a matéria não pode ser encontrada");

            return materia.Select(x => new MateriasDto
            {
                Id = x.Id,
                Nome = x.Nome
            });
        }

        public MateriasDto Post(MateriasDto materiaDto)
        {
            if (materiaDto.Nome == "")
                return _notification.AddWithReturn<MateriasDto>("Ops, você não pode inserir um campo vazio");

            var materia = _materiasRepository.Post(new MateriasEntity
            {
                Nome = materiaDto.Nome,
            });

            return new MateriasDto
            {
                Id = materia.Id,
                Nome = materia.Nome
            };
        }
    }
}
