using Encuestas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Infraestructure.Data.Configurations
{
    public class RespuestaConfiguration : IEntityTypeConfiguration<Respuesta>
    {
        public void Configure(EntityTypeBuilder<Respuesta> builder)
        {
            builder.HasKey(e => e.Idrespuesta);

            builder.Property(e => e.Idrespuesta).HasColumnName("IDRespuesta");

            builder.Property(e => e.Fecha).HasColumnType("date");

            builder.Property(e => e.Idencuesta).HasColumnName("IDEncuesta");

            builder.Property(e => e.Idencuestado).HasColumnName("IDEncuestado");

            builder.Property(e => e.Idpregunta).HasColumnName("IDPregunta");

            builder.Property(e => e.Respuesta1).HasColumnName("Respuesta");

            builder.HasOne(d => d.IdencuestaNavigation)
                .WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.Idencuesta)
                .HasConstraintName("FK_Encuestas_Respuestas");

            builder.HasOne(d => d.IdencuestadoNavigation)
                .WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.Idencuestado)
                .HasConstraintName("FK_Encuestados_Respuestas");

            builder.HasOne(d => d.IdpreguntaNavigation)
                .WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.Idpregunta)
                .HasConstraintName("FK_Preguntas_Respuestas");
        }
    }
}
