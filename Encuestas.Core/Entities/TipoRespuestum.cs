using System;
using System.Collections.Generic;

#nullable disable

namespace Encuestas.Core.Entities
{
    public partial class TipoRespuestum
    {
        public TipoRespuestum()
        {
            Pregunta = new HashSet<Pregunta>();
        }

        public int IdtipoRespuesta { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Pregunta> Pregunta { get; set; }
    }
}
