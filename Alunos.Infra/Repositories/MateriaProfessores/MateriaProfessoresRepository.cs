using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Infra.Data;
using Microsoft.EntityFrameworkCore;
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

        public bool GetByCadastroExistente(int idMateria, int idProfessor)
        {
            using (var context = new ApplicationContext())
            {
                var cadastro = context.MateriaProfessores.FirstOrDefault(x => x.IdMaterias == idMateria && x.IdProfessores == idProfessor);
                return true;
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

        public MateriaProfessoresEntity GetByIdMateria(int id)
        {
            using (var context = new ApplicationContext())
            {
                var materia = context.MateriaProfessores.FirstOrDefault(x => x.IdMaterias == id);
                return materia;
            }
        }

        public MateriaProfessoresEntity GetByIdProfessores(int id)
        {
            using (var context = new ApplicationContext())
            {
                var professor = context.MateriaProfessores.FirstOrDefault(x => x.IdProfessores == id);
                return professor;
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

        public IEnumerable<MateriaProfessoresEntity> GetMateriasDeUmProfessor(int idProfessor)
        {
            using (var context = new ApplicationContext())
            {
                var materiaProfessores = context.MateriaProfessores
                    .Include(x => x.Materias)
                    .Include(x => x.Professores)
                    .Where(x => x.IdProfessores == idProfessor);
                return materiaProfessores.ToList();
            }
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
