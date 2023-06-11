using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Encuestas.Core.Entities;
using Encuestas.Infraestructure.Data.Configurations;

#nullable disable

namespace Encuestas.Infraestructure.Data
{
    public partial class EncuestasContext : DbContext
    {
        public EncuestasContext()
        {
        }

        public EncuestasContext(DbContextOptions<EncuestasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Encuesta> Encuestas { get; set; }
        public virtual DbSet<Encuestado> Encuestados { get; set; }
        public virtual DbSet<Opcione> Opciones { get; set; }
        public virtual DbSet<Pregunta> Preguntas { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }
        public virtual DbSet<TipoRespuestum> TipoRespuesta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new EncuestaConfiguration());

            modelBuilder.ApplyConfiguration(new EncuestadoConfiguration());

            modelBuilder.ApplyConfiguration(new OpcionConfiguration());

            modelBuilder.ApplyConfiguration(new PreguntaConfiguration());

            modelBuilder.ApplyConfiguration(new RespuestaConfiguration());

            modelBuilder.ApplyConfiguration(new TipoRespuestaConfiguration());

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
