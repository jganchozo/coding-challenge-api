using Encuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.DTOs
{
    public class PreguntaDto
    {
        public int Idpregunta { get; set; }
        public int? Idencuesta { get; set; }
        public string Pregunta1 { get; set; }
        public string Encuesta { get; set; }
        public int? IdtipoRespuesta { get; set; }
        public int? Orden { get; set; }
        public IEnumerable<OpcionDto> Opciones { get; set; }
    }
}
