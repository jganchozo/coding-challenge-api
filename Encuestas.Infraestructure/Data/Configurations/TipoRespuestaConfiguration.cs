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
    public class TipoRespuestaConfiguration : IEntityTypeConfiguration<TipoRespuestum>
    {
        public void Configure(EntityTypeBuilder<TipoRespuestum> builder)
        {
            builder.HasKey(e => e.IdtipoRespuesta);

            builder.Property(e => e.IdtipoRespuesta)
                .ValueGeneratedNever()
                .HasColumnName("IDTipoRespuesta");

            builder.Property(e => e.Tipo)
                .HasMaxLength(32)
                .IsUnicode(false);
        }
    }
}