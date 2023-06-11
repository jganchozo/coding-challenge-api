using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.DTOs
{
    public record PreguntasOpcionesReporteDto
    {
        public string Pregunta { get; set; }
        public List<Opcion> Opciones { get; set; }
    }

    public record Opcion
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
}
