using System;
using System.Collections.Generic;

#nullable disable

namespace Encuestas.Core.Entities
{
    public partial class Encuesta
    {
        public Encuesta()
        {
            Pregunta = new HashSet<Pregunta>();
            Respuesta = new HashSet<Respuesta>();
        }

        public int Idencuesta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<Pregunta> Pregunta { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
