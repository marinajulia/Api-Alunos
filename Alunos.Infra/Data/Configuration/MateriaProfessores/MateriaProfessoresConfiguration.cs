using Alunos.Domain.Service.MateriaProfessores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alunos.Infra.Data.Configuration.MateriaProfessores
{
    public class MateriaProfessoresConfiguration : IEntityTypeConfiguration<MateriaProfessoresEntity>
    {
        public void Configure(EntityTypeBuilder<MateriaProfessoresEntity> builder)
        {
            builder.ToTable("MateriaProfessores");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IdMaterias).IsRequired();
            builder.Property(p => p.IdProfessores).IsRequired();
        }
    }
}
