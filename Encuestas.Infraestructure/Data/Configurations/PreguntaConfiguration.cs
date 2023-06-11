using Encuestas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encuestas.Infraestructure.Data.Configurations
{
    public class PreguntaConfiguration : IEntityTypeConfiguration<Pregunta>
    {
        public void Configure(EntityTypeBuilder<Pregunta> builder)
        {
            builder.HasKey(e => e.Idpregunta);

            builder.Property(e => e.Idpregunta).HasColumnName("IDPregunta");

            builder.Property(e => e.Idencuesta).HasColumnName("IDEncuesta");

            builder.Property(e => e.IdtipoRespuesta).HasColumnName("IDTipoRespuesta");

            builder.Property(e => e.Pregunta1)
                .HasMaxLength(250)
                .HasColumnName("Pregunta");

            builder.HasOne(d => d.IdencuestaNavigation)
                .WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.Idencuesta)
                .HasConstraintName("FK_Encuestas_Preguntas");

            builder.HasOne(d => d.IdtipoRespuestaNavigation)
                .WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdtipoRespuesta)
                .HasConstraintName("FK_TipoRespuesta_Preguntas");
        }
    }
}
