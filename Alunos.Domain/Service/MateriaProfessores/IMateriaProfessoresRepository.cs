using System.Collections.Generic;

namespace Alunos.Domain.Service.MateriaProfessores
{
    public interface IMateriaProfessoresRepository
    {
        IEnumerable<MateriaProfessoresEntity> Get();
        MateriaProfessoresEntity GetById(int id);
        IEnumerable<MateriaProfessoresEntity> GetMateriasDeUmProfessor(int idProfessor);
        MateriaProfessoresEntity GetByIdMateria(int id);
        MateriaProfessoresEntity GetByIdProfessores(int id);
        MateriaProfessoresEntity Post(MateriaProfessoresEntity materiaProfessores);
        IEnumerable<MateriaProfessoresEntity> GetByNameProfessor(string nomeProfessor);
        IEnumerable<MateriaProfessoresEntity> GetByNameMateria(string nomeMateria);
        bool Delete(MateriaProfessoresEntity materiaProfessores);
        bool GetByCadastroExistente(int idMateria, int idProfessor);
    }
}
