using Alunos.Domain.Service.Professores.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alunos.Infra.Data.Configuration.Professores
{
    public class ProfessoresConfiguration : IEntityTypeConfiguration<ProfessoresEntity>
    {
        public void Configure(EntityTypeBuilder<ProfessoresEntity> builder)
        {
            builder.ToTable("Professores");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}
