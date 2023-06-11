using Encuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.DTOs
{
    public class EncuestaRespuestasDto
    {
        public int Idencuesta { get; set; }
        public int? Idencuestado { get; set; }
        public string UidUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public List<PreguntaOpcion> Respuestas { get; set; }
    }

    public partial class PreguntaOpcion
    {
        public int? Idpregunta { get; set; }
        public string Respuesta { get; set; }
        public int? IdtipoRespuesta { get; set; }
    }
}
