using Alunos.Domain.Service.Alunos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alunos.Infra.Data.Configuration.Alunos
{
    public class AlunosConfiguration : IEntityTypeConfiguration<AlunosEntity>
    {
        public void Configure(EntityTypeBuilder<AlunosEntity> builder)
        {
            builder.ToTable("Alunos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}
