using Alunos.Domain.Service.MateriaAlunos;
using Alunos.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Infra.Repositories.MateriaAlunos
{
    public class MateriaAlunosRepository : IMateriaAlunosRepository
    {
        public bool Delete(MateriaAlunosEntity materiaAlunos)
        {
            using (var context = new ApplicationContext())
            {
                context.MateriaAlunos.Remove(materiaAlunos);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<MateriaAlunosEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var materiaAlunos = context.MateriaAlunos;
                return materiaAlunos.ToList();
            }
        }

        public bool GetByCadastroExistente(int idMateria, int idAluno)
        {
            using (var context = new ApplicationContext())
            {
                var cadastro = context.MateriaAlunos
                    .FirstOrDefault(x => x.IdMaterias == idMateria && x.IdAlunos == idAluno);
                return true;
            }
        }

        public MateriaAlunosEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var materiaAluno = context.MateriaAlunos.FirstOrDefault(x => x.Id == id);
                return materiaAluno;
            }
        }

        public MateriaAlunosEntity GetByIdAluno(int id)
        {
            using (var context = new ApplicationContext())
            {
                var aluno = context.MateriaAlunos.FirstOrDefault(x => x.IdAlunos == id);
                return aluno;
            }
        }

        public MateriaAlunosEntity GetByIdMateria(int id)
        {
            using (var context = new ApplicationContext())
            {
                var materia = context.MateriaAlunos.FirstOrDefault(x => x.IdMaterias == id);
                return materia;
            }
        }
            public IEnumerable<MateriaAlunosEntity> GetByNameAluno(string nomeAluno)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MateriaAlunosEntity> GetByNameMateria(string nomeMateria)
        {
            throw new System.NotImplementedException();
        }

        public MateriaAlunosEntity Post(MateriaAlunosEntity materiaAluno)
        {
            using (var context = new ApplicationContext())
            {
                context.MateriaAlunos.Add(materiaAluno);
                context.SaveChanges();
                return materiaAluno;
            }
        }
    }
}
