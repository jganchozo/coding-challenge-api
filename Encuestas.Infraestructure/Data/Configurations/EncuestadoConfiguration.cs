using Encuestas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Encuestas.Infraestructure.Data.Configurations
{
    public class EncuestadoConfiguration : IEntityTypeConfiguration<Encuestado>
    {
        public void Configure(EntityTypeBuilder<Encuestado> builder)
        {
            builder.HasKey(e => e.Idencuestado);

            builder.Property(e => e.Idencuestado).HasColumnName("IDEncuestado");

            builder.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.UidUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("uidUsuario");
        }
    }
}
