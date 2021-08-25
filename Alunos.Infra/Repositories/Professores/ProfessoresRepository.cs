using Alunos.Domain.Service.Professores;
using Alunos.Domain.Service.Professores.Entities;
using Alunos.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Infra.Repositories.Professores
{
    public class ProfessoresRepository : IProfessoresRepository
    {
        public bool Delete(ProfessoresEntity professor)
        {
            using (var context = new ApplicationContext())
            {
                context.Professores.Remove(professor);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<ProfessoresEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var professores = context.Professores;
                return professores.ToList();
            }
        }

        public ProfessoresEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var professor = context.Professores.FirstOrDefault(x => x.Id == id);
                return professor;
            }
        }

        public IEnumerable<ProfessoresEntity> GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var professores = context.Professores
                    .Where(x => x.Nome.Trim().ToLower().Contains(nome));

                return professores.ToList();
            }
        }

        public ProfessoresEntity GetNames(string name)
        {
            using (var context = new ApplicationContext())
            {
                var professor = context.Professores.FirstOrDefault(x => x.Nome == name);

                return professor;
            }
        }

        public ProfessoresEntity Post(ProfessoresEntity professor)
        {
            using (var context = new ApplicationContext())
            {
                context.Professores.Add(professor);
                context.SaveChanges();
                return professor;
            }
        }
    }
}
