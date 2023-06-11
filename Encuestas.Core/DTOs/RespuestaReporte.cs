using Encuestas.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.DTOs
{
    public record RespuestaReporte
    {
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public List<RespuestaCantidad> Reporte { get; set; }
    }

    public record RespuestaCantidad
    {
        public string Respuesta { get; set; }
        public int Cantidad { get; set; }
    }
}
