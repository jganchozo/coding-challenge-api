using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Interfaces
{
    public interface IRespuestasService
    {
        Task InsertarRespuesta(Respuesta respuesta);
        Task<bool> InsertarRespuesta(EncuestaRespuestasDto respuesta);
        Task EliminarRespuesta(Respuesta respuesta);
        Task ActualizarRespuesta(Respuesta respuesta);
    }
}
