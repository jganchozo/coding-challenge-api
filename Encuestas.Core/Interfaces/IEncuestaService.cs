using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Interfaces
{
    public interface IEncuestaService
    {
        Task<IEnumerable<Encuesta>> ObtenerEncuestas();
        Task<bool> EliminarEncuesta(int id);
        Task<Encuesta> ObtenerEncuestaById(int id);
        Task<Encuesta> CrearEncuesta(Encuesta encuesta);
        Task<Encuesta> ActualizarEncuesta(Encuesta encuesta);
    }
}
