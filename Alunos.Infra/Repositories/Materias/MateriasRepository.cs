using Alunos.Domain.Service.Materias;
using Alunos.Domain.Service.Materias.Entities;
using Alunos.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Alunos.Infra.Repositories.Materias
{
    public class MateriasRepository : IMateriasRepository
    {
        public bool Delete(MateriasEntity materia)
        {
            using (var context = new ApplicationContext())
            {
                context.Materias.Remove(materia);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<MateriasEntity> Get()
        {
            using (var context = new ApplicationContext())
            {
                var materias = context.Materias;
                return materias.ToList();
            }
        }

        public MateriasEntity GetById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var materia = context.Materias.FirstOrDefault(x => x.Id == id);
                return materia;
            }
        }

        public IEnumerable<MateriasEntity> GetByName(string nome)
        {
            using (var context = new ApplicationContext())
            {
                var materias = context.Materias
                    .Where(x => x.Nome.Trim().ToLower().Contains(nome));

                return materias.ToList();
            }
        }

        public MateriasEntity Post(MateriasEntity materia)
        {
            using (var context = new ApplicationContext())
            {
                context.Materias.Add(materia);
                context.SaveChanges();
                return materia;
            }
        }
    }
}
