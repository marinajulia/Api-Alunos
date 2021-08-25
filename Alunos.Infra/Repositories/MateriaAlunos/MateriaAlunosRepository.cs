using Alunos.Domain.Service.MateriaAlunos;
using Alunos.Infra.Data;
using Microsoft.EntityFrameworkCore;
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
                var materiaAlunos = context.MateriaAlunos
                    .Include(x=> x.Alunos)
                    .Include(x=> x.Materias);
                return materiaAlunos.ToList();
            }
        }

        public IEnumerable<MateriaAlunosEntity> GetAlunosDeUmaMateria(int idMateria)
        {
            using (var context = new ApplicationContext())
            {
                var materiaAlunos = context.MateriaAlunos
                    .Include(x => x.Materias)
                    .Include(x => x.Alunos)
                    .Where(x => x.IdMaterias == idMateria);
                return materiaAlunos.ToList();
            }
        }

        public MateriaAlunosEntity GetByCadastroExistente(int idMateria, int idAluno)
        {
            using (var context = new ApplicationContext())
            {
                var cadastro = context.MateriaAlunos
                    .FirstOrDefault(x => x.IdMaterias == idMateria && x.IdAlunos == idAluno);
                return cadastro;
            }
        }

        public MateriaAlunosEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var materiaAluno = context.MateriaAlunos
                    .Include(x => x.Alunos)
                    .Include(x => x.Materias)
                    .FirstOrDefault(x => x.Id == id);
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

        public IEnumerable<MateriaAlunosEntity> GetMateriasDoAluno(int idAluno)
        {
            using (var context = new ApplicationContext())
            {
                var materiaAlunos = context.MateriaAlunos
                    .Include(x => x.Materias)
                    .Include(x => x.Alunos)
                    .Where(x => x.IdAlunos == idAluno);
                return materiaAlunos.ToList();
            }
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
