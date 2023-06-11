using System;
using System.Collections.Generic;

#nullable disable

namespace Encuestas.Core.Entities
{
    public partial class Respuesta
    {
        public int Idrespuesta { get; set; }
        public Guid? Codigo { get; set; }
        public int Idencuesta { get; set; }
        public int? Idpregunta { get; set; }
        public int? Idencuestado { get; set; }
        public string Respuesta1 { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Encuesta IdencuestaNavigation { get; set; }
        public virtual Encuestado IdencuestadoNavigation { get; set; }
        public virtual Pregunta IdpreguntaNavigation { get; set; }
    }
}
