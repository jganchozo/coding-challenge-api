using Encuestas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encuestas.Infraestructure.Data.Configurations
{
    public class EncuestaConfiguration : IEntityTypeConfiguration<Encuesta>
    {
        public void Configure(EntityTypeBuilder<Encuesta> builder)
        {
            builder.HasKey(e => e.Idencuesta);

            builder.Property(e => e.Idencuesta).HasColumnName("IDEncuesta");

            builder.Property(e => e.Fecha).HasColumnType("datetime");

            builder.Property(e => e.Titulo).HasMaxLength(100);
        }
    }
}
