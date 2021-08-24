using Alunos.Domain.Service.Materias.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alunos.Infra.Data.Configuration.Materias
{
    public class MateriasConfiguration : IEntityTypeConfiguration<MateriasEntity>
    {
        public void Configure(EntityTypeBuilder<MateriasEntity> builder)
        {
            builder.ToTable("Materias");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}
