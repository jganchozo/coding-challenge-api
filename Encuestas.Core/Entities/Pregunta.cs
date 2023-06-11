using System.Collections.Generic;

#nullable disable

namespace Encuestas.Core.Entities
{
    public partial class Pregunta
    {
        public Pregunta()
        {
            Opciones = new HashSet<Opcione>();
            Respuesta = new HashSet<Respuesta>();
        }

        public int Idpregunta { get; set; }
        public int Idencuesta { get; set; }
        public string Pregunta1 { get; set; }
        public int? IdtipoRespuesta { get; set; }
        public int? Orden { get; set; }

        public virtual Encuesta IdencuestaNavigation { get; set; }
        public virtual TipoRespuestum IdtipoRespuestaNavigation { get; set; }
        public virtual ICollection<Opcione> Opciones { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
