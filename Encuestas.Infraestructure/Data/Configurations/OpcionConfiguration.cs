using Encuestas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Encuestas.Infraestructure.Data.Configurations
{
    public class OpcionConfiguration : IEntityTypeConfiguration<Opcione>
    {
        public void Configure(EntityTypeBuilder<Opcione> builder)
        {
            builder.HasKey(e => e.Idopcion);

            builder.Property(e => e.Idopcion).HasColumnName("IDOpcion");

            builder.Property(e => e.Idpregunta).HasColumnName("IDPregunta");

            builder.Property(e => e.Opcion).HasMaxLength(100);

            builder.HasOne(d => d.IdpreguntaNavigation)
                .WithMany(p => p.Opciones)
                .HasForeignKey(d => d.Idpregunta)
                .HasConstraintName("FK_Preguntas_Opciones");
        }
    }
}