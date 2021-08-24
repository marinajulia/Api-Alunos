using Alunos.Domain.Service.Alunos;
using Alunos.Domain.Service.Alunos.Entities;
using Alunos.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Infra.Repositories.Alunos
{
    public class AlunosRepository : IAlunosRepository
    {
        public bool Delete(AlunosEntity aluno)
        {
            using (var context = new ApplicationContext())
            {
                context.Alunos.Remove(aluno);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<AlunosEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var alunos = context.Alunos;
                return alunos.ToList();
            }
        }

        public AlunosEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var aluno = context.Alunos.FirstOrDefault(x => x.Id == id);
                return aluno;
            }
        }

        public IEnumerable<AlunosEntity> GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var alunos = context.Alunos
                    .Where(x => x.Nome.Trim().ToLower().Contains(nome));

                return alunos.ToList();
            }
        }

        public AlunosEntity GetByRa(string ra)
        {
            using (var context = new ApplicationContext())
            {
                var aluno = context.Alunos.FirstOrDefault(x => x.RA == ra);
                return aluno;
            }
        }

        public AlunosEntity Post(AlunosEntity aluno)
        {
            using (var context = new ApplicationContext())
            {
                context.Alunos.Add(aluno);
                context.SaveChanges();
                return aluno;
            }
        }
    }
}
