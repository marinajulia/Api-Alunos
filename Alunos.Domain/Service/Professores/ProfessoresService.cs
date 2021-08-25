using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Domain.Service.Professores.Dto;
using Alunos.Domain.Service.Professores.Entities;
using Alunos.SharedKernel.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Domain.Service.Professores
{
    public class ProfessoresService : IProfessoresService
    {
        private readonly INotification _notification;
        private readonly IProfessoresRepository _professoresRepository;
        private readonly IMateriaProfessoresRepository _materiaProfessoresRepository;

        public ProfessoresService(IMateriaProfessoresRepository materiaProfessoresRepository,
            IProfessoresRepository professoresRepository, INotification notification)
        {
            _materiaProfessoresRepository = materiaProfessoresRepository;
            _professoresRepository = professoresRepository;
            _notification = notification;
        }

        public bool Delete(int professor)
        {
            var professorData = _professoresRepository.GetById(professor);
            if (professorData == null)
                return _notification.AddWithReturn<bool>("Ops.. O professor não pode ser encontrado!");

            var verificaRelacaoProfessorMateria = _materiaProfessoresRepository.GetByIdProfessores(professorData.Id);

            if (verificaRelacaoProfessorMateria != null)
                return _notification.AddWithReturn<bool>("Ops.. você não pode apagar este professor pois ele já está com matérias");

            _professoresRepository.Delete(professorData);
            _notification.Add("O professor foi deletado com sucesso");
            return true;
        }

        public IEnumerable<ProfessoresDto> Get()
        {
            var professores = _professoresRepository.Get();

            return professores.Select(x => new ProfessoresDto
            {
                Id = x.Id,
                Nome = x.Nome
            });
        }

        public ProfessoresDto GetById(int id)
        {
            var professor = _professoresRepository.GetById(id);
            if (professor == null)
                return _notification.AddWithReturn<ProfessoresDto>("Ops.. o professor não pode ser encontrado");
            return new ProfessoresDto
            {
                Id = professor.Id,
                Nome = professor.Nome
            };
        }

        public IEnumerable<ProfessoresDto> GetByName(string nome)
        {
            var professor = _professoresRepository.GetByName(nome);
            if (professor == null)
                return _notification.AddWithReturn<IEnumerable<ProfessoresDto>>("Ops.. o professor não pode ser encontrado");

            return professor.Select(x => new ProfessoresDto
            {
                Id = x.Id,
                Nome = x.Nome
            });
        }

        public ProfessoresDto Post(ProfessoresDto professor)
        {
            if (professor.Nome == "")
                return _notification.AddWithReturn<ProfessoresDto>("Ops, você não pode inserir um campo vazio");

            var consultaProfessor = _professoresRepository.GetByName(professor.Nome);
            if (consultaProfessor != null)
                return _notification.AddWithReturn<ProfessoresDto>("Ops.. este professor já está cadastrado");

            var newProfessor = _professoresRepository.Post(new ProfessoresEntity
            {
                Nome = professor.Nome
            });

            return new ProfessoresDto
            {
                Id = newProfessor.Id,
                Nome = newProfessor.Nome
            };
        }
    }
}
