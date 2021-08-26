using Alunos.Domain.Service.MateriaProfessores.Dto;
using Alunos.Domain.Service.Professores;
using Alunos.SharedKernel.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Domain.Service.MateriaProfessores
{
    public class MateriaProfessoresService : IMateriaProfessoresService
    {
        private readonly INotification _notification;
        private readonly IMateriaProfessoresRepository _materiaProfessoresRepository;
        private readonly IProfessoresRepository _professoresRepository;

        public MateriaProfessoresService(IMateriaProfessoresRepository materiaProfessoresRepository,
            INotification notification, IProfessoresRepository professoresRepository)
        {
            _materiaProfessoresRepository = materiaProfessoresRepository;
            _notification = notification;
            _professoresRepository = professoresRepository;
        }

        public bool Delete(int materiaProfessor)
        {

            var materiaProfessorData = _materiaProfessoresRepository.GetById(materiaProfessor);
            if (materiaProfessorData == null)
                return _notification.AddWithReturn<bool>("Ops.. a relação de matéria/professor não pode ser encontrada!");

            _materiaProfessoresRepository.Delete(materiaProfessorData);
            _notification.Add("A relação de matéria/professor foi deletada com sucesso");
            return true;
        }

        public IEnumerable<MateriaProfessoresDto> Get()
        {
            var materiaProfessores = _materiaProfessoresRepository.Get();

            return materiaProfessores.Select(x => new MateriaProfessoresDto
            {
                Id = x.Id,
                IdProfessores = x.IdProfessores,
                IdMaterias = x.IdMaterias
            }).ToList();
        }

        public MateriaProfessoresDto GetById(int id)
        {
            var materiaProfessor = _materiaProfessoresRepository.GetById(id);
            if (materiaProfessor == null)
                return _notification.AddWithReturn<MateriaProfessoresDto>("Ops.. a relação de matéria/professor não pode ser encontrada");
            return new MateriaProfessoresDto
            {
                Id = materiaProfessor.Id,
                IdProfessores = materiaProfessor.IdProfessores,
                IdMaterias = materiaProfessor.IdMaterias
            };
        }

        public IEnumerable<MateriaProfessoresDto> GetByNameMateria(string nome)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MateriaProfessoresDto> GetByNameProfessores(string nome)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MateriaProfessoresDto> GetMateriasDoProfessor(int idProfessor)
        {

            var materiaProfessoes = _professoresRepository.GetById(idProfessor);
            if (materiaProfessoes == null)
                return _notification.AddWithReturn<IEnumerable<MateriaProfessoresDto>>("Ops.. este professor não existe");

            var materiasDoProfessor = _materiaProfessoresRepository.GetMateriasDeUmProfessor(idProfessor);
            if (materiasDoProfessor == null)
                return _notification.AddWithReturn<IEnumerable<MateriaProfessoresDto>>
                    ("Não foi encontrado nenhuma matéria com este professor");

            return materiasDoProfessor.Select(x => new MateriaProfessoresDto
            {
                Id = x.Id,
                IdMaterias = x.IdMaterias,
                IdProfessores = x.IdProfessores,
                Materias = x.Materias,
                Professores = x.Professores,
            }).ToList();
        }

        public MateriaProfessoresDto Post(MateriaProfessoresDto materiaProfessoresDto)
        {
            var verificaCadastro = _materiaProfessoresRepository
                .GetByCadastroExistente(materiaProfessoresDto.IdMaterias, materiaProfessoresDto.IdProfessores);

            if (verificaCadastro)
                return _notification.AddWithReturn<MateriaProfessoresDto>("Ops.. este cadastro já existe");

            var materiaProfessor = _materiaProfessoresRepository.Post(new MateriaProfessoresEntity
            {
                IdProfessores = materiaProfessoresDto.IdProfessores,
                IdMaterias = materiaProfessoresDto.IdMaterias
            });

            return new MateriaProfessoresDto
            {
                Id = materiaProfessor.Id,
                IdProfessores = materiaProfessor.IdProfessores,
                IdMaterias = materiaProfessor.IdMaterias
            };
        }
    }
}
