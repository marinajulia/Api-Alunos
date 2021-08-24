using Microsoft.EntityFrameworkCore;

namespace Alunos.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8024PRG\SERVIDOR;Initial Catalog=Alunos;Integrated Security=True");
        }
    }
}
