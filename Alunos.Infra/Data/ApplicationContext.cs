using Alunos.Domain.Service.Alunos.Entities;
using Alunos.Domain.Service.MateriaAlunos;
using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Domain.Service.Materias.Entities;
using Alunos.Domain.Service.Professores.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8024PRG\SERVIDOR;Initial Catalog=Alunos;Integrated Security=True");
        }
        public DbSet<AlunosEntity> Alunos { get; set; }
        public DbSet<ProfessoresEntity> Professores { get; set; }
        public DbSet<MateriasEntity> Materias { get; set; }
        public DbSet<MateriaAlunosEntity> MateriaAlunos { get; set; }
        public DbSet<MateriaProfessoresEntity> MateriaProfessores { get; set; }

    }
}
