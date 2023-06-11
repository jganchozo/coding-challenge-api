using Encuestas.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encuestas.Core.Interfaces
{
    public interface IReportesService
    {
        Task<IEnumerable<RespuestaReporte>> ObtenerRespuestas(string encuesta);
        Task<IEnumerable<PreguntasOpcionesReporteDto>> ObtenerRespuestasOpciones();
        Task<int> ObtenerPorcentajePregunta(string pregunta);
    }
}
