using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Infra.Repositories.MateriaProfessores
{
    public class MateriaProfessoresRepository : IMateriaProfessoresRepository
    {
        public bool Delete(MateriaProfessoresEntity materiaProfessor)
        {
            using (var context = new ApplicationContext())
            {
                context.MateriaProfessores.Remove(materiaProfessor);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<MateriaProfessoresEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var materiaProfessores = context.MateriaProfessores;
                return materiaProfessores.ToList();
            }
        }

        public MateriaProfessoresEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var materiaProfessor = context.MateriaProfessores.FirstOrDefault(x => x.Id == id);
                return materiaProfessor;
            }
        }

        public IEnumerable<MateriaProfessoresEntity> GetByNameMateria(string nomeMateria)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MateriaProfessoresEntity> GetByNameProfessor(string nomeProfessor)
        {
            throw new System.NotImplementedException();
        }

        public MateriaProfessoresEntity Post(MateriaProfessoresEntity materiaProfessores)
        {
            using (var context = new ApplicationContext())
            {
                context.MateriaProfessores.Add(materiaProfessores);
                context.SaveChanges();
                return materiaProfessores;
            }
        }
    }
}
