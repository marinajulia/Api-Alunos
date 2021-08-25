using Alunos.Domain.Service.MateriaAlunos;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Infra.Data.Configuration.MateriaAlunos
{
    public class MateriaAlunosConfiguration : IEntityTypeConfiguration<MateriaAlunosEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MateriaAlunosEntity> builder)
        {
            builder.ToTable("MateriaAlunos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IdAlunos).IsRequired();
            builder.Property(p => p.IdMaterias).IsRequired();
        }
    }
}
